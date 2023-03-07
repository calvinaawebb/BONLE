using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class loadScene : MonoBehaviour
{
    public string scene;
    public static string skeleType;
    public Animator transistion;
    public static float transistionTime = 1.1f;
    public string difficulty;
    public GameObject slider;
    public bool practice;

    // Used with the escape key to close the application.
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }

    // Final function to load the scene provided.
    public void sceneLoad(string inpScene)
    {
        SceneManager.LoadScene(inpScene);
        difficulty = "";
    }

    // First function that gets called, calls coroutine to start its processes.
    public void startLevel() 
    {
        StartCoroutine(LoadLevel());
    }

    // Sets the name of the scene that is being loaded using the variables inputed into the script.
    public void difficultySet() 
    {
        if (skeleType.Length != 0) 
        {
            if (practice) 
            {
                difficulty = skeleType + "_" + difficulty + "_PRACTICE" ;
                sceneLoad(difficulty);
            } else 
            {
                difficulty = skeleType + "_" + difficulty;
                sceneLoad(difficulty);
            }
        }
    }

    // Main runtime that combines all the functions to process the input given to the script, turn it into a scene name, and load said scene.
    IEnumerator LoadLevel() 
    {
        transistion.SetTrigger("out");

        yield return new WaitForSeconds(transistionTime);

        Debug.Log("going in");
        skeleType = gameObject.name;
        try 
        {
            difficulties scrip = slider.GetComponent<difficulties>();
            difficulty = scrip.inp.text;
            difficultySet();
        } 
        catch (Exception e) {
            sceneLoad(scene);
        }
    }
}
