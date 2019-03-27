using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonFolderScript : MonoBehaviour {

    public InteractionScript interactionScript;
    public DayOneScript dayOneScript;
    RobotDialogueTrigger dialogueTrigger;
    Stats statsScript;

    [Header("Animations")]
    public Animator anim;

    [Header("GameObjects")]
    public GameObject frontPage, player, chair, currentPage, lastPage, eduPage, healPage, nsPage, bcPage, wrPage, fundsPage, page1, page2, page3, pageMain, es;
    GameObject prefab, canvas1, canvas2, canvas3;

    [Header("Button Type")]
    public string type, buttonClicked;

    [Header("UI")]
    public int buttons;
    public Text fundsText;

    [Header("Lists")]
    List<float> changes = new List<float>();
    List<string> changedNames = new List<string>();

    void Start()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        dialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
    }

    void Awake()
    {
        interactionScript = player.GetComponent<InteractionScript>();

        //Sets the current page to be false as long as the variable is holding an object
        if (currentPage != null)
        {
            currentPage.SetActive(false);
        }

        //Set it to the front page
        currentPage = frontPage;
        currentPage.SetActive(true);

        dialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();

        canvas1 = GameObject.Find("Earth Folder Canvas");
        canvas2 = GameObject.Find("Mars Folder Canvas");
        canvas3 = GameObject.Find("Venus Folder Canvas");

        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

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

            es.SetActive(false);

            //Close the folder
            anim.Play("Close");
            gameObject.SetActive(false);

            canvas1.SetActive(true);
            canvas2.SetActive(true);
            canvas3.SetActive(true);

            //Activate the player
            chair.SetActive(true);
        }
    }

    #region FrontPage

    public void Education()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = eduPage;
        type = "Education";
        buttons = 1;
        currentPage.SetActive(true);
    }

    public void Healthcare()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = healPage;
        type = "Healthcare";
        buttons = 1;
        currentPage.SetActive(true);
    }

    public void NationalServices()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = nsPage;
        type = "National Services";
        buttons = 1;
        currentPage.SetActive(true);
    }

    public void BorderControl()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = bcPage;
        type = "Border Control";
        buttons = 1;
        currentPage.SetActive(true);
    }

    public void WorkerRegulations()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = wrPage;
        type = "Worker Regulations";
        buttons = 1;
        currentPage.SetActive(true);
    }

    public void PopFunds()
    {
        currentPage.SetActive(false);
        lastPage = currentPage;
        currentPage = fundsPage;
        type = "PopFunds";
        buttons = 3;
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
        buttons = 1;

        ReturnToPlayer();
    }

    public void HealEnact()
    {
        changes.Add(-0.2f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");

        buttonClicked = "Healthcare";
        buttons = 1;

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
        buttons = 1;

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
        buttons = 1;

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
        buttons = 1;

        ReturnToPlayer();
    }

    #endregion

    #region Population Funds

    public void Wage()
    {
        pageMain.SetActive(false);
        page1.SetActive(true);
    }

    public void WageInc()
    {
        changes.Add(-0.4f);
        changes.Add(10f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");

        buttonClicked = "Wage Increase";
        buttons = 3;

        ReturnToPlayer();
    }

    public void WageDec()
    {
        changes.Add(0.2f);
        changes.Add(-5f);
        changes.Add(-5f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");

        buttonClicked = "Wage Decrease";
        buttons = 3;

        ReturnToPlayer();
    }

    public void Pension()
    {
        pageMain.SetActive(false);
        page2.SetActive(true);
    }

    public void PenInc()
    {
        changes.Add(-0.3f);
        changes.Add(5f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");

        buttonClicked = "Pension Increase";
        buttons = 3;

        ReturnToPlayer();
    }

    public void PenDec()
    {
        changes.Add(0.1f);
        changes.Add(-10f);

        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");

        buttonClicked = "Pension Decrease";
        buttons = 3;

        ReturnToPlayer();
    }

    public void Taxes()
    {
        pageMain.SetActive(false);
        page3.SetActive(true);
    }

    public void TaxInc()
    {
        changes.Add(0.3f);
        changes.Add(-10f);

        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");

        buttonClicked = "Tax Increase";
        buttons = 3;

        ReturnToPlayer();
    }

    public void TaxDec()
    {
        changes.Add(-0.3f);
        changes.Add(5f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");

        buttonClicked = "Tax Decrease";
        buttons = 3;

        ReturnToPlayer();
    }

    public void FundsBack()
    {
        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
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
        currentPage.SetActive(false);

        //Sets the last page to active in order to deactivate the buttons
        lastPage.SetActive(true);

        if (type == "PopFunds")
        {
            //Sets a text object to be displayed to the player to inform them of their choice
            fundsText.gameObject.SetActive(true);
            fundsText.text = buttonClicked + " is the chosen policy";

            //For each of the buttons on said page
            for (int i = 1; i <= buttons; i++)
            {
                //Deactivate the button
                GameObject.Find(type + "Button" + i).GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            GameObject.Find("Button").GetComponent<Button>().interactable = false;
        }

        //Set the last page to be inactive
        lastPage.SetActive(false);

        currentPage.SetActive(true);
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

        canvas1.SetActive(true);
        canvas2.SetActive(true);
        canvas3.SetActive(true);
    }

    void ReturnToPlayer()
    {             
        //Close the folder
        anim.Play("Close");



        statsScript.TimeForward();

        interactionScript.policy = true;

        //Activate the player
        player.SetActive(true);
        
        //Gets the policy page prefab from the resources folder
        prefab = (GameObject)Resources.Load("Policy", typeof(GameObject));

        Reset();

        //Sets the current page active to false
        currentPage.SetActive(false);

        //Resets the current page to the front page and activates it
        lastPage = currentPage;
        currentPage = frontPage;
        currentPage.SetActive(true);

        es.SetActive(false);

        PolicyScript policyScript;

        //Sets up the prefab to be spawned on the player
        interactionScript.prefab = Instantiate(prefab, interactionScript.spawnPos.transform.position, GameObject.Find("MainCamera").transform.rotation);
        interactionScript.prefab.transform.parent = GameObject.Find("SpawnPos").transform;
        interactionScript.holdingPolicy = true;
        interactionScript.holding = true;
        interactionScript.folder = false;
        interactionScript.moonFolderScript = this;

        //Calls the folder and policy methods within the interaction script
        interactionScript.FolderOn();
        interactionScript.PolicyScript();

        policyScript = interactionScript.prefab.GetComponent<PolicyScript>();

        //Sets up the stats for the policy script
        policyScript.UpdatePolicy(changes, changedNames);
        policyScript.type = type;
        policyScript.chosenPolicy = buttonClicked;
        policyScript.buttonAmount = buttons;
        policyScript.planet = "Moon";

        policyScript.taxType = buttonClicked;
        
        //Clears the lists onced they have been used
        changedNames.Clear();
        changes.Clear();

        gameObject.SetActive(false);

        if (interactionScript.uses == 0)
        {
            dialogueTrigger.TriggerRobotDialogue2_6();
        }
    }
}
