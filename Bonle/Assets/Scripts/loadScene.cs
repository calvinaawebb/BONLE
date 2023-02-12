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

    // Start is called before the first frame update
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
            difficulty = skeleType + "_" + difficulty;
            sceneLoad(difficulty);
        }
    }

    IEnumerator LoadLevel() 
    {
        transistion.SetTrigger("out");

        yield return new WaitForSeconds(transistionTime);

        Debug.Log("going in");
        try 
        {
            if (difficulty.Length != 0) 
            {
                difficultySet();
            } else {
                skeleType = gameObject.name;
                Debug.Log("Switching");
                sceneLoad(scene);
            }
        } catch (Exception e) {
            skeleType = gameObject.name;
            Debug.Log("Switching");
            sceneLoad(scene);
        }
    }
}
