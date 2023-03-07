using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class normalTrex : graphClass
{
    // Graph to be used by logic scripts later that denotes which bones touch which bones.
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

        GraphNode gastralia = new GraphNode("gastralia");
        ribcage.AddConnection(gastralia);
        valuePairs.Add(ribcage.Name + gastralia.Name, 1.0);
        node_list.Add(gastralia);

        GraphNode furcula = new GraphNode("furcula");
        ribcage.AddConnection(furcula);
        valuePairs.Add(ribcage.Name + furcula.Name, 1.0);
        node_list.Add(furcula);

        GraphNode rScapula = new GraphNode("scapula r");
        ribcage.AddConnection(rScapula);
        valuePairs.Add(ribcage.Name + rScapula.Name, 1.0);
        furcula.AddConnection(rScapula);
        valuePairs.Add(furcula.Name + rScapula.Name, 1.0);
        node_list.Add(rScapula);

        GraphNode lScapula = new GraphNode("scapula l");
        ribcage.AddConnection(lScapula);
        valuePairs.Add(ribcage.Name + lScapula.Name, 1.0);
        furcula.AddConnection(lScapula);
        valuePairs.Add(furcula.Name + lScapula.Name, 1.0);
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

        GraphNode rClaw = new GraphNode("claw r");
        rUlna.AddConnection(rClaw);
        valuePairs.Add(rUlna.Name + rClaw.Name, 1.0);
        rRadius.AddConnection(rClaw);
        valuePairs.Add(rRadius.Name + rClaw.Name, 1.0);
        node_list.Add(rClaw);

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

        GraphNode lClaw = new GraphNode("claw l");
        lUlna.AddConnection(lClaw);
        valuePairs.Add(lUlna.Name + lClaw.Name, 1.0);
        lRadius.AddConnection(lClaw);
        valuePairs.Add(lRadius.Name + lClaw.Name, 1.0);
        node_list.Add(lClaw);

        GraphNode sacrum = new GraphNode("sacrum");
        lSpine.AddConnection(sacrum);
        valuePairs.Add(lSpine.Name + sacrum.Name, 1.0);
        node_list.Add(sacrum);

        GraphNode tail = new GraphNode("tail");
        sacrum.AddConnection(tail);
        valuePairs.Add(sacrum.Name + tail.Name, 1.0);
        node_list.Add(tail);

        GraphNode ilium = new GraphNode("ilium");
        sacrum.AddConnection(ilium);
        valuePairs.Add(sacrum.Name + ilium.Name, 1.0);
        node_list.Add(ilium);

        GraphNode pubis = new GraphNode("pubis");
        sacrum.AddConnection(pubis);
        valuePairs.Add(sacrum.Name + pubis.Name, 1.0);
        ilium.AddConnection(pubis);
        valuePairs.Add(ilium.Name + pubis.Name, 1.0);
        node_list.Add(pubis);

        GraphNode ischium = new GraphNode("ischium");
        sacrum.AddConnection(ischium);
        valuePairs.Add(sacrum.Name + ischium.Name, 1.0);
        ilium.AddConnection(ischium);
        valuePairs.Add(ilium.Name + ischium.Name, 1.0);
        pubis.AddConnection(ischium);
        valuePairs.Add(pubis.Name + ischium.Name, 1.0);
        node_list.Add(ischium);

        GraphNode rFemur = new GraphNode("femur r");
        sacrum.AddConnection(rFemur);
        valuePairs.Add(sacrum.Name + rFemur.Name, 1.0);
        ilium.AddConnection(rFemur);
        valuePairs.Add(ilium.Name + rFemur.Name, 1.0);
        pubis.AddConnection(rFemur);
        valuePairs.Add(pubis.Name + rFemur.Name, 1.0);
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
        sacrum.AddConnection(lFemur);
        valuePairs.Add(sacrum.Name + lFemur.Name, 1.0);
        ilium.AddConnection(lFemur);
        valuePairs.Add(ilium.Name + lFemur.Name, 1.0);
        pubis.AddConnection(lFemur);
        valuePairs.Add(pubis.Name + lFemur.Name, 1.0);
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