using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GraphNode;

public class hardTrex : graphClass
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

        GraphNode dorsalVertebrae = new GraphNode("dorsal vertebrae");
        cervicalVertebrae.AddConnection(dorsalVertebrae);
        valuePairs.Add(cervicalVertebrae.Name + dorsalVertebrae.Name, 1.0);
        node_list.Add(dorsalVertebrae);

        GraphNode cervicalRibs = new GraphNode("cervical ribs");
        cervicalVertebrae.AddConnection(cervicalRibs);
        valuePairs.Add(cervicalVertebrae.Name + cervicalRibs.Name, 1.0);
        node_list.Add(cervicalRibs);

        GraphNode dorsalRibs = new GraphNode("cervical ribs");
        dorsalVertebrae.AddConnection(dorsalRibs);
        valuePairs.Add(dorsalVertebrae.Name + dorsalRibs.Name, 1.0);
        node_list.Add(dorsalRibs);

        GraphNode sternalPlate = new GraphNode("sternal plate");
        dorsalRibs.AddConnection(sternalPlate);
        valuePairs.Add(dorsalRibs.Name + sternalPlate.Name, 1.0);
        node_list.Add(sternalPlate);

        GraphNode gastralia = new GraphNode("gastralia");
        sternalPlate.AddConnection(gastralia);
        valuePairs.Add(sternalPlate.Name + gastralia.Name, 1.0);
        node_list.Add(gastralia);

        GraphNode furcula = new GraphNode("furcula");
        dorsalRibs.AddConnection(furcula);
        valuePairs.Add(dorsalRibs.Name + furcula.Name, 1.0);
        node_list.Add(furcula);

        GraphNode rScapula = new GraphNode("scapula r");
        dorsalRibs.AddConnection(rScapula);
        valuePairs.Add(dorsalRibs.Name + rScapula.Name, 1.0);
        furcula.AddConnection(rScapula);
        valuePairs.Add(furcula.Name + rScapula.Name, 1.0);
        node_list.Add(rScapula);

        GraphNode lScapula = new GraphNode("scapula l");
        dorsalRibs.AddConnection(lScapula);
        valuePairs.Add(dorsalRibs.Name + lScapula.Name, 1.0);
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

        GraphNode rMetacarpals = new GraphNode("metacarpals r");
        rUlna.AddConnection(rMetacarpals);
        valuePairs.Add(rUlna.Name + rMetacarpals.Name, 1.0);
        rRadius.AddConnection(rMetacarpals);
        valuePairs.Add(rRadius.Name + rMetacarpals.Name, 1.0);
        node_list.Add(rMetacarpals);

        GraphNode rManualPhalanges = new GraphNode("manaual phalanges r");
        rMetacarpals.AddConnection(rManualPhalanges);
        valuePairs.Add(rMetacarpals.Name + rManualPhalanges.Name, 1.0);
        node_list.Add(rManualPhalanges);

        GraphNode rManualUngual = new GraphNode("manual ungual r");
        rManualPhalanges.AddConnection(rManualUngual);
        valuePairs.Add(rManualPhalanges.Name + rManualUngual.Name, 1.0);
        node_list.Add(rManualUngual);

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

        GraphNode lMetacarpals = new GraphNode("metacarpals l");
        lUlna.AddConnection(lMetacarpals);
        valuePairs.Add(lUlna.Name + lMetacarpals.Name, 1.0);
        lRadius.AddConnection(lMetacarpals);
        valuePairs.Add(lRadius.Name + lMetacarpals.Name, 1.0);
        node_list.Add(lMetacarpals);

        GraphNode lManualPhalanges = new GraphNode("manaual phalanges l");
        lMetacarpals.AddConnection(lManualPhalanges);
        valuePairs.Add(lMetacarpals.Name + lManualPhalanges.Name, 1.0);
        node_list.Add(lManualPhalanges);

        GraphNode lManualUngual = new GraphNode("manual ungual l");
        lManualPhalanges.AddConnection(lManualUngual);
        valuePairs.Add(lManualPhalanges.Name + lManualUngual.Name, 1.0);
        node_list.Add(lManualUngual);

        GraphNode sacrum = new GraphNode("sacrum");
        dorsalVertebrae.AddConnection(sacrum);
        valuePairs.Add(dorsalVertebrae.Name + sacrum.Name, 1.0);
        node_list.Add(sacrum);

        GraphNode caudalVertebrae = new GraphNode("caudal vertebrae");
        sacrum.AddConnection(caudalVertebrae);
        valuePairs.Add(sacrum.Name + caudalVertebrae.Name, 1.0);
        node_list.Add(caudalVertebrae);

        GraphNode chevrons = new GraphNode("chevrons");
        caudalVertebrae.AddConnection(chevrons);
        valuePairs.Add(caudalVertebrae.Name + chevrons.Name, 1.0);
        node_list.Add(chevrons);

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

        GraphNode rMetatarsals = new GraphNode("metatarsals r");
        rTibia.AddConnection(rMetatarsals);
        valuePairs.Add(rTibia.Name + rMetatarsals.Name, 1.0);
        node_list.Add(rMetatarsals);

        GraphNode rPedalPhalanges = new GraphNode("pedal phalanges r");
        rMetatarsals.AddConnection(rPedalPhalanges);
        valuePairs.Add(rMetatarsals.Name + rPedalPhalanges.Name, 1.0);
        node_list.Add(rPedalPhalanges);

        GraphNode rPedalUngual = new GraphNode("pedal ungual r");
        rPedalPhalanges.AddConnection(rPedalUngual);
        valuePairs.Add(rPedalPhalanges.Name + rPedalUngual.Name, 1.0);
        node_list.Add(rPedalUngual);

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

        GraphNode lMetatarsals = new GraphNode("metatarsals l");
        lTibia.AddConnection(lMetatarsals);
        valuePairs.Add(lTibia.Name + lMetatarsals.Name, 1.0);
        node_list.Add(lMetatarsals);

        GraphNode lPedalPhalanges = new GraphNode("pedal phalanges l");
        lMetatarsals.AddConnection(lPedalPhalanges);
        valuePairs.Add(lMetatarsals.Name + lPedalPhalanges.Name, 1.0);
        node_list.Add(lPedalPhalanges);

        GraphNode lPedalUngual = new GraphNode("pedal ungual l");
        lPedalPhalanges.AddConnection(lPedalUngual);
        valuePairs.Add(lPedalPhalanges.Name + lPedalUngual.Name, 1.0);
        node_list.Add(lPedalUngual);
    }
}