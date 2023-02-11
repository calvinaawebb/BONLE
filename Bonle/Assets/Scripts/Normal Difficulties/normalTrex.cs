using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class normalTrex : graphClass
{
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

        GraphNode rForearm = new GraphNode("forearm r");
        rHumerus.AddConnection(rForearm);
        valuePairs.Add(rHumerus.Name + rForearm.Name, 1.0);
        node_list.Add(rForearm);

        GraphNode rClaw = new GraphNode("claw r");
        rForearm.AddConnection(rClaw);
        valuePairs.Add(rForearm.Name + rClaw.Name, 1.0);
        node_list.Add(rClaw);

        GraphNode lHumerus = new GraphNode("humerus l");
        lScapula.AddConnection(lHumerus);
        valuePairs.Add(lScapula.Name + lHumerus.Name, 1.0);
        node_list.Add(lHumerus);

        GraphNode lForearm = new GraphNode("forearm l");
        lHumerus.AddConnection(lForearm);
        valuePairs.Add(lHumerus.Name + lForearm.Name, 1.0);
        node_list.Add(lForearm);

        GraphNode lClaw = new GraphNode("claw l");
        lForearm.AddConnection(lClaw);
        valuePairs.Add(lForearm.Name + lClaw.Name, 1.0);
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

        GraphNode rCalf = new GraphNode("calf r");
        rFemur.AddConnection(rCalf);
        valuePairs.Add(rFemur.Name + rCalf.Name, 1.0);
        node_list.Add(rCalf);

        GraphNode rFoot = new GraphNode("foot r");
        rCalf.AddConnection(rFoot);
        valuePairs.Add(rCalf.Name + rFoot.Name, 1.0);
        node_list.Add(rFoot);

        GraphNode lFemur = new GraphNode("femur l");
        sacrum.AddConnection(lFemur);
        valuePairs.Add(sacrum.Name + lFemur.Name, 1.0);
        ilium.AddConnection(lFemur);
        valuePairs.Add(ilium.Name + lFemur.Name, 1.0);
        pubis.AddConnection(lFemur);
        valuePairs.Add(pubis.Name + lFemur.Name, 1.0);
        node_list.Add(lFemur);

        GraphNode lCalf = new GraphNode("calf l");
        lFemur.AddConnection(lCalf);
        valuePairs.Add(lFemur.Name + lCalf.Name, 1.0);
        node_list.Add(lCalf);

        GraphNode lFoot = new GraphNode("foot l");
        lCalf.AddConnection(lFoot);
        valuePairs.Add(lCalf.Name + lFoot.Name, 1.0);
        node_list.Add(lFoot);
    }
}