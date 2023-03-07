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
    public Color[] colors;
    private static Color farthest;
    private static Color farther;
    private static Color far;
    private static Color close;
    private static Color closer;
    private static Color closest;
    private static Color based;

    void Start()
    {
        // Sets all the colors.
        ColorUtility.TryParseHtmlString("#FFC8C8", out farthest);
        ColorUtility.TryParseHtmlString("#FFAAAA", out farther);
        ColorUtility.TryParseHtmlString("#FF5353", out far);
        ColorUtility.TryParseHtmlString("#FF0000", out close);
        ColorUtility.TryParseHtmlString("#B40000", out closer);
        ColorUtility.TryParseHtmlString("#6F0000", out closest);
        ColorUtility.TryParseHtmlString("#FFFFFF", out based);

        colors = new Color[] { closest, closer, close, far, farther, farthest };

        // Random Bone(randB) to use as target bone(tBone) using random number(num).
        num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
        randB = skeleton.transform.GetChild(num);
        tBone = GameObject.Find(randB.name);

        // Excuses the gameobject I use to center the camera when it is moving.
        while (tBone.name == "Orbit") 
        {
            num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
            randB = skeleton.transform.GetChild(num);
            tBone = GameObject.Find(randB.name);
        }
    }

    // Dijkstra's Algorithm: basically just takes the node I give it(target) and finds the shortest distance to all other nodes based off of their connections.
    public void djk(GraphNode anchor, Dictionary<String, Double> dist, Dictionary<String, Double> edges)
    {
        foreach (GraphNode child in anchor.Children)
        {
            try
            {
                if (dist.ContainsKey(child.Name))
                {
                    if (dist[child.Name] > (edges[anchor.Name + child.Name] + dist[anchor.Name]))
                    {
                        dist[child.Name] = (edges[anchor.Name + child.Name] + dist[anchor.Name]);
                    }
                }
                else
                {
                    dist.Add(child.Name, edges[anchor.Name + child.Name] + dist[anchor.Name]);
                    prevNode.Add(child.Name, anchor.Name);
                    djk(child, dist, edges);
                }
            }
            catch (KeyNotFoundException e)
            {
                if (dist.ContainsKey(child.Name))
                {
                    if (dist[child.Name] > (edges[child.Name + anchor.Name] + dist[anchor.Name]))
                    {
                        dist[child.Name] = (edges[child.Name + anchor.Name] + dist[anchor.Name]);
                    }
                }
                else
                {
                    dist.Add(child.Name, edges[child.Name + anchor.Name] + dist[anchor.Name]);
                    prevNode.Add(child.Name, anchor.Name);
                    djk(child, dist, edges);
                }
            }
        }
    }

    // Retry function that resets all of the bone meshes to their base color and regenerates the target bone so you can play again.
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

    // Simple optimization to make coloring a bone faster and take less space.
    public void colorBone(Transform bone, double num, Color[] cols) 
    {
        try
        {
            bone.GetComponent<MeshRenderer>().material.color = cols[(int)num-1];
        }
        catch(IndexOutOfRangeException e) 
        {
            bone.GetComponent<MeshRenderer>().material.color = cols[cols.Length-1];
        }
    }

    // Main runtime of the logic where all the logic is combined to color the bones based of their nodal distance to the target.
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

        // Activate dijkstra's algorithm.
        shortestdistance.Add(target.Name, 0);
        djk(target, shortestdistance, graph.valuePairs);

        // Process the input from the user and color the bones respectively as well as handle if player guess the right bone.
        if (guess.Name != null)
        {
            if (guess.Name == target.Name)
            {
                num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
                Main.enabled = false;
                GameOver.gameObject.SetActive(true);
            }
            else
            {
                try {
                    colorBone(skeleB, shortestdistance[guess.Name], colors);
                }
                catch (Exception e)  
                {
                    for (int i = 0; i < skeleB.transform.childCount; i++) 
                    {
                        skeleA = skeleB.transform.GetChild(i);
                        colorBone(skeleA, shortestdistance[guess.Name], colors);
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
