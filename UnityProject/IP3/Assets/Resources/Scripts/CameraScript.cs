using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    public GameObject player, chairCamera, canvas, homePage, statsPage, ocPage, currentPage, lastPage, backButton, ocHomePage, earthPage, marsPage, venusPage, moonCanvas, earthCanvas, marsCanvas, venusCanvas, es;
    GameObject prefab;

    bool firstPCUse = true;

    InteractionScript interactionScript;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    public Stats statsScript;

    List<string> statNames = new List<string>();
    List<float> statApprove = new List<float>();
    List<float> statDecline = new List<float>();

    string planet;

    void Start()
    {
        interactionScript = GameObject.Find("PlayerController").GetComponentInParent<InteractionScript>();
        dayOneScript = GameObject.Find("PlayerController").GetComponent<DayOneScript>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();

        earthCanvas = GameObject.Find("Earth Folder Canvas");
        marsCanvas = GameObject.Find("Mars Folder Canvas");
        venusCanvas = GameObject.Find("Venus Folder Canvas");

        statNames.Add("Autonomy");
        statNames.Add("Public_Support");
    }

    void Awake()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();

        es.SetActive(true);

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

        es.SetActive(true);

        //if the player hits F then activate the player and deactivate the PC camera/screen
        if (Input.GetKeyDown(KeyCode.F))
        {
            chairCamera.SetActive(true);
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


    #region Earth

    public void Earth()
    {
        currentPage.SetActive(false);

        currentPage = earthPage;

        lastPage = ocHomePage;

        currentPage.SetActive(true);
    }

    public void EarthChoice()
    {
        statApprove.Add(-5f);
        statApprove.Add(5f);

        statDecline.Add(5f);
        statApprove.Add(-5f);

        planet = "Earth";

        ReturnToPlayer();
    }

    #endregion

    #region Mars

    public void Mars()
    {
        currentPage.SetActive(false);

        currentPage = marsPage;

        lastPage = ocHomePage;

        currentPage.SetActive(true);
    }

    public void MarsChoice()
    {
        statApprove.Add(-5f);
        statApprove.Add(5f);

        statDecline.Add(5f);
        statApprove.Add(-5f);

        planet = "Mars";

        ReturnToPlayer();
    }

    #endregion

    #region Venus

    public void Venus()
    {
        currentPage.SetActive(false);

        currentPage = venusPage;

        lastPage = ocHomePage;

        currentPage.SetActive(true);
    }

    public void VenusChoice()
    {
        statApprove.Add(-5f);
        statApprove.Add(5f);

        statDecline.Add(5f);
        statApprove.Add(-5f);

        planet = "Venus";

        ReturnToPlayer();
    }

    #endregion

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

    void ReturnToPlayer()
    {
        //Gets the policy page prefab from the resources folder
        prefab = (GameObject)Resources.Load("Paper", typeof(GameObject));

        player.SetActive(true);

        player.GetComponentInParent<InteractionScript>().enabled = true;

        //Sets the current page active to false
        currentPage.SetActive(false);

        //Resets the current page to the front page and activates it
        lastPage = currentPage;
        currentPage = homePage;
        currentPage.SetActive(true);

        //Sets up the prefab to be spawned on the player
        interactionScript.prefab = Instantiate(prefab, interactionScript.spawnPos.transform.position, GameObject.Find("MainCamera").transform.rotation);
        interactionScript.prefab.transform.parent = GameObject.Find("SpawnPos").transform;
        interactionScript.holding = true;
        interactionScript.holdingContact = true;

        ContactScript conSc = interactionScript.prefab.GetComponent<ContactScript>();

        conSc.UpdateContact(statNames, statApprove, statDecline, planet);

        //Calls the folder and policy methods within the interaction script
        interactionScript.FolderOn();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        earthCanvas.SetActive(true);
        marsCanvas.SetActive(true);
        moonCanvas.SetActive(true);
        venusCanvas.SetActive(true);

        if (interactionScript.pcActive == true)
        {
            canvas.SetActive(true);
            interactionScript.pcActive = false;
        }

        statApprove.Clear();
        statDecline.Clear();

        gameObject.SetActive(false);
    }
}
