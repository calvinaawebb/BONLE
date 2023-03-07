using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Image inp;
    public Sprite[] imagesList = new Sprite[4];
    public int current;

    // Used to inumerate up in the slides of images in the tutorial.
    public void inumeraterUp()
    {
        for (int i = 0; i < imagesList.Length; i++)
        {
            if (imagesList[i] == inp.sprite)
            {
                current = i + 1;
            }
        }
        try
        {
            inp.sprite = imagesList[current];
        }
        catch (IndexOutOfRangeException e)
        {
            inp.sprite = imagesList[0];
        }
    }

    // Used to inumerate down in the slides of images in the tutorial.
    public void inumeraterDown()
    {
        for (int i = 0; i < imagesList.Length; i++)
        {
            if (imagesList[i] == inp.sprite)
            {
                current = i - 1;
            }
        }
        try
        {
            inp.sprite = imagesList[current];
        }
        catch (IndexOutOfRangeException e)
        {
            inp.sprite = imagesList[imagesList.Length - 1];
        }
    }
}

