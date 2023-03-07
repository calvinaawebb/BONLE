using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play : MonoBehaviour
{
    public Transform skeleton;
    public Material based;
    public Canvas Main;
    public Canvas GameOver;
    
    void Start() 
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }

    public void Scene1()
    {
        SceneManager.LoadScene("Selection");
    }
    public void Scene0() 
    {
        Application.Quit();
    }
    public void Back() 
    {
        SceneManager.LoadScene("Title");
    }
    //public void Retry() 
    //{
    //    Main.enabled = true;
    //    GameOver.gameObject.SetActive(false);
    //    foreach (Transform child in skeleton)
    //    {
    //        if (child.name != "Orbit")
    //        {
    //            try {
    //                child.GetComponent<MeshRenderer>().material = based;
    //            }
    //            catch (Exception e) 
    //            {
    //                foreach (Transform children in child)
    //                {
    //                    children.GetComponent<MeshRenderer>().material = based;
    //                }
    //            }
    //        }
    //    }
    //}
}
