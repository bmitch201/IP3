using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    Stats stats;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Actual Game");
    }

    public void LoadGame()
    {
        PlayerData data = SaveLoad.LoadPlayer();

        stats.day = data.day;
        stats.time = data.time;

        stats.stats[0] = data.statistics[0];
        stats.stats[1] = data.statistics[1];
        stats.stats[2] = data.statistics[2];
        stats.stats[3] = data.statistics[3];
        stats.stats[4] = data.statistics[4];
        stats.stats[5] = data.statistics[5];
        stats.stats[6] = data.statistics[6];
        stats.stats[7] = data.statistics[7];

        SceneManager.LoadScene("Actual Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
