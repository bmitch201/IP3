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
        //loadingPanel.gameObject.SetActive(false);
    }

    public GameObject hightlight_NewGame;
    public GameObject hightlight_LoadGame;
    public GameObject hightlight_QuitGame;
    public GameObject hightlight_Options;

    public GameObject loadingPanel;
    //public Slider loadingSlider;
    //public Text perctenageText;

    public void StartGame()
    {
        loadingPanel.gameObject.SetActive(true);
        SceneManager.LoadScene("Actual Game");
        //StartCoroutine(LoadAsynchronously());
    }

    //IEnumerator LoadAsynchronously()
    //{

    //    AsyncOperation operation = SceneManager.LoadSceneAsync("Actual Game");

    //    while (!operation.isDone)
    //    {
    //        float progress = Mathf.Clamp01(operation.progress / 0.9f);
    //        Debug.Log(progress);
    //        loadingSlider.value = progress;
    //        perctenageText.text = progress * 100f + "%";
    //    }

    //    yield return null;
    //}

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

    void Update()
    {
        if (GameObject.Find("GameInfoObject") != null)
        {
            Destroy(GameObject.Find("GameInfoObject"));
            Destroy(GameObject.Find("Earth Folder"));
            Destroy(GameObject.Find("Mars Folder"));
            Destroy(GameObject.Find("Venus Folder"));
        }
    }
}
