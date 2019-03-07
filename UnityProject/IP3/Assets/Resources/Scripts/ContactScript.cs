using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactScript : MonoBehaviour {

    public Stats statsScript;
    InteractionScript interactionScript;

    public string[] names;

    string planet;
    string cName;

    public float[] dec = new float[8];
    public float[] app = new float[8];


    int amount;

    void Awake()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        interactionScript = GameObject.Find("PlayerController").GetComponent<InteractionScript>();

        interactionScript.contactScript = this;

        amount = statsScript.statNames.Length;

        names = new string[amount];

        Debug.Log(amount);
        
        for (int i = 0; i < amount; i++)
        {
            names[i] = statsScript.statNames[i];
        }
    }

    public void UpdateContact(/*string conName,*/ List<string> changedStats, List<float> approved, List<float> declined, string plan)
    {
        int k = 0;

        Debug.Log(amount);
        Debug.Log(approved[0]);
        Debug.Log(declined[0]);

        planet = plan;

        //cName = conName;

        for (int i = 0; i < amount; i++)
        {
            Debug.Log(i);


            foreach (string name in changedStats)
            {
                Debug.Log(name);

                if (name == names[i])
                {
                    app[i] = approved[k];
                    dec[i] = declined[k];

                    k++;
                }
            }
        }
    }

    public void Enact()
    {
        statsScript.conPlanet = planet;        
        
        //statsScript.contactNames.Add(cName);
        statsScript.contactPlanets.Add(planet);

        for(int i = 0; i < app.Length; i++)
        {
            statsScript.contactApprove[i] += app[i];
            statsScript.contactDecline[i] += dec[i];
        }
    }
}
