using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactScript : MonoBehaviour {

    Stats statsScript;
    InteractionScript interactionScript;
    public CameraScript cameraScript;

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
        
        for (int i = 0; i < amount; i++)
        {
            names[i] = statsScript.statNames[i];
        }
    }

    public void UpdateContact(string conName, List<string> changedStats, List<float> approved, List<float> declined, string plan)
    {
        int k = 0;

        planet = plan;

        cName = conName;

        for (int i = 0; i < amount; i++)
        {
            foreach (string name in changedStats)
            {
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
        statsScript.con = cName;
        
        statsScript.contactNames.Add(cName);
        statsScript.contactPlanets.Add(planet);

        cameraScript.DisableButton();

        for(int i = 0; i < app.Length; i++)
        {
            statsScript.contactApprove[i] = app[i];
            statsScript.contactDecline[i] = dec[i];
        }

        statsScript.Submitted();
    }
}
