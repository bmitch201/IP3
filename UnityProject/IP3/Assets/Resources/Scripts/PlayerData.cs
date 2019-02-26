using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int day;
    public int time;
    public float[] statistics;

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
    }
}
