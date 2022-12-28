using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class guessBone : MonoBehaviour
{
    public InputField input;
    public Transform skeleB;
    public GameObject bone;
    public GameObject tBone;
    public Transform randB;
    public GameObject skeleton;
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

    void Start()
    {
        num = UnityEngine.Random.Range(0, skeleton.transform.childCount);
        GraphNode head = new GraphNode("skull");
        node_list.Add(head);
        
        GraphNode uSpine = new GraphNode("upper spine");
        head.AddConnection(uSpine);
        valuePairs.Add(head.Name + uSpine.Name, 1.0);
        node_list.Add(uSpine);

        GraphNode lSpine = new GraphNode("lower spine");
        uSpine.AddConnection(lSpine);
        valuePairs.Add(uSpine.Name + lSpine.Name, 5.0);
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
        valuePairs.Add(rScapula.Name + rHumerus.Name, 3.0);
        node_list.Add(rHumerus); 

        GraphNode rForearm = new GraphNode("forearm r");
        rHumerus.AddConnection(rForearm);
        valuePairs.Add(rHumerus.Name + rForearm.Name, 2.0);
        node_list.Add(rForearm);

        GraphNode rHand = new GraphNode("hand r");
        rForearm.AddConnection(rHand);
        valuePairs.Add(rForearm.Name + rHand.Name, 1.5);
        node_list.Add(rHand);

        GraphNode lHumerus = new GraphNode("humerus l");
        lScapula.AddConnection(lHumerus);
        valuePairs.Add(lScapula.Name + lHumerus.Name, 3.0);
        node_list.Add(lHumerus);

        GraphNode lForearm = new GraphNode("forearm l");
        lHumerus.AddConnection(lForearm);
        valuePairs.Add(lHumerus.Name + lForearm.Name, 2.0);
        node_list.Add(lForearm);

        GraphNode lHand = new GraphNode("hand l");
        lForearm.AddConnection(lHand);
        valuePairs.Add(lForearm.Name + lHand.Name, 1.5);
        node_list.Add(lHand);

        GraphNode pelvis = new GraphNode("pelvis");
        lSpine.AddConnection(pelvis);
        valuePairs.Add(lSpine.Name + pelvis.Name, 1.0);
        node_list.Add(pelvis);

        GraphNode rFemur = new GraphNode("femur r");
        pelvis.AddConnection(rFemur);
        valuePairs.Add(pelvis.Name + rFemur.Name, 4.0);
        node_list.Add(rFemur);

        GraphNode rCalf = new GraphNode("calf r");
        rFemur.AddConnection(rCalf);
        valuePairs.Add(rFemur.Name + rCalf.Name, 3.0);
        node_list.Add(rCalf);

        GraphNode rFoot = new GraphNode("foot r");
        rCalf.AddConnection(rFoot);
        valuePairs.Add(rCalf.Name + rFoot.Name, 2.0);
        node_list.Add(rFoot);

        GraphNode lFemur = new GraphNode("femur l");
        pelvis.AddConnection(lFemur);
        valuePairs.Add(pelvis.Name + lFemur.Name, 4.0);
        node_list.Add(lFemur);

        GraphNode lCalf = new GraphNode("calf l");
        lFemur.AddConnection(lCalf);
        valuePairs.Add(lFemur.Name + lCalf.Name, 3.0);
        node_list.Add(lCalf);

        GraphNode lFoot = new GraphNode("foot l");
        lCalf.AddConnection(lFoot);
        valuePairs.Add(lCalf.Name + lFoot.Name, 2.0);
        node_list.Add(lFoot);
    }

    public void activate()
    {
        bone = GameObject.Find(input.text);
        Debug.Log("bone: " + bone.name.ToLower());
        randB = skeleton.transform.GetChild(num);
        tBone = GameObject.Find(randB.name);
        skeleB = skeleton.transform.Find(bone.name.ToLower());
        Debug.Log("Skeleb: " + skeleB.name);
        Debug.Log("target: " + tBone.name.ToLower());
        foreach (GraphNode node in node_list)
        {
            Debug.Log("currN: " + node.Name);
            if (node.Name == bone.name.ToLower()) {
                guess = node;
                Debug.Log("guess: " + guess.Name);
            } else if (node.Name == tBone.name.ToLower()) {
                target = node;
                Debug.Log("in: " + target.Name);
            }
        }
        Debug.Log("finished");
        void djk(GraphNode anchor) {
            foreach (GraphNode child in anchor.Children)
            {
                try {
                    if (shortestdistance.ContainsKey(child.Name))
                    {
                        if (shortestdistance[child.Name] < valuePairs[anchor.Name + child.Name])
                        {
                            shortestdistance.Remove(child.Name);
                            shortestdistance.Add(child.Name, valuePairs[anchor.Name + child.Name]);
                        }
                    } else {
                        shortestdistance.Add(child.Name, valuePairs[anchor.Name + child.Name]);
                        prevNode.Add(child.Name, anchor.Name);
                        djk(child);
                    }
                }
                catch (KeyNotFoundException e) {
                    if (shortestdistance.ContainsKey(child.Name))
                    {
                        if (shortestdistance[child.Name] < valuePairs[child.Name + anchor.Name])
                        {
                            shortestdistance.Remove(child.Name);
                            shortestdistance.Add(child.Name, valuePairs[child.Name + anchor.Name]);
                        }
                    }
                    else
                    {
                        shortestdistance.Add(child.Name, valuePairs[child.Name + anchor.Name]);
                        prevNode.Add(child.Name, anchor.Name);
                        djk(child);
                    }
                }
            }
        }
        djk(target);
        
        if (guess.Name != null)
        {
            Debug.Log(bone);
            Debug.Log(tBone);
            Debug.Log("so its a prob: " + skeleton.transform.childCount);
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
        }
        else
        {
            Debug.Log("Not a valid bone");
        }

        /*
        bone = GameObject.Find(input.text);
        randB = skeleton.transform.GetChild(num);
        tBone = GameObject.Find(randB.name);
        skeleB = skeleton.transform.Find(input.text);
        if (bone) {
            Debug.Log(bone);
            Debug.Log(tBone);
            Debug.Log(skeleton.transform.childCount);
            if (bone == tBone)
            {
                num = Random.Range(0, skeleton.transform.childCount);
                Main.enabled = false;
                GameOver.gameObject.SetActive(true);
            }
            else 
            {
                //Vector3 difference = new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
                //float distance = Math.Sqrt(Math.Pow(difference.x, 2f) + Math.Pow(difference.y, 2f) + Math.Pow(difference.z, 2f));
                float distance = Vector3.Distance(bone.transform.position, tBone.transform.position);
                Debug.Log(bone.transform.position);
                Debug.Log(distance);
                if (distance <= 4) {
                    skeleB.GetComponent<MeshRenderer>().material = closest;
                } else if (distance > 4 && distance <= 6) {
                    skeleB.GetComponent<MeshRenderer>().material = closer;
                } else if (distance > 6 && distance <= 9) {
                    skeleB.GetComponent<MeshRenderer>().material = close;
                } else if (distance > 9 && distance <= 12) {
                    skeleB.GetComponent<MeshRenderer>().material = far;
                } else if (distance > 12 && distance <= 15) {
                    skeleB.GetComponent<MeshRenderer>().material = farther;
                } else if (distance > 15) {
                    skeleB.GetComponent<MeshRenderer>().material = farthest;
                }
            }
        } else {
            Debug.Log("Not a valid bone");
        }
        */
    }
}
