using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficulties : MonoBehaviour
{
    public Text inp;
    public GameObject inpObject;
    public string[] difficultyList = new string[] {"EASY", "NORMAL", "HARD"};
    public int current;

    void Start() 
    {
        inp = inpObject.GetComponent<Text>();  
    }

    public void inumeraterUp() 
    {
        for (int i=0;i<difficultyList.Length;i++) 
        {
            if (difficultyList[i] == inp.text) 
            {
                current = i+1;
            }
        }
        try 
        {
            inp.text = difficultyList[current];
        }
        catch (IndexOutOfRangeException e) 
        {
            inp.text = difficultyList[0];
        }
    }

    public void inumeraterDown() 
    {
        for (int i=0;i<difficultyList.Length;i++) 
        {
            if (difficultyList[i] == inp.text) 
            {
                current = i-1;
            }
        }
        try 
        {
            inp.text = difficultyList[current];
        }
        catch (IndexOutOfRangeException e) 
        {
            inp.text = difficultyList[difficultyList.Length-1];
        }
    }
}
