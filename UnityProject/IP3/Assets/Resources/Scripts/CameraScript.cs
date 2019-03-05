using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    public GameObject player, canvas, homePage, statsPage, ocPage, currentPage, lastPage, backButton, ocHomePage, earthPage, marsPage, venusPage, moonCanvas, earthCanvas, marsCanvas, venusCanvas;

    bool firstPCUse = true;

    InteractionScript interactionScript;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    public Stats statsScript;

    void Start()
    {
        interactionScript = GameObject.Find("PlayerController").GetComponentInParent<InteractionScript>();
        dayOneScript = GameObject.Find("PlayerController").GetComponent<DayOneScript>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();

        earthCanvas = GameObject.Find("Earth Folder Canvas");
        marsCanvas = GameObject.Find("Mars Folder Canvas");
        venusCanvas = GameObject.Find("Venus Folder Canvas");
    }

    void Awake()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();

        statsScript.PCnames = GameObject.Find("Text_Name_PC").GetComponent<Text>();
        statsScript.PCnums = GameObject.Find("Text_Numbers_PC").GetComponent<Text>();

        homePage.SetActive(true);
        statsPage.SetActive(false);
        ocPage.SetActive(false);

        backButton.SetActive(true);

        currentPage = homePage;

        if (statsScript.day == 1)
        {
            homePage.SetActive(false);
            statsPage.SetActive(true);

            currentPage = statsPage;

            backButton.SetActive(false);
        }
    }

    void Update ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //if the player hits F then activate the player and deactivate the PC camera/screen
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.SetActive(true);
            gameObject.SetActive(false);
            dayOneScript.pcAudio.Stop();

            if (statsScript.day == 1 && firstPCUse == true)
            {
                robotDialogueTrigger.TriggerRobotDialogue4();
                firstPCUse = false;
                dayOneScript.pcActive = false;
            }

            if (statsScript.day == 1 && dayOneScript.pcIntractable == true)
            {
                canvas.SetActive(true);
                dayOneScript.Light();
            }

            if (interactionScript.pcActive == true)
            {
                canvas.SetActive(true);
                interactionScript.pcActive = false;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            earthCanvas.SetActive(true);
            marsCanvas.SetActive(true);
            moonCanvas.SetActive(true);
            venusCanvas.SetActive(true);
        }
	}

    public void CheckScript()
    {
        currentPage.SetActive(false);

        backButton.SetActive(true);

        homePage.SetActive(true);

        currentPage = homePage;

        earthCanvas = GameObject.Find("Earth Folder Canvas");
        marsCanvas = GameObject.Find("Mars Folder Canvas");
        venusCanvas = GameObject.Find("Venus Folder Canvas");
    }

    public void Stats()
    {
        currentPage.SetActive(false);

        currentPage = statsPage;

        lastPage = homePage;

        currentPage.SetActive(true);
    }

    public void OutboundContacts()
    {
        currentPage.SetActive(false);

        currentPage = ocPage;

        currentPage.SetActive(true);

        lastPage = homePage;

        ocHomePage.SetActive(true);
        earthPage.SetActive(false);
        marsPage.SetActive(false);
        venusPage.SetActive(false);

        currentPage = ocHomePage;
    }

    public void Earth()
    {
        currentPage.SetActive(false);

        currentPage = earthPage;

        lastPage = ocHomePage;

        currentPage.SetActive(true);
    }

    public void Mars()
    {
        currentPage.SetActive(false);

        currentPage = marsPage;

        lastPage = ocHomePage;

        currentPage.SetActive(true);
    }

    public void Venus()
    {
        currentPage.SetActive(false);

        currentPage = venusPage;

        lastPage = ocHomePage;

        currentPage.SetActive(true);
    }

    public void Back()
    {
        currentPage.SetActive(false);

        if (lastPage == ocHomePage)
        {
            currentPage = lastPage;
            lastPage = homePage;
        }
        else
        {
            currentPage = lastPage;
        }

        currentPage.SetActive(true);
    }
}
