using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update
    public void sceneLoad()
    {
        SceneManager.LoadScene(scene);
    }
}
