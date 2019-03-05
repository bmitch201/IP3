using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    public GameObject player, canvas, homePage, statsPage, ocPage, currentPage, lastPage, backButton;

    bool firstPCUse = true;

    InteractionScript interactionScript;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    Stats statsScript;

    void Start()
    {

        interactionScript = GameObject.Find("PlayerController").GetComponentInParent<InteractionScript>();
        dayOneScript = GameObject.Find("PlayerController").GetComponent<DayOneScript>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
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

            backButton.SetActive(false);
        }
    }

    void Update ()
    {
        //if the player hits F then activate the player and deactivate the PC camera/screen
		if(Input.GetKeyDown(KeyCode.F))
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
        }
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

        lastPage = homePage;

        currentPage.SetActive(false);
    }

    public void Back()
    {
        currentPage.SetActive(false);

        currentPage = lastPage;

        currentPage.SetActive(true);
    }
}
