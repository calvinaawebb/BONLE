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

    // Start is called before the first frame update
    void Start()
    {
        name = "Unknown";
    }

    public void returnName() 
    {
        name = input.text;
    }
}
