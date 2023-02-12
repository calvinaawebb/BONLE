using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class colorize : MonoBehaviour
{
    public InputField input;
    public Transform skeleB;
    public Transform skeleA;
    public GameObject bone;
    public GameObject tBone;
    public Transform randB;
    public GameObject skeleton;
    public Transform resetSkeleton;
    public int num;


    public Dictionary<string, string> prevNode = new Dictionary<string, string>();

    public Dictionary<string, double> shortestdistance = new Dictionary<string, double>();


    public GraphNode guess;
    public GraphNode target;

    public graphClass graph;

    public Canvas Main;
    public Canvas GameOver;


    // material.colors
    private Color farthest;
    private Color farther;
    private Color far;
    private Color close;
    private Color closer;
    private Color closest;
    private Color based;

    void Start()
    {
        ColorUtility.TryParseHtmlString("#FFC8C8", out farthest);
        ColorUtility.TryParseHtmlString("#FFAAAA", out farther);
        ColorUtility.TryParseHtmlString("#FF5353", out far);
        ColorUtility.TryParseHtmlString("#FF0000", out close);
        ColorUtility.TryParseHtmlString("#B40000", out closer);
        ColorUtility.TryParseHtmlString("#6F0000", out closest);
        ColorUtility.TryParseHtmlString("#FFFFFF", out based);

        // Random Bone(randB) to use as target bone(tBone) using random number(num)
        num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
        randB = skeleton.transform.GetChild(num);
        tBone = GameObject.Find(randB.name);

        while (tBone.name == "Orbit") 
        {
            num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
            randB = skeleton.transform.GetChild(num);
            tBone = GameObject.Find(randB.name);
        }
    }

    public void Retry()
    {
        Main.enabled = true;
        GameOver.gameObject.SetActive(false);
        num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
        randB = skeleton.transform.GetChild(num);
        tBone = GameObject.Find(randB.name);
        foreach (Transform child in resetSkeleton)
        {
            if (child.name != "Orbit")
            {
                try
                {
                    child.GetComponent<MeshRenderer>().material.color = based;
                }
                catch (Exception e)
                {
                    foreach (Transform children in child)
                    {
                        children.GetComponent<MeshRenderer>().material.color = based;
                    }
                }
            }
        }
    }

    public void activate()
    {
        // Getting the bone object
        skeleB = skeleton.transform.Find(input.text.ToLower());
        Debug.Log("Skeleb: " + skeleB.name);
        Debug.Log("this target: " + tBone.name.ToLower());

        // Finding the node that corresponds with the bone object in unity.
        foreach (GraphNode node in graph.node_list)
        {
            if (node.Name == tBone.name.ToLower())
            {
                target = node;
                Debug.Log("target: " + target.Name);
            }
            if (node.Name == input.text.ToLower())
            {
                guess = node;
                Debug.Log("guess: " + guess.Name);
            }
        }

        // Dijkstra's Algorithm: basically just takes the node I give it(target) and finds the shortest distance to all other nodes based off of their connections.
        void djk(GraphNode anchor) {
            foreach (GraphNode child in anchor.Children)
            {
                try {
                    if (shortestdistance.ContainsKey(child.Name))
                    {
                        if (shortestdistance[child.Name] > (graph.valuePairs[anchor.Name + child.Name] + shortestdistance[anchor.Name]))
                        {
                            shortestdistance[child.Name] = (graph.valuePairs[anchor.Name + child.Name] + shortestdistance[anchor.Name]);
                        }
                    } else {
                        shortestdistance.Add(child.Name, graph.valuePairs[anchor.Name + child.Name] + shortestdistance[anchor.Name]);
                        prevNode.Add(child.Name, anchor.Name);
                        djk(child);
                    }
                }
                catch (KeyNotFoundException e) {
                    if (shortestdistance.ContainsKey(child.Name))
                    {
                        if (shortestdistance[child.Name] > (graph.valuePairs[child.Name + anchor.Name] + shortestdistance[anchor.Name]))
                        {
                            shortestdistance[child.Name] = (graph.valuePairs[child.Name + anchor.Name] + shortestdistance[anchor.Name]);
                        }
                    }
                    else
                    {
                        shortestdistance.Add(child.Name, graph.valuePairs[child.Name + anchor.Name] + shortestdistance[anchor.Name]);
                        prevNode.Add(child.Name, anchor.Name);
                        djk(child);
                    }
                }
            }
        }
        shortestdistance.Add(target.Name, 0);
        djk(target);
        Debug.Log(shortestdistance.Count);
        foreach (var val in shortestdistance)
        {
            Debug.Log("Key: " + val.Key + " Value: " + val.Value);
        }
        
        if (guess.Name != null)
        {
            Debug.Log(tBone);
            Debug.Log("guess: " + guess.Name + " target: " + target.Name);
            if (guess.Name == target.Name)
            {
                num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
                Main.enabled = false;
                GameOver.gameObject.SetActive(true);
            }
            else
            {
                // For anybody seeing this later and thinking "why didnt he just use a switch" I am recycling old code and I dont want to make it a switch.
                // If you are seeing this I was too lazy to just switch the ifs to a switch(haha).
                try {
                    if (shortestdistance[guess.Name] <= 1.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material.color = closest;
                    }
                    else if (shortestdistance[guess.Name] > 1.5 && shortestdistance[guess.Name] <= 2.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material.color = closer;
                    }
                    else if (shortestdistance[guess.Name] > 2.5 && shortestdistance[guess.Name] <= 3.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material.color = close;
                    }
                    else if (shortestdistance[guess.Name] > 3.5 && shortestdistance[guess.Name] <= 4.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material.color = far;
                    }
                    else if (shortestdistance[guess.Name] > 4.5 && shortestdistance[guess.Name] <= 6)
                    {
                        skeleB.GetComponent<MeshRenderer>().material.color = farther;
                    }
                    else if (shortestdistance[guess.Name] > 6)
                    {
                        skeleB.GetComponent<MeshRenderer>().material.color = farthest;
                    }
                }
                catch (Exception e)  
                {
                    for (int i = 0; i < skeleB.transform.childCount; i++) 
                    {
                        skeleA = skeleB.transform.GetChild(i);
                        if (shortestdistance[guess.Name] <= 1.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material.color = closest;
                        }
                        else if (shortestdistance[guess.Name] > 1.5 && shortestdistance[guess.Name] <= 2.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material.color = closer;
                        }
                        else if (shortestdistance[guess.Name] > 2.5 && shortestdistance[guess.Name] <= 3.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material.color = close;
                        }
                        else if (shortestdistance[guess.Name] > 3.5 && shortestdistance[guess.Name] <= 4.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material.color = far;
                        }
                        else if (shortestdistance[guess.Name] > 4.5 && shortestdistance[guess.Name] <= 6)
                        {
                            skeleA.GetComponent<MeshRenderer>().material.color = farther;
                        }
                        else if (shortestdistance[guess.Name] > 6)
                        {
                            skeleA.GetComponent<MeshRenderer>().material.color = farthest;
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not a valid bone");
        }
        shortestdistance.Clear();
        prevNode.Clear();
    }
}
