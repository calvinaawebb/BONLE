using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Dictionary<string, int> scores = new Dictionary<string, int>();
    public Text outScore;
    public Text outBone;
    public Text outTime;
    public Text outName;

    // Start is called before the first frame update
    void Start()
    {
        scores = colorize.scoresc;
        var sortedDict = scores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        for (int i = 0; i < 10; i++)
        {
            outScore.text = outScore.text + "\n" + "Score: " + scores.ElementAt(i).Value;
            outName.text = outName.text + "\n" + (i+1) + ". " + scores.ElementAt(i).Key;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
