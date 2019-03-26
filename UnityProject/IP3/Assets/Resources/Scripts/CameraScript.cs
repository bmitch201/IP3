using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    public GameObject player, chairCamera, canvas, homePage, statsPage, ocPage, currentPage, lastPage, backButton, ocHomePage, earthPage, marsPage, venusPage, moonCanvas, earthCanvas, marsCanvas, venusCanvas, es;
    GameObject prefab;

    public bool firstPCUse;

    InteractionScript interactionScript;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    public Stats statsScript;

    public List<string> statNames = new List<string>();
    public List<float> statApprove = new List<float>();
    public List<float> statDecline = new List<float>();

    public Button[] earthButtons = new Button[3];
    public Button[] marsButtons = new Button[3];
    public Button[] venusButtons = new Button[3];
    public Button selected;

    string planet, contactName;
    public string buttonClicked;

    void Awake()
    {
        interactionScript = player.GetComponent<InteractionScript>();
        dayOneScript = player.GetComponent<DayOneScript>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();

        earthCanvas = GameObject.Find("Earth Folder Canvas");
        marsCanvas = GameObject.Find("Mars Folder Canvas");
        venusCanvas = GameObject.Find("Venus Folder Canvas");

        statNames.Add("Autonomy");
        statNames.Add("Public_Support");

        statsScript.PCnames = GameObject.Find("Text_Name_PC").GetComponent<Text>();
        statsScript.PCnums = GameObject.Find("Text_Numbers_PC").GetComponent<Text>();

        firstPCUse = true;

        es.SetActive(true);

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

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update ()
    {
        if(statsScript.day > 1 && firstPCUse == true)
        {
            homePage.SetActive(true);
            statsPage.SetActive(false);

            currentPage = homePage;

            backButton.SetActive(true);

            firstPCUse = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        es.SetActive(true);

        //if the player hits F then activate the player and deactivate the PC camera/screen
        if (Input.GetKeyDown(KeyCode.F))
        {
            chairCamera.SetActive(true);
            gameObject.SetActive(false);
            canvas.SetActive(true);
            dayOneScript.pcAudio.Stop();

            if (statsScript.day == 1 && firstPCUse == true)
            {
                robotDialogueTrigger.TriggerRobotDialogue4();
                firstPCUse = false;
                dayOneScript.pcActive = false;
            }

            if (statsScript.day == 1 && dayOneScript.pcIntractable == true)
            {
                dayOneScript.Light();
            }

            if (interactionScript.pcActive == true)
            {
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

        if (statsScript.healthEarth == null || statsScript.travelEarth == null || statsScript.workEarth == null)
        {
            statsScript.healthEarth = GameObject.Find("HEALTH_TEXT_EARTH").GetComponent<Text>();
            statsScript.travelEarth = GameObject.Find("TRAVEL_TEXT_EARTH").GetComponent<Text>();
            statsScript.workEarth = GameObject.Find("WORK_RIGHTS_EARTH").GetComponent<Text>();

            statsScript.UpdateScreen();
        }

        if (statsScript.healthMars == null || statsScript.travelMars == null || statsScript.workMars == null)
        {
            statsScript.healthMars = GameObject.Find("HEALTH_TEXT_MARS").GetComponent<Text>();
            statsScript.travelMars = GameObject.Find("TRAVEL_TEXT_MARS").GetComponent<Text>();
            statsScript.workMars = GameObject.Find("WORK_RIGHTS_MARS").GetComponent<Text>();

            statsScript.UpdateScreen();
        }

        if (statsScript.healthVenus == null || statsScript.travelVenus == null || statsScript.workVenus == null)
        {
            statsScript.healthVenus = GameObject.Find("HEALTH_TEXT_VENUS").GetComponent<Text>();
            statsScript.travelVenus = GameObject.Find("TRAVEL_TEXT_VENUS").GetComponent<Text>();
            statsScript.workVenus = GameObject.Find("WORK_RIGHTS_VENUS").GetComponent<Text>();

            statsScript.UpdateScreen();
        }

        if(statsScript.day == 2 && GameObject.Find("TRAVEL_EARTH") != null)
        {
            GameObject.Find("TRAVEL_EARTH").SetActive(false);
            GameObject.Find("WORKRIGHTS_EARTH").SetActive(false);
            GameObject.Find("WORK_RIGHTS_EARTH").SetActive(false);
            GameObject.Find("TRAVEL_TEXT_EARTH").SetActive(false);

            GameObject.Find("TRAVEL_MARS").SetActive(false);
            GameObject.Find("WORKRIGHTS_MARS").SetActive(false);
            GameObject.Find("WORK_RIGHTS_MARS").SetActive(false);
            GameObject.Find("TRAVEL_TEXT_MARS").SetActive(false);

            GameObject.Find("TRAVEL_VENUS").SetActive(false);
            GameObject.Find("WORKRIGHTS_VENUS").SetActive(false);
            GameObject.Find("TRAVEL_TEXT_VENUS").SetActive(false);
            GameObject.Find("WORK_RIGHTS_VENUS").SetActive(false);

            statsScript.UpdateScreen();
        }

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

    //If the earth page is open and button is clicked
    public void EarthChoice()
    {
        statApprove.Add(-5f);
        statApprove.Add(5f);

        statDecline.Add(5f);
        statDecline.Add(-5f);

        planet = "Earth";
        buttonClicked = "EARTH";
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

    //If the mars page is open and button is clicked
    public void MarsChoice()
    {
        statApprove.Add(-5f);
        statApprove.Add(5f);

        statDecline.Add(5f);
        statDecline.Add(-5f);

        planet = "Mars";
        buttonClicked = "MARS";
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

    //If the venus page is open and button is clicked
    public void VenusChoice()
    {
        statApprove.Add(-5f);
        statApprove.Add(5f);

        statDecline.Add(5f);
        statDecline.Add(-5f);

        planet = "Venus";
        buttonClicked = "VENUS";
    }

    #endregion

    //If the healthcare button is clicked
    public void Healthcare()
    {
        contactName = "Healthcare";
        buttonClicked = "HEALTHCARE_" + buttonClicked;
        
        ReturnToPlayer();
    }

    //if the travel button is clicked
    public void Travel()
    {
        contactName = "Travel";
        buttonClicked = "TRAVEL_" + buttonClicked;

        ReturnToPlayer();
    }

    //If the worker button is clicked
    public void Worker()
    {
        contactName = "Worker Rights";
        buttonClicked = "WORKRIGHTS_" + buttonClicked;

        ReturnToPlayer();
    }

    //When the back button is clicked the page is taken back to previous
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

    //Disables button after the paper has been submitted
    public void DisableButton()
    {
        if(planet == "Earth")
        {
            foreach(Button b in earthButtons)
            {
                if(b.name == buttonClicked)
                {
                    b.GetComponent<Button>().interactable = false;
                }
            }
        }
        else if (planet == "Mars")
        {
            foreach (Button b in marsButtons)
            {
                if (b.name == buttonClicked)
                {
                    b.GetComponent<Button>().interactable = false;
                }
            }
        }
        else if (planet == "Venus")
        {
            foreach (Button b in venusButtons)
            {
                if (b.name == buttonClicked)
                {
                    b.GetComponent<Button>().interactable = false;
                }
            }
        }

    }

    //Used to disbale buttons when the game is loaded
    public void Load()
    {
        selected.GetComponent<Button>().interactable = false;
    }

    //Returns the player to the player object with a paper with the crooect details to be faxed or binned
    void ReturnToPlayer()
    {
        //Gets the policy page prefab from the resources folder
        prefab = (GameObject)Resources.Load("Paper", typeof(GameObject));

        player.SetActive(true);

        interactionScript.enabled = true;

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

        conSc.cameraScript = this;
        conSc.UpdateContact(contactName, statNames, statApprove, statDecline, planet);

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
            interactionScript.pcActive = false;
        }

        canvas.SetActive(true);

        statsScript.TimeForward();

        statApprove.Clear();
        statDecline.Clear();

        if (statsScript.day == 2 && firstPCUse == true)
        {
            robotDialogueTrigger.TriggerRobotDialogue2_9();
            firstPCUse = false;
        }

        gameObject.SetActive(false);
    }
}
