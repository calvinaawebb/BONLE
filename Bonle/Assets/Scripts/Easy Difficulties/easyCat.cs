using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class easyCat : graphClass
{
    // Graph to be used by logic scripts later that denotes which bones touch which bones.
    void Start()
    {
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
}

