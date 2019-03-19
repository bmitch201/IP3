using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public int day;
    public int time;
    public float[] statistics = new float[8];

    public void Load()
    {
        PlayerData data = SaveLoad.LoadPlayer();

        day = data.day;
        time = data.time;

        statistics[0] = data.statistics[0];
        statistics[1] = data.statistics[1];
        statistics[2] = data.statistics[2];
        statistics[3] = data.statistics[3];
        statistics[4] = data.statistics[4];
        statistics[5] = data.statistics[5];
        statistics[6] = data.statistics[6];
        statistics[7] = data.statistics[7];

        DontDestroyOnLoad(this);

        SceneManager.LoadScene("Actual Game");
    }
}
