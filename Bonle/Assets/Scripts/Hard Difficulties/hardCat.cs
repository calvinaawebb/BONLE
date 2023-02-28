using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class hardCat : graphClass
{
    void Start()
    {
        GraphNode cranium = new GraphNode("cranium");
        node_list.Add(cranium);

        GraphNode mandible = new GraphNode("mandible");
        cranium.AddConnection(mandible);
        valuePairs.Add(cranium.Name + mandible.Name, 1.0);
        node_list.Add(mandible);

        GraphNode cervicalVertebrae = new GraphNode("cervical vertebrae");
        cranium.AddConnection(cervicalVertebrae);
        valuePairs.Add(cranium.Name + cervicalVertebrae.Name, 1.0);
        node_list.Add(cervicalVertebrae);

        GraphNode thoracicVertebrae = new GraphNode("thoracic vertebrae");
        cervicalVertebrae.AddConnection(thoracicVertebrae);
        valuePairs.Add(cervicalVertebrae.Name + thoracicVertebrae.Name, 1.0);
        node_list.Add(thoracicVertebrae);

        GraphNode lumbarVertebrae = new GraphNode("lumbar vertebrae");
        thoracicVertebrae.AddConnection(lumbarVertebrae);
        valuePairs.Add(thoracicVertebrae.Name + lumbarVertebrae.Name, 1.0);
        node_list.Add(lumbarVertebrae);

        GraphNode ribcage = new GraphNode("ribcage");
        thoracicVertebrae.AddConnection(ribcage);
        valuePairs.Add(thoracicVertebrae.Name + ribcage.Name, 1.0);
        node_list.Add(ribcage);

        GraphNode xiphisternum = new GraphNode("xiphisternum");
        ribcage.AddConnection(xiphisternum);
        valuePairs.Add(ribcage.Name + xiphisternum.Name, 1.0);
        node_list.Add(xiphisternum);

        GraphNode rScapula = new GraphNode("scapula r");
        ribcage.AddConnection(rScapula);
        valuePairs.Add(ribcage.Name + rScapula.Name, 1.0);
        node_list.Add(rScapula);

        GraphNode lScapula = new GraphNode("scapula l");
        ribcage.AddConnection(lScapula);
        valuePairs.Add(ribcage.Name + lScapula.Name, 1.0);
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

        GraphNode rCarpals = new GraphNode("carpals r");
        rUlna.AddConnection(rCarpals);
        valuePairs.Add(rUlna.Name + rCarpals.Name, 1.0);
        rRadius.AddConnection(rCarpals);
        valuePairs.Add(rRadius.Name + rCarpals.Name, 1.0);
        node_list.Add(rCarpals);

        GraphNode rMetacarpals = new GraphNode("metacarpals r");
        rCarpals.AddConnection(rMetacarpals);
        valuePairs.Add(rCarpals.Name + rMetacarpals.Name, 1.0);
        node_list.Add(rMetacarpals);

        GraphNode rManualPhalanges = new GraphNode("manual phalanges r");
        rMetacarpals.AddConnection(rManualPhalanges);
        valuePairs.Add(rMetacarpals.Name + rManualPhalanges.Name, 1.0);
        node_list.Add(rManualPhalanges);

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

        GraphNode lCarpals = new GraphNode("carpals l");
        lUlna.AddConnection(lCarpals);
        valuePairs.Add(lUlna.Name + lCarpals.Name, 1.0);
        lRadius.AddConnection(lCarpals);
        valuePairs.Add(lRadius.Name + lCarpals.Name, 1.0);
        node_list.Add(lCarpals);

        GraphNode lMetacarpals = new GraphNode("metacarpals l");
        lCarpals.AddConnection(lMetacarpals);
        valuePairs.Add(lCarpals.Name + lMetacarpals.Name, 1.0);
        node_list.Add(lMetacarpals);

        GraphNode lManualPhalanges = new GraphNode("manual phalanges l");
        lMetacarpals.AddConnection(lManualPhalanges);
        valuePairs.Add(lMetacarpals.Name + lManualPhalanges.Name, 1.0);
        node_list.Add(lManualPhalanges);

        GraphNode sacrum = new GraphNode("sacrum");
        lumbarVertebrae.AddConnection(sacrum);
        valuePairs.Add(lumbarVertebrae.Name + sacrum.Name, 1.0);
        node_list.Add(sacrum);

        GraphNode pelvis = new GraphNode("pelvis");
        sacrum.AddConnection(pelvis);
        valuePairs.Add(sacrum.Name + pelvis.Name, 1.0);
        node_list.Add(pelvis);

        GraphNode caudalVertebrae = new GraphNode("caudal vertebrae");
        sacrum.AddConnection(caudalVertebrae);
        valuePairs.Add(sacrum.Name + caudalVertebrae.Name, 1.0);
        node_list.Add(caudalVertebrae);

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

        GraphNode rTarsals = new GraphNode("tarsals r");
        rTibia.AddConnection(rTarsals);
        valuePairs.Add(rTibia.Name + rTarsals.Name, 1.0);
        node_list.Add(rTarsals);

        GraphNode rMetatarsals = new GraphNode("metatarsals r");
        rTarsals.AddConnection(rMetatarsals);
        valuePairs.Add(rTarsals.Name + rMetatarsals.Name, 1.0);
        node_list.Add(rMetatarsals);

        GraphNode rPedalPhalanges = new GraphNode("pedal phalanges r");
        rMetatarsals.AddConnection(rPedalPhalanges);
        valuePairs.Add(rMetatarsals.Name + rPedalPhalanges.Name, 1.0);
        node_list.Add(rPedalPhalanges);

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

        GraphNode lTarsals = new GraphNode("tarsals l");
        lTibia.AddConnection(lTarsals);
        valuePairs.Add(lTibia.Name + lTarsals.Name, 1.0);
        node_list.Add(lTarsals);

        GraphNode lMetatarsals = new GraphNode("metatarsals l");
        lTarsals.AddConnection(lMetatarsals);
        valuePairs.Add(lTarsals.Name + lMetatarsals.Name, 1.0);
        node_list.Add(lMetatarsals);

        GraphNode lPedalPhalanges = new GraphNode("pedal phalanges l");
        lMetatarsals.AddConnection(lPedalPhalanges);
        valuePairs.Add(lMetatarsals.Name + lPedalPhalanges.Name, 1.0);
        node_list.Add(lPedalPhalanges);
    }
}

