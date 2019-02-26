using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyScript : MonoBehaviour
{
    Stats statsScript;
    public PolicyChoices policyChoicesScript;

    public string[] names;
    public float[] decreases;
    public float[] scrap;

    int amount;

    public string type;
    public int buttonAmount;

    public string movement = "";
    public string planet = "";

    void Awake()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        policyChoicesScript = GameObject.Find("GameInfoObject").GetComponent<PolicyChoices>();

        amount = statsScript.statNames.Length;

        names = new string[amount];
        decreases = new float[amount];
        scrap = new float[amount];

        for (int i = 0; i < amount; i++)
        {
            names[i] = statsScript.statNames[i];
        }
    }

    public void UpdatePolicy(List<float> changes, List<string> changedStats)
    {
        float[] statChanges = new float[changes.Capacity];
        int j = 0, k = 0;

        foreach (float stat in changes)
        {
            statChanges[j] = stat;
            j++;
        }

        for (int i = 0; i < amount; i++)
        {
            foreach (string name in changedStats)
            {
                if (name == names[i])
                {
                    decreases[i] = statChanges[k];
                }

                k++;
            }

            k = 0;
        }
    }

    public void UpdateBin(List<float> changes, List<string> changedStats)
    {
        float[] statChanges = new float[changes.Capacity];
        int j = 0, k = 0;

        foreach (float stat in changes)
        {
            statChanges[j] = stat;
            j++;
        }

        for (int i = 0; i < amount; i++)
        {
            foreach (string name in changedStats)
            {
                if (name == names[i])
                {
                    scrap[i] = statChanges[k];
                }

                k++;
            }

            k = 0;
        }
    }

}
