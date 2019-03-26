using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int day;
    public int time;
    public float[] statistics;
    public string[] text;

    public string[] policies;
    public string[] policyPlanet;

    public string[] contact;
    public string[] contactPlanet;

    public string[] phoneCallAccept;
    public string[] phoneCallDecline;

    public string[] conferenceCallAccept;
    public string[] conferenceCallDecline;

    public PlayerData (Stats stats)
    {
        day = stats.day;
        time = stats.time;

        statistics = new float[8];

        statistics[0] = stats.stats[0];
        statistics[1] = stats.stats[1];
        statistics[2] = stats.stats[2];
        statistics[3] = stats.stats[3];
        statistics[4] = stats.stats[4];
        statistics[5] = stats.stats[5];
        statistics[6] = stats.stats[6];
        statistics[7] = stats.stats[7];

        text = new string[9];

        text[0] = stats.hEText;
        text[1] = stats.tEText;
        text[2] = stats.wEText;
        text[3] = stats.hMText;
        text[4] = stats.tMText;
        text[5] = stats.wMText;
        text[6] = stats.hVText;
        text[7] = stats.tVText;
        text[8] = stats.wVText;

        policies = new string[stats.chosenPolicies.Count];

        for(int i = 0; i < stats.chosenPolicies.Count; i++)
        {
            policies[i] = stats.chosenPolicies[i];
        }

        policyPlanet = new string[stats.chosenPlanets.Count];

        for (int i = 0; i < stats.chosenPlanets.Count; i++)
        {
            policyPlanet[i] = stats.chosenPlanets[i];
        }

        contact = new string[stats.contactNames.Count];

        for (int i = 0; i < stats.contactNames.Count; i++)
        {
            contact[i] = stats.contactNames[i];
        }

        contactPlanet = new string[stats.contactPlanets.Count];

        for (int i = 0; i < stats.contactPlanets.Count; i++)
        {
            contactPlanet[i] = stats.contactPlanets[i];
        }

        phoneCallAccept = new string[stats.phonecallAccept.Count];

        for (int i = 0; i < stats.phonecallAccept.Count; i++)
        {
            phoneCallAccept[i] = stats.phonecallAccept[i];
        }

        phoneCallDecline = new string[stats.phonecallDecline.Count];

        for (int i = 0; i < stats.phonecallDecline.Count; i++)
        {
            phoneCallDecline[i] = stats.phonecallDecline[i];
        }

        conferenceCallAccept = new string[stats.connferenceCallAccept.Count];

        for (int i = 0; i < stats.connferenceCallAccept.Count; i++)
        {
            conferenceCallAccept[i] = stats.connferenceCallAccept[i];
        }

        conferenceCallDecline = new string[stats.connferenceCallDecline.Count];

        for (int i = 0; i < stats.connferenceCallDecline.Count; i++)
        {
            conferenceCallDecline[i] = stats.connferenceCallDecline[i];
        }
    }
}
