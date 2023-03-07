    using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class Unity3dOrbit : MonoBehaviour
{
    // Unity's built in orbit system  that I tweaked for my purposes.
    public Transform target;
    public LayerMask ignore;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = -20f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    private Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    float tx = 0.0f;
    float ty = 0.0f;

    bool orbitable;
    bool move;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void Update() { 
        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit, ignore))
        {
            distance -= hit.distance;
        }
    }

    void LateUpdate()
    {
        // Checking booleans to see if it is a valid time to move and in what way.
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 50, distanceMin, distanceMax);
        if (Input.GetMouseButtonDown(0))
        {
            orbitable = true;
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            orbitable = false;
        }
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && orbitable)
        {
            move = true;
            Debug.Log("clicked");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            move = false;
            Debug.Log("Unclicked");
        }

        // Assuming booleans are all fine, move.
        if (orbitable)
        {
            if (target)
            {
                if (move)
                {
                    tx -= Input.GetAxis("Mouse X");
                    ty -= Input.GetAxis("Mouse Y");

                    y = ClampAngle(y, yMinLimit, yMaxLimit);
                }
                else 
                {
                    x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                    y = ClampAngle(y, yMinLimit, yMaxLimit);
                }
            }
        }
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 targetCoords = new Vector3(tx, ty, 0);

        target.position = targetCoords;
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;
        transform.rotation = rotation;
        transform.position = position;
    }

    // Setting limits for how far it can turn according to screen width/height.
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
