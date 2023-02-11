using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public string scene;
    public Animator transistion;
    public static float transistionTime = 1.1f;

    // Start is called before the first frame update
    public void sceneLoad()
    {
        SceneManager.LoadScene(scene);
    }

    public void startLevel() 
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel() 
    {
        transistion.SetTrigger("out");

        yield return new WaitForSeconds(transistionTime);

        sceneLoad();

    }
}
