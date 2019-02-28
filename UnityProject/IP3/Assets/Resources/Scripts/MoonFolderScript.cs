using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonFolderScript : MonoBehaviour {

    public InteractionScript interactionScript;
    RobotDialogueTrigger dialogueTrigger;
    Stats statsScript;

    [Header("Animations")]
    public Animator anim;

    [Header("GameObjects")]
    public GameObject frontPage, player, currentPage, lastPage, eduPage, healPage, nsPage, bcPage, wrPage, fundsPage, page1, page2, page3, pageMain;
    GameObject newPage;

    [Header("Button Type")]
    public string type;
    string buttonClicked;

    [Header("UI")]
    public int buttons = 3;
    public Text fundsText;

    [Header("Lists")]
    List<float> changes = new List<float>();
    List<string> changedNames = new List<string>();

    void Start()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
    }

    void Awake()
    {
        anim.Play("Open");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Sets the current page to be false as long as the variable is holding an object
        if (currentPage != null)
        {
            currentPage.SetActive(false);
        }

        //Set it to the front page
        currentPage = frontPage;
        currentPage.SetActive(true);

        //Sets up the interaction from the player
        //interactionScript = player.GetComponent<InteractionScript>();

        dialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
    }

    void Update()
    {
        if (player == null && GameObject.Find("PlayerController") != null)
        {
            player = GameObject.Find("PlayerController");
            interactionScript = player.GetComponent<InteractionScript>();
        }

        if (statsScript == null)
        {
            statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        }

        //If the current variable has no object attachted to it
        if (currentPage == null)
        {
            //Set it to the front page
            currentPage = frontPage;
            currentPage.SetActive(true);
        }

        //If the player hits F while in the folder
        if (Input.GetKeyDown(KeyCode.F))
        {
            Reset();
            
            //Sets the current page active to false
            currentPage.SetActive(false);

            //Resets the current page to the front page and activates it
            currentPage = frontPage;
            currentPage.SetActive(true);

            //Close the folder
            anim.Play("Close");
            gameObject.SetActive(false);

            //Activate the player
            player.SetActive(true);
        }
    }

    #region FrontPage

    public void Education()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = eduPage;
        type = "Education";
        currentPage.SetActive(true);
    }

    public void Healthcare()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = healPage;
        type = "Healthcare";
        currentPage.SetActive(true);
    }

    public void NationalServices()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = nsPage;
        type = "National Services";
        currentPage.SetActive(true);
    }

    public void BorderControl()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = bcPage;
        type = "Border Control";
        currentPage.SetActive(true);
    }

    public void WorkerRegulations()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = wrPage;
        type = "Worker Regulations";
        currentPage.SetActive(true);
    }

    public void PopFunds()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = fundsPage;
        type = "Population Funds";
        currentPage.SetActive(true);

        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
    }

    #endregion

    #region Enacting

    public void EduEnact()
    {
        changes.Add(-0.1f);
        changes.Add(5f);

        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");

        buttonClicked = "Education";

        ReturnToPlayer();
    }

    public void HealEnact()
    {
        changes.Add(-0.2f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");

        buttonClicked = "Healthcare";

        ReturnToPlayer();
    }

    public void NSEnact()
    {
        changes.Add(-0.3f);
        changes.Add(5f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");

        buttonClicked = "National Services";

        ReturnToPlayer();
    }

    public void BCEnact()
    {
        changes.Add(-0.2f);
        changes.Add(10f);
        changes.Add(-5f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");

        buttonClicked = "Border Control";

        ReturnToPlayer();
    }

    public void WREnact()
    {
        changes.Add(-0.2f);
        changes.Add(5f);
        changes.Add(5f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");


        buttonClicked = "Worker Regulations";

        ReturnToPlayer();
    }

    #endregion

    //Called when the player hits the back button on the main pages
    public void Back()
    {
        Reset();

        //Sets the current to be deactivated
        currentPage.SetActive(false);

        currentPage = lastPage;

        currentPage.SetActive(true);
    }

    //Disables the buttons on a page if the player has selected a policy
    public void DisableButton()
    {
        //Sets the last page to active in order to deactivate the buttons
        lastPage.SetActive(true);

        //Sets a text object to be displayed to the player to inform them of their choice
        fundsText.gameObject.SetActive(true);
        fundsText.text = buttonClicked + " is the chosen policy";

        //For each of the buttons on said page
        for (int i = 1; i <= buttons; i++)
        {
            //Deactivate the button
            GameObject.Find(type + "Button" + i).GetComponent<Button>().interactable = false;
        }

        //Set the last page to be inactive
        lastPage.SetActive(false);
    }

    //Resets the pages 
    void Reset()
    {
        if (pageMain != null)
        {
            pageMain.SetActive(true);
        }

        if (page1 != null)
        {
            page1.SetActive(true);
        }

        if (page2 != null)
        {
            page2.SetActive(true);
        }

        if (page3 != null)
        {
            page3.SetActive(true);
        }
    }

    void ReturnToPlayer()
    {

    }
}
