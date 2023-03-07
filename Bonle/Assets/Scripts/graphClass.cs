using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphClass : MonoBehaviour
{
    // Interface used as a super class for all graphs to minimize space and increase organization by having universal variables.
    public ArrayList node_list = new ArrayList();
    public Dictionary<string, double> valuePairs = new Dictionary<string, double>();
}
