using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Plsy : MonoBehaviour
{
    public Transform skeleton;
    public Material based;
    public Canvas Main;
    public Canvas GameOver;

    public void Scene1()
    {
        SceneManager.LoadScene("main");
    }
    public void Scene0() 
    {
        Application.Quit();
    }
    public void Back() 
    {
        SceneManager.LoadScene("Title");
    }
    public void Retry() 
    {
        Main.enabled = true;
        GameOver.gameObject.SetActive(false);
        foreach (Transform child in skeleton)
        {
            if (child.name != "Orbit") {
                child.GetComponent<MeshRenderer>().material = based;
            } 
        }
    }
}
