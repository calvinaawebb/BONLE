using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class normalCat : MonoBehaviour
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
    public Dictionary<string, double> valuePairs = new Dictionary<string, double>();
    public Dictionary<string, string> prevNode = new Dictionary<string, string>();
    public Dictionary<string, double> shortestdistance = new Dictionary<string, double>();
    public GraphNode guess;
    public GraphNode target;

    public Canvas Main;
    public Canvas GameOver;

    private ArrayList node_list = new ArrayList();

    // materials
    public Material farthest;
    public Material farther;
    public Material far;
    public Material close;
    public Material closer;
    public Material closest;
    public Material based;

    void Start()
    {
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

        GraphNode head = new GraphNode("skull");
        node_list.Add(head);

        GraphNode uSpine = new GraphNode("spine");
        head.AddConnection(uSpine);
        valuePairs.Add(head.Name + uSpine.Name, 1.0);
        node_list.Add(uSpine);

        GraphNode lSpine = new GraphNode("spine l");
        uSpine.AddConnection(lSpine);
        valuePairs.Add(uSpine.Name + lSpine.Name, 1.0);
        node_list.Add(lSpine);

        GraphNode ribcage = new GraphNode("ribcage");
        uSpine.AddConnection(ribcage);
        valuePairs.Add(uSpine.Name + ribcage.Name, 1.0);
        node_list.Add(ribcage);

        GraphNode rClavicle = new GraphNode("clavicle r");
        ribcage.AddConnection(rClavicle);
        valuePairs.Add(ribcage.Name + rClavicle.Name, 1.0);
        node_list.Add(rClavicle);

        GraphNode rScapula = new GraphNode("scapula r");
        ribcage.AddConnection(rScapula);
        valuePairs.Add(ribcage.Name + rScapula.Name, 1.0);
        rClavicle.AddConnection(rScapula);
        valuePairs.Add(rClavicle.Name + rScapula.Name, 1.0);
        node_list.Add(rScapula);

        GraphNode lClavicle = new GraphNode("clavicle l");
        ribcage.AddConnection(lClavicle);
        valuePairs.Add(ribcage.Name + lClavicle.Name, 1.0);
        node_list.Add(lClavicle);

        GraphNode lScapula = new GraphNode("scapula l");
        ribcage.AddConnection(lScapula);
        valuePairs.Add(ribcage.Name + lScapula.Name, 1.0);
        lClavicle.AddConnection(lScapula);
        valuePairs.Add(lClavicle.Name + lScapula.Name, 1.0);
        node_list.Add(lScapula);

        GraphNode rHumerus = new GraphNode("humerus r");
        rScapula.AddConnection(rHumerus);
        valuePairs.Add(rScapula.Name + rHumerus.Name, 1.0);
        node_list.Add(rHumerus);

        GraphNode rForearm = new GraphNode("forearm r");
        rHumerus.AddConnection(rForearm);
        valuePairs.Add(rHumerus.Name + rForearm.Name, 1.0);
        node_list.Add(rForearm);

        GraphNode rfFoot = new GraphNode("foot rf");
        rForearm.AddConnection(rfFoot);
        valuePairs.Add(rForearm.Name + rfFoot.Name, 1.0);
        node_list.Add(rfFoot);

        GraphNode lHumerus = new GraphNode("humerus l");
        lScapula.AddConnection(lHumerus);
        valuePairs.Add(lScapula.Name + lHumerus.Name, 1.0);
        node_list.Add(lHumerus);

        GraphNode lForearm = new GraphNode("forearm l");
        lHumerus.AddConnection(lForearm);
        valuePairs.Add(lHumerus.Name + lForearm.Name, 1.0);
        node_list.Add(lForearm);

        GraphNode lfFoot = new GraphNode("foot lf");
        lForearm.AddConnection(lfFoot);
        valuePairs.Add(lForearm.Name + lfFoot.Name, 1.0);
        node_list.Add(lfFoot);

        GraphNode sacrum = new GraphNode("sacrum");
        lSpine.AddConnection(sacrum);
        valuePairs.Add(lSpine.Name + sacrum.Name, 1.0);
        node_list.Add(sacrum);

        GraphNode pelvis = new GraphNode("pelvis");
        sacrum.AddConnection(pelvis);
        valuePairs.Add(sacrum.Name + pelvis.Name, 1.0);
        node_list.Add(pelvis);

        GraphNode tail = new GraphNode("tail");
        sacrum.AddConnection(tail);
        valuePairs.Add(sacrum.Name + tail.Name, 1.0);
        node_list.Add(tail);

        GraphNode rFemur = new GraphNode("femur r");
        pelvis.AddConnection(rFemur);
        valuePairs.Add(pelvis.Name + rFemur.Name, 1.0);
        node_list.Add(rFemur);

        GraphNode rCalf = new GraphNode("calf r");
        rFemur.AddConnection(rCalf);
        valuePairs.Add(rFemur.Name + rCalf.Name, 1.0);
        node_list.Add(rCalf);

        GraphNode rbFoot = new GraphNode("foot rb");
        rCalf.AddConnection(rbFoot);
        valuePairs.Add(rCalf.Name + rbFoot.Name, 1.0);
        node_list.Add(rbFoot);

        GraphNode lFemur = new GraphNode("femur l");
        pelvis.AddConnection(lFemur);
        valuePairs.Add(pelvis.Name + lFemur.Name, 1.0);
        node_list.Add(lFemur);

        GraphNode lCalf = new GraphNode("calf l");
        lFemur.AddConnection(lCalf);
        valuePairs.Add(lFemur.Name + lCalf.Name, 1.0);
        node_list.Add(lCalf);

        GraphNode lbFoot = new GraphNode("foot lb");
        lCalf.AddConnection(lbFoot);
        valuePairs.Add(lCalf.Name + lbFoot.Name, 1.0);
        node_list.Add(lbFoot);
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
                    child.GetComponent<MeshRenderer>().material = based;
                }
                catch (Exception e)
                {
                    foreach (Transform children in child)
                    {
                        children.GetComponent<MeshRenderer>().material = based;
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
        foreach (GraphNode node in node_list)
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
        void djk(GraphNode anchor)
        {
            foreach (GraphNode child in anchor.Children)
            {
                try
                {
                    if (shortestdistance.ContainsKey(child.Name))
                    {
                        if (shortestdistance[child.Name] > (valuePairs[anchor.Name + child.Name] + shortestdistance[anchor.Name]))
                        {
                            shortestdistance[child.Name] = (valuePairs[anchor.Name + child.Name] + shortestdistance[anchor.Name]);
                        }
                    }
                    else
                    {
                        shortestdistance.Add(child.Name, valuePairs[anchor.Name + child.Name] + shortestdistance[anchor.Name]);
                        prevNode.Add(child.Name, anchor.Name);
                        djk(child);
                    }
                }
                catch (KeyNotFoundException e)
                {
                    if (shortestdistance.ContainsKey(child.Name))
                    {
                        if (shortestdistance[child.Name] > (valuePairs[child.Name + anchor.Name] + shortestdistance[anchor.Name]))
                        {
                            shortestdistance[child.Name] = (valuePairs[child.Name + anchor.Name] + shortestdistance[anchor.Name]);
                        }
                    }
                    else
                    {
                        shortestdistance.Add(child.Name, valuePairs[child.Name + anchor.Name] + shortestdistance[anchor.Name]);
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
                try
                {
                    if (shortestdistance[guess.Name] <= 1.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material = closest;
                    }
                    else if (shortestdistance[guess.Name] > 1.5 && shortestdistance[guess.Name] <= 2.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material = closer;
                    }
                    else if (shortestdistance[guess.Name] > 2.5 && shortestdistance[guess.Name] <= 3.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material = close;
                    }
                    else if (shortestdistance[guess.Name] > 3.5 && shortestdistance[guess.Name] <= 4.5)
                    {
                        skeleB.GetComponent<MeshRenderer>().material = far;
                    }
                    else if (shortestdistance[guess.Name] > 4.5 && shortestdistance[guess.Name] <= 6)
                    {
                        skeleB.GetComponent<MeshRenderer>().material = farther;
                    }
                    else if (shortestdistance[guess.Name] > 6)
                    {
                        skeleB.GetComponent<MeshRenderer>().material = farthest;
                    }
                }
                catch (Exception e)
                {
                    for (int i = 0; i < skeleB.transform.childCount; i++)
                    {
                        skeleA = skeleB.transform.GetChild(i);
                        if (shortestdistance[guess.Name] <= 1.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material = closest;
                        }
                        else if (shortestdistance[guess.Name] > 1.5 && shortestdistance[guess.Name] <= 2.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material = closer;
                        }
                        else if (shortestdistance[guess.Name] > 2.5 && shortestdistance[guess.Name] <= 3.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material = close;
                        }
                        else if (shortestdistance[guess.Name] > 3.5 && shortestdistance[guess.Name] <= 4.5)
                        {
                            skeleA.GetComponent<MeshRenderer>().material = far;
                        }
                        else if (shortestdistance[guess.Name] > 4.5 && shortestdistance[guess.Name] <= 6)
                        {
                            skeleA.GetComponent<MeshRenderer>().material = farther;
                        }
                        else if (shortestdistance[guess.Name] > 6)
                        {
                            skeleA.GetComponent<MeshRenderer>().material = farthest;
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
