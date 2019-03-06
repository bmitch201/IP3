using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactScript : MonoBehaviour {

    Stats statsScript;

    public string[] names;
    public float[] approve;
    public float[] decline;

    int amount;

    void Start()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();

        amount = statsScript.statNames.Length;

        names = new string[amount];
        approve = new float[amount];
        decline = new float[amount];

        for (int i = 0; i < amount; i++)
        {
            names[i] = statsScript.statNames[i];
        }
    }
	
	public void UpdatePolicy(List<string> changedStats, List<float> approved, List<float> declined)
    {
        int k = 0;

        for(int i = 0; i < amount; i++)
        {
            foreach(string name in changedStats)
            {
                if(name == names[i])
                {
                    approve[i] = approved[k];
                    decline[i] = declined[k];

                    k++;
                }
            }
        }
    }
}
