using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public GameObject hightlight_NewGame;
    public GameObject hightlight_LoadGame;
    public GameObject hightlight_QuitGame;
    public GameObject hightlight_Options;

    public void StartGame()
    {
        SceneManager.LoadScene("Actual Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HighlightNewOn()
    {
        hightlight_NewGame.gameObject.SetActive(true);
    }

    public void HighlightNewOff()
    {
        hightlight_NewGame.gameObject.SetActive(false);
    }

    public void HighlightLoadOn()
    {
        hightlight_LoadGame.gameObject.SetActive(true);
    }

    public void HighlightLoadOff()
    {
        hightlight_LoadGame.gameObject.SetActive(false);
    }

    public void HighlightQuitOn()
    {
        hightlight_QuitGame.gameObject.SetActive(true);
    }

    public void HighlightQuitOff()
    {
        hightlight_QuitGame.gameObject.SetActive(false);
    }

    public void HighlightOptionsOn()
    {
        hightlight_Options.gameObject.SetActive(true);
    }

    public void HighlightOptionsOff()
    {
        hightlight_Options.gameObject.SetActive(false);
    }
}
