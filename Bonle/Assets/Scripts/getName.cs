using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour
{
    public static string name;
    public InputField input;
    public Text entry;
    public GameObject inputfield;

    // Start is called before the first frame update
    void Awake()
    {
        if (name == null) 
        {
            name = "Unknown";
        }
        inputfield = input.gameObject;
        if (name != "Unknown") 
        {
            inputfield.SetActive(false);
            entry.text = "Username: " + name;
        }
    }

    public void setName() 
    {
        name = input.text;
        inputfield.SetActive(false);
        entry.text = "Username: " + name;
        //DontDestroyOnLoad(entry.transform.root.gameObject);
    }
}
