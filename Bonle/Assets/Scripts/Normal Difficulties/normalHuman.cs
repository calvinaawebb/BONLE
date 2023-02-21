using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class normalHuman : graphClass
{
    void Start()
    {
        GraphNode cranium = new GraphNode("cranium");
        node_list.Add(cranium);

        GraphNode mandible = new GraphNode("mandible");
        cranium.AddConnection(mandible);
        valuePairs.Add(cranium.Name + mandible.Name, 1.0);
        node_list.Add(mandible);

        GraphNode uSpine = new GraphNode("spine");
        cranium.AddConnection(uSpine);
        valuePairs.Add(cranium.Name + uSpine.Name, 1.0);
        node_list.Add(uSpine);

        GraphNode lSpine = new GraphNode("spine l");
        uSpine.AddConnection(lSpine);
        valuePairs.Add(uSpine.Name + lSpine.Name, 1.0);
        node_list.Add(lSpine);

        GraphNode ribcage = new GraphNode("ribcage");
        uSpine.AddConnection(ribcage);
        valuePairs.Add(uSpine.Name + ribcage.Name, 1.0);
        node_list.Add(ribcage);

        GraphNode sternum = new GraphNode("sternum");
        ribcage.AddConnection(sternum);
        valuePairs.Add(ribcage.Name + sternum.Name, 1.0);
        node_list.Add(sternum);

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

        GraphNode rUlna = new GraphNode("ulna r");
        rHumerus.AddConnection(rUlna);
        valuePairs.Add(rHumerus.Name + rUlna.Name, 1.0);
        node_list.Add(rUlna);

        GraphNode rRadius = new GraphNode("radius r");
        rHumerus.AddConnection(rRadius);
        valuePairs.Add(rHumerus.Name + rRadius.Name, 1.0);
        node_list.Add(rRadius);

        GraphNode rHand = new GraphNode("hand r");
        rUlna.AddConnection(rHand);
        valuePairs.Add(rUlna.Name + rHand.Name, 1.0);
        rRadius.AddConnection(rHand);
        valuePairs.Add(rRadius.Name + rHand.Name, 1.0);
        node_list.Add(rHand);

        GraphNode lHumerus = new GraphNode("humerus l");
        lScapula.AddConnection(lHumerus);
        valuePairs.Add(lScapula.Name + lHumerus.Name, 1.0);
        node_list.Add(lHumerus);

        GraphNode lUlna = new GraphNode("ulna l");
        lHumerus.AddConnection(lUlna);
        valuePairs.Add(lHumerus.Name + lUlna.Name, 1.0);
        node_list.Add(lUlna);

        GraphNode lRadius = new GraphNode("radius l");
        lHumerus.AddConnection(lRadius);
        valuePairs.Add(lHumerus.Name + lRadius.Name, 1.0);
        node_list.Add(lRadius);

        GraphNode lHand = new GraphNode("hand l");
        lUlna.AddConnection(lHand);
        valuePairs.Add(lUlna.Name + lHand.Name, 1.0);
        lRadius.AddConnection(lHand);
        valuePairs.Add(lRadius.Name + lHand.Name, 1.0);
        node_list.Add(lHand);

        GraphNode sacrum = new GraphNode("sacrum");
        lSpine.AddConnection(sacrum);
        valuePairs.Add(lSpine.Name + sacrum.Name, 1.0);
        node_list.Add(sacrum);

        GraphNode pelvis = new GraphNode("pelvis");
        sacrum.AddConnection(pelvis);
        valuePairs.Add(sacrum.Name + pelvis.Name, 1.0);
        node_list.Add(pelvis);

        GraphNode rFemur = new GraphNode("femur r");
        pelvis.AddConnection(rFemur);
        valuePairs.Add(pelvis.Name + rFemur.Name, 1.0);
        node_list.Add(rFemur);

        GraphNode rTibia = new GraphNode("tibia r");
        rFemur.AddConnection(rTibia);
        valuePairs.Add(rFemur.Name + rTibia.Name, 1.0);
        node_list.Add(rTibia);

        GraphNode rFibula = new GraphNode("fibula r");
        rTibia.AddConnection(rFibula);
        valuePairs.Add(rTibia.Name + rFibula.Name, 1.0);
        node_list.Add(rFibula);

        GraphNode rFoot = new GraphNode("foot r");
        rTibia.AddConnection(rFoot);
        valuePairs.Add(rTibia.Name + rFoot.Name, 1.0);
        node_list.Add(rFoot);

        GraphNode lFemur = new GraphNode("femur l");
        pelvis.AddConnection(lFemur);
        valuePairs.Add(pelvis.Name + lFemur.Name, 1.0);
        node_list.Add(lFemur);

        GraphNode lTibia = new GraphNode("tibia l");
        lFemur.AddConnection(lTibia);
        valuePairs.Add(lFemur.Name + lTibia.Name, 1.0);
        node_list.Add(lTibia);

        GraphNode lFibula = new GraphNode("fibula l");
        lTibia.AddConnection(lFibula);
        valuePairs.Add(lTibia.Name + lFibula.Name, 1.0);
        node_list.Add(lFibula);

        GraphNode lFoot = new GraphNode("foot l");
        lTibia.AddConnection(lFoot);
        valuePairs.Add(lTibia.Name + lFoot.Name, 1.0);
        node_list.Add(lFoot);
    }
}

