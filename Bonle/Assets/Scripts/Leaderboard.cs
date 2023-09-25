using System.Collections;
using System;
using System.IO;
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
    public ArrayList types2 = new ArrayList();
    public ArrayList types1 = new ArrayList();
    public String[] temp;
    public String[] temp2;
    Dictionary<string, int> temp3 = new Dictionary<string, int>();
    string filePath = "C:\\Users\\fluxc\\OneDrive\\Documents\\B.O.N.L.E\\Bonle\\Assets\\Scripts\\Scores.txt";
    // public TextWriter scoreW = new StreamWriter("Scores.txt");
    // public TextWriter namesW = new StreamWriter("Usernames.txt");
    // public TextWriter gamemodesW = new StreamWriter("Gamemodes.txt");x

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Here2");
        if (new FileInfo(filePath).Length != 0)
        {
            string[] temp2 = System.IO.File.ReadAllLines(filePath);
            foreach (string line in temp2)
            {
                string trimmedLine = line.Trim('[', ']');
                string[] parts = trimmedLine.Split(' ');
                string key = parts[0];
                int value = int.Parse(parts[1]);
                temp3[key] = value;
            }
            scores = colorize.scoresc;
            //temp3.ToList().ForEach(x => scores.Add(x.Key, x.Value));
            temp3.ToList();
            foreach (var x in temp3) 
            {
                try 
                {
                    scores.Add(x.Key, x.Value);
                } catch (Exception e) 
                {
                    if (x.Value > scores[x.Key]) 
                    {
                        scores[x.Key] = x.Value;
                    }
                }
            }
        } else
        {
            scores = colorize.scoresc;
        }
        var sortedDict = scores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        outScore.text = "";
        outName.text = "";
        outBone.text = "";
        Debug.Log("Here1");
        System.IO.File.WriteAllText("Scores.txt", String.Empty);
        System.IO.File.WriteAllLines(filePath, sortedDict.Select(x => "[" + x.Key + " " + x.Value + "]").ToArray());
        for (int i = 0; i < 10; i++)
        {
            temp = sortedDict.ElementAt(i).Key.Split(':');
            types1.Add(temp[0]);
            types2.Add(temp[1]);
            outScore.text = outScore.text + "\n" + "Score: " + sortedDict.ElementAt(i).Value;
            outName.text = outName.text + "\n" + (i+1) + ". " + types1[i];
            outBone.text = outBone.text + "\n" + "Mode: " + types2[i];
        }
        Debug.Log("Here");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
