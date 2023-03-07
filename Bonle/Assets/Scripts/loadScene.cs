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

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
            Debug.Log("quitefefie");
        }
    }

    public void sceneLoad(string inpScene)
    {
        SceneManager.LoadScene(inpScene);
        difficulty = "";
    }

    public void startLevel() 
    {
        StartCoroutine(LoadLevel());
    }

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
