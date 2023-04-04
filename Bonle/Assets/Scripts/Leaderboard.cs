using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Dictionary<string, int> scores = new Dictionary<string, int>();
    public Text outBoard;

    // Start is called before the first frame update
    void Start()
    {
        scores = colorize.scoresc;
        var sortedDict = scores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        for (int i=0;i>10;i++) 
        {
            outBoard.text = outBoard.text + "\n" + sortedDict.ElementAt(i).Key + sortedDict.ElementAt(i).Value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
