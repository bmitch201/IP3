using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Phone))]

public class InteractionScript : MonoBehaviour
{
    [Header ("Game Objects")]
    public GameObject prefab;
    public GameObject spawnPos;
    public GameObject obj;
    public GameObject phonePanel;
    public TextMesh info;
    GameObject es;

    [Header ("Cameras")]
    public GameObject pcCamera, chairCamera, boardCamera;
    public GameObject earthFolderCamera, marsFolderCamera, venusFolderCamera;
    public GameObject conferenceCamera;

    [Header ("Canvas")]
    public GameObject canvas;
    public GameObject conferenceCanvas;

    Phone phoneScript;
    Stats statsScript;
    PolicyScript policyScript;
    public FolderScript folderScript;
    DialogueTrigger dialogueTrigger;
    RobotDialogueTrigger robotDialogueTrigger;
    DialogueManager dialogueManager;
    DayOneScript dayOneScript;

    [Header("Booleans")]
    public bool holding;
    bool holdingPaper;
    public bool holdingPolicy;
    public bool withinAnswerDistance;
    public bool answered;
    bool phoneCanvasOn;
    public bool folder;
    public bool pcActive;

    float dist;

    string item;

    //Used to setup the objects
    void Start()
    {
        spawnPos = GameObject.Find("SpawnPos");

        info.gameObject.SetActive(false);

        phoneScript = GameObject.FindGameObjectWithTag("Phone").GetComponent<Phone>();
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        dialogueTrigger = GameObject.FindGameObjectWithTag("ConferenceCall").GetComponent<DialogueTrigger>();
        robotDialogueTrigger = GameObject.FindObjectOfType<RobotDialogueTrigger>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        dayOneScript = FindObjectOfType<DayOneScript>();

        es = GameObject.Find("EventSystem");

        Folder();

        if (statsScript.day == 2)
        {
            robotDialogueTrigger.TriggerRobotDialogue2_1();
        }
    }

    void Update()
    {
        if(statsScript.newDay)
        {
            statsScript.NewDay();
            statsScript.newDay = false;
        }

        //Sets up a raycast for the position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        //If the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            //Get the distance to the object from the current position
            dist = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);

            if (hit.collider.gameObject.tag == "Chair")
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'F' to sit";
                    info.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    chairCamera.SetActive(true);
                }
            }
            else if (hit.collider.gameObject.tag == "Board")
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'F' to open";
                    info.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    boardCamera.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
            //If the phone is ringing
            else if (phoneScript.isRinging == true)
            {
                //If the object hit is the phone and the distance to it is less than 5 then 
                //show the player a message to allow them to answer the phone
                if (hit.collider.gameObject.tag == "Phone")
                {
                    if (dist <= 5.0f)
                    {
                        info.text = "Press 'F' to answer";
                        info.gameObject.SetActive(true);
                        withinAnswerDistance = true;
                    }
                }
            }
            //Any other object remove the info
            else
            {
                info.gameObject.SetActive(false);
            }
        }
        //}


        //If the user hits F
        if (Input.GetKeyDown(KeyCode.F) && !holding)
        {
            //If the object hit by the raycast is the PC then activate the PC Camera
            //and update the canvas to display the correct stats
            if (hit.collider.gameObject.tag == "PC")
            {
                pcCamera.SetActive(true);
                canvas.SetActive(false);
                statsScript.UpdateScreen();
                gameObject.SetActive(false);
                pcActive = true;

            }
            //If the object hit by the raycast is the Folder then activate the folder camera,
            //activate the cursor and run the folder method 
            else if (hit.collider.gameObject.tag == "Folder")
            {
                GameObject folderCamera = earthFolderCamera;

                switch (hit.collider.transform.parent.transform.parent.gameObject.name)
                {
                    case "Earth Folder":
                        folderCamera = earthFolderCamera;
                        folderScript = earthFolderCamera.GetComponent<FolderScript>();

                        GameObject.Find("Mars Folder Canvas").SetActive(false);
                        GameObject.Find("Venus Folder Canvas").SetActive(false);
                        break;

                    case "Mars Folder":
                        folderCamera = marsFolderCamera;
                        folderScript = marsFolderCamera.GetComponent<FolderScript>();

                        GameObject.Find("Earth Folder Canvas").SetActive(false);
                        GameObject.Find("Venus Folder Canvas").SetActive(false);
                        break;

                    case "Venus Folder":
                        folderCamera = venusFolderCamera;
                        folderScript = venusFolderCamera.GetComponent<FolderScript>();

                        GameObject.Find("Mars Folder Canvas").SetActive(false);
                        GameObject.Find("Earth Folder Canvas").SetActive(false);
                        break;
                }

                RotationScript rot = hit.collider.transform.parent.transform.parent.gameObject.GetComponent<RotationScript>();

                rot.endPos = GameObject.Find("FolderEndPos").transform;
                rot.startTime = Time.time;
                rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                StartCoroutine(FolderOut(rot));

                folderCamera.SetActive(true);

                GameObject.Find("MainCamera").transform.LookAt(hit.collider.gameObject.transform);
            }
            else if (hit.collider.gameObject.tag == "ConferenceCall")
            {
                conferenceCamera.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                dialogueManager.speakerPanel.SetActive(true);
                gameObject.SetActive(false);
                dialogueTrigger.TriggerDialogue();
                folder = true;
                Folder();
                statsScript.TimeForward();
            }

        }
        //}

        
        #region Buttons

        //If the phone is ringing
        if (phoneScript.isRinging == true)
        {
            //If the user presses F and is within answer distance
            if (Input.GetKeyDown(KeyCode.F) && withinAnswerDistance == true)
            {
                //If the object hit by the ray is the phone
                if (hit.collider.gameObject.tag == "Phone")
                {
                    info.gameObject.SetActive(false);
                    answered = true;
                    phoneScript.callMissed = false;
                    phoneScript.ringTimerActive = false;
                    phoneScript.isRinging = false;
                    phonePanel.SetActive(true);
                    phoneCanvasOn = true;
                    statsScript.TimeForward();
                }
            }
        }

        //If the phone canvas is active i.e. the user has picked up the phone
        if (phoneCanvasOn)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                phonePanel.SetActive(false);
                //Spawn a piece of paper
                prefab = (GameObject)Resources.Load("Policy", typeof(GameObject));
                obj = Instantiate(prefab, spawnPos.transform.position, GameObject.Find("MainCamera").transform.rotation);
                obj.transform.parent = spawnPos.transform;
                obj.transform.rotation = obj.transform.rotation * new Quaternion(0, 1, -30, 0);
                holding = true;
                phoneCanvasOn = false;
                holdingPaper = true;
            }
        }

        //If holding is true
        if (holding == true)
        {
            //Find the distance to the bin and the fax machine
            float distToTrash = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Bin").transform.position);
            float distToFax = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Fax").transform.position);

            //If holding a boring piece of paper
            if (holdingPaper == true)
            {
                //If the distance to the bin is less than 1
                //TODO CHANGE THIS TO MAKE USE OF COLLIDERS INSTEAD OF THE DISTANCE
                if (distToTrash <= 1.5f)
                {
                    //If the player hits F then Destroy the paper, descrease the time and the stats, 
                    //Update the PC screen and set holding to false 
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(obj);
                        holding = !holding;                                             
                        holdingPaper = !holdingPaper;
                        statsScript.TimeForward();

                        if (phoneScript.firstCall)
                        {
                            statsScript.stats[6] -= 10;
                        }
                        else
                        {
                            statsScript.stats[5] -= 5;
                        }

                        statsScript.UpdateScreen();
                    }
                }
                //If the distance to the fax is less than 1
                else if (distToFax <= 1.5f)
                {
                    //If the player hits F then Destroy the paper, descrease the time and increase the stats, 
                    //Update the PC screen and set holding to false
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(obj);
                        holding = !holding;
                        holdingPaper = !holdingPaper;
                        statsScript.TimeForward();

                        if (phoneScript.firstCall)
                        {
                            statsScript.stats[1] += 0.2f;
                            statsScript.stats[6] += 10;
                            statsScript.stats[2] -= 5;

                        }
                        else
                        {
                            statsScript.stats[5] += 10;
                            statsScript.stats[2] -= 5;
                        }

                        statsScript.UpdateScreen();
                    }
                }
            }

            //If holding a not so boring piece of paper
            else if (holdingPolicy == true)
            {
                //If the distance to the bin is less than 1
                if (distToTrash <= 1.0f)
                {
                    //If the player hits F then Destroy the Policy, descrease the time, 
                    //set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(obj);
                        holding = !holding;
                        phoneScript.timeUntilRingTimerActive = true;
                        holdingPolicy = false;
                        answered = false;
                        statsScript.TimeForward();
                    }
                }
                //If the distance to the fax is less than 1
                else if (distToFax <= 1.0f)
                {
                    //If the player hits F then Destroy the Policy, descrease the time and the stats, 
                    //Update the PC screen and set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(obj);
                        holding = !holding;
                        
                        for(int i = 0; i < policyScript.decreases.Length; i++)
                        {
                            statsScript.stats[i] += policyScript.decreases[i];
                        }

                        folderScript.buttons = policyScript.buttonAmount;
                        folderScript.type = policyScript.type;
                        folderScript.DisableButton();
                        statsScript.UpdateScreen();
                        phoneScript.timeUntilRingTimerActive = true;
                        holdingPolicy = false;
                        answered = false;
                        statsScript.TimeForward();
                    }
                }
            }
        }
        
#endregion
    }

    //Used to activate the EventSystem so that the buttons do not get clicked when the folder is inactive
    public void Folder()
    {
        if (!folder)
        {
            es.SetActive(false);
        }
        else
        {
            es.SetActive(true);
        }
    }

    //Used to setup the policy script when the object is created
    public void PolicyScript()
    {
        policyScript = obj.GetComponent<PolicyScript>();
    }

    IEnumerator FolderOut(RotationScript rot)
    {
        rot.enabled = true;
        yield return new WaitForSeconds(1.25f);
        rot.endPos = GameObject.Find(folderScript.planet + "FolderStartPos").transform;
        rot.enabled = false;
        folderScript.enabled = true;
        folder = true;
        Folder();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        folderScript.anim.Play("Open");
        this.transform.position = folderScript.playerSpawn.transform.position;
        gameObject.SetActive(false);
        statsScript.TimeForward();
    }
}