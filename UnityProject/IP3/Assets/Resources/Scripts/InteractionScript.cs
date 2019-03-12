﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Phone))]

public class InteractionScript : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject prefab;
    public Transform spawnPos;
    public GameObject phonePanel;
    public TextMesh info;
    GameObject es;
    GameObject paper;

    [Header("Cameras")]
    public GameObject pcCamera, chairCamera, boardCamera;
    public GameObject conferenceCamera;

    [Header("Canvas")]
    public GameObject canvas;
    public GameObject conferenceCanvas;

    Phone phoneScript;
    Stats statsScript;
    PolicyScript policyScript;
    public FolderScript folderScript;
    DialogueTrigger dialogueTrigger;
    RobotDialogueTrigger robotDialogueTrigger;
    RobotDialogueManager robotDialogueManager;
    DialogueManager dialogueManager;
    public ContactScript contactScript;
    public MoonFolderScript moonFolderScript;

    [Header("Booleans")]
    public bool holding;
    bool holdingPaper;
    public bool holdingPolicy, holdingContact, holdingPhone;
    public bool withinAnswerDistance;
    public bool answered;
    bool phoneCanvasOn;
    public bool folder;
    public bool pcActive;
    public bool contact;
    bool triggerOnce;
    bool triggerOnce2;

    float dist;
    public int uses;
    public int contactUses;

    string item;

    public bool conferenceCallInteractable = false;

    public bool policy = false;

    public GameObject earthCanvas, marsCanvas, venusCanvas, moonCanvas;
    public GameObject earthCamera, marsCamera, venusCamera, folderCamera;
    public GameObject robotPanel;
    public GameObject femaleHologram;

    PolicyChoices policyChoices;

    AudioSource trashAudio, faxAudio;

    public AudioSource conferenceCallAudio, pcAudio;

    public AudioClip trashFX, faxFX, typingFX, conferenceCallFX;

    //Used to setup the objects
    void Start()
    {

        info.gameObject.SetActive(false);

        statsScript = FindObjectOfType<Stats>();
        policyChoices = FindObjectOfType<PolicyChoices>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        phoneScript = FindObjectOfType<Phone>();
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        folderScript = FindObjectOfType<FolderScript>();
        robotDialogueManager = FindObjectOfType<RobotDialogueManager>();

        trashAudio = GameObject.FindGameObjectWithTag("Bin").GetComponent<AudioSource>();
        faxAudio = GameObject.FindGameObjectWithTag("Fax").GetComponent<AudioSource>();
        pcAudio = GameObject.FindGameObjectWithTag("Fax").GetComponent<AudioSource>();
        conferenceCallAudio = GameObject.FindGameObjectWithTag("ConferenceCall").GetComponent<AudioSource>();

        es = GameObject.Find("EventSystem");

        paper = (GameObject)Resources.Load("Policy", typeof(GameObject));

        if (GameObject.Find("GameInfoObject DDL") != null)
        {
            pcCamera.GetComponent<CameraScript>().statsScript = GameObject.Find("GameInfoObject DDL").GetComponent<Stats>();
            pcCamera.GetComponent<CameraScript>().CheckScript();
        }

        FolderOn();

        if (statsScript.day == 2)
        {
            robotDialogueTrigger.TriggerRobotDialogue2_1();
        }

        uses = 0;
        contactUses = 0;

        triggerOnce = true;
        triggerOnce2 = true;
    }

    void Update()
    {
        if (earthCamera == null)
        {
            earthCamera = statsScript.earthCam;
            marsCamera = statsScript.marsCam;
            venusCamera = statsScript.venusCam;
        }

        if (earthCanvas == null)
        {
            earthCanvas = GameObject.Find("Earth Folder Canvas");
            marsCanvas = GameObject.Find("Mars Folder Canvas");
            venusCanvas = GameObject.Find("Venus Folder Canvas");
            moonCanvas = GameObject.Find("Moon Folder Canvas");
        }

        if (statsScript.newDay)
        {
            statsScript.NewDay();
            statsScript.newDay = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Sets up a raycast for the position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        //If the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            //Get the distance to the object from the current position
            float dist = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);

            if (hit.collider.gameObject.tag == "Chair")
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'F' to sit";
                    info.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        info.gameObject.SetActive(false);
                        chairCamera.SetActive(true);
                    }
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
            else if (hit.collider.gameObject.tag == "Folder")
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'F' to open";
                    info.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        RotationScript rot = hit.collider.transform.parent.transform.parent.gameObject.GetComponent<RotationScript>();

                        rot.endPos = GameObject.Find("FolderEndPos").transform;
                        rot.startTime = Time.time;
                        rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                        if (hit.collider.transform.parent.transform.parent.gameObject.name == "Earth Folder")
                        {
                            folderCamera = earthCamera;
                            marsCanvas.SetActive(false);
                            venusCanvas.SetActive(false);
                        }
                        else if (hit.collider.transform.parent.transform.parent.gameObject.name == "Mars Folder")
                        {
                            folderCamera = marsCamera;
                            earthCanvas.SetActive(false);
                            venusCanvas.SetActive(false);
                        }
                        else
                        {
                            folderCamera = venusCamera;
                            earthCanvas.SetActive(false);
                            marsCanvas.SetActive(false);
                        }

                        StartCoroutine(FolderOut(rot));
                        folderCamera.GetComponent<FolderScript>().enabled = true;
                        GameObject.Find("MainCamera").transform.LookAt(hit.collider.gameObject.transform);
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Fax" && holding)
            {
                if (dist <= 1.25f)
                {
                    info.text = "Press 'F' to enact";
                    info.gameObject.SetActive(true);

                    //If the player hits F then Destroy the Policy, descrease the time and the stats, 
                    //Update the PC screen and set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(prefab);
                        holding = !holding;

                        if (holdingPolicy)
                        {
                            for (int i = 0; i < policyScript.decreases.Length; i++)
                            {
                                statsScript.stats[i] += policyScript.decreases[i];
                            }

                            if (folderScript != null && moonFolderScript == null)
                            {
                                folderScript.buttons = policyScript.buttonAmount;
                                folderScript.type = policyScript.type;
                                folderScript.DisableButton();
                            }
                            else
                            {
                                moonFolderScript.buttons = policyScript.buttonAmount;
                                moonFolderScript.type = policyScript.type;
                            }

                            if (policyChoices.movementChoice != "")
                            {
                                policyChoices.movementChoice = policyScript.movement;
                                policyChoices.planetType = policyScript.pfm;
                            }

                            if (policy)
                            {
                                uses++;
                                statsScript.chosenPolicies.Add(policyScript.chosenPolicy);
                                statsScript.chosenPlanets.Add(policyScript.planet);

                                if (statsScript.day == 2)
                                {
                                    if (uses == 1)
                                    {
                                        robotDialogueTrigger.TriggerRobotDialogue2_7();
                                    }
                                }

                                policy = false;
                            }

                            holdingPolicy = false;
                        }
                        else if (holdingContact)
                        {
                            prefab.GetComponent<ContactScript>().Enact();

                            contactUses++;

                            if (statsScript.day == 2)
                            {
                                if (contactUses == 1)
                                {
                                    robotDialogueTrigger.TriggerRobotDialogue2_10();
                                }
                            }

                            holdingContact = false;
                        }
                        else if (holdingPhone)
                        {
                            statsScript.phonecallAccept.Add(phoneScript.phonecall);

                            if (phoneScript.calls == 2)
                            {
                                robotDialogueTrigger.TriggerRobotDialogue2_14();
                                conferenceCallInteractable = true;
                                conferenceCallAudio.clip = conferenceCallFX;
                                conferenceCallAudio.Play();
                                phoneScript.calls = 0;
                            }

                            holdingPhone = false;
                        }

                        statsScript.UpdateScreen();
                        statsScript.TimeForward();

                        faxAudio.clip = faxFX;
                        faxAudio.PlayOneShot(faxFX);
                    }
                }


            }
            else if (hit.collider.gameObject.tag == "Bin" && holding)
            {
                //If the distance to the bin is less than 1
                if (dist <= 1.25f)
                {
                    info.text = "Press 'F' to scrap";
                    info.gameObject.SetActive(true);

                    //If the player hits F then Destroy the Policy, descrease the time, 
                    //set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(prefab);
                        holding = !holding;

                        statsScript.TimeForward();

                        trashAudio.clip = trashFX;
                        trashAudio.PlayOneShot(trashFX);

                        if (holdingPhone)
                        {
                            for (int i = 0; i < policyScript.scrap.Length; i++)
                            {
                                statsScript.stats[i] += policyScript.scrap[i];
                            }

                            statsScript.phonecallDecline.Add(phoneScript.phonecall);

                            if (statsScript.day == 2)
                            {
                                if (phoneScript.calls == 2)
                                {
                                    statsScript.wifeCounter++;
                                    robotDialogueTrigger.TriggerRobotDialogue2_14();
                                    conferenceCallInteractable = true;
                                    conferenceCallAudio.clip = conferenceCallFX;
                                    conferenceCallAudio.Play();
                                    phoneScript.calls = 0;
                                }
                            }

                            holdingPhone = false;
                        }

                        if (policy)
                        {
                            uses++;

                            if (statsScript.day == 2)
                            {
                                if (uses == 1)
                                {
                                    robotDialogueTrigger.TriggerRobotDialogue2_7();
                                }
                            }

                            policy = false;
                        }

                        if (holdingContact)
                        {
                            contactUses++;

                            if (statsScript.day == 2)
                            {
                                if (contactUses == 1)
                                {
                                    robotDialogueTrigger.TriggerRobotDialogue2_10();
                                }
                            }
                            holdingContact = false;
                        }                     
                    }
                }
            }
            //If the phone is ringing and If the object hit is the phone and the distance to it is less than 2.5 then 
            //show the player a message to allow them to answer the phone
            else if (phoneScript.isRinging == true && hit.collider.gameObject.tag == "Phone" && dist <= 2.5f)
            {
                info.text = "Press 'F' to answer";
                info.gameObject.SetActive(true);

                //If the phone is ringing
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (statsScript.day == 2)
                    {
                        if (phoneScript.calls == 1)
                        {
                            info.gameObject.SetActive(false);
                            answered = true;
                            phoneScript.newAudio = true;
                            phoneScript.callMissed = false;
                            phoneScript.ringTimerActive = false;
                            phoneScript.isRinging = false;
                            phonePanel.SetActive(true);
                            phoneCanvasOn = true;
                        }
                        else
                        {
                            info.gameObject.SetActive(false);
                            answered = true;
                            phoneScript.newAudio = true;
                            phoneScript.callMissed = false;
                            phoneScript.ringTimerActive = false;
                            phoneScript.isRinging = false;
                            phonePanel.SetActive(true);
                            phoneCanvasOn = true;
                            statsScript.TimeForward();
                        }
                    }
                }
            }

            //If the conference call is hit, it is interactable and the distance is less than 2.5, then display info text
            else if (hit.collider.gameObject.tag == "ConferenceCall" && conferenceCallInteractable == true && dist <= 2.5f)
            {
                info.text = "Press 'F' to start call";
                info.gameObject.SetActive(true);

                //If the player presses F, start conference call
                if (Input.GetKeyDown(KeyCode.F))
                {
                    conferenceCallAudio.Stop();
                    conferenceCamera.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    dialogueManager.speakerPanel.SetActive(true);
                    femaleHologram.SetActive(true);
                    robotDialogueManager.conferencePhoneRing = false;
                    folder = true;
                    FolderOn();
                    statsScript.TimeForward();
                    gameObject.SetActive(false);

                    if (statsScript.day == 2)
                    {
                        dialogueTrigger.TriggerConferenceDialogue1();
                    }
                }
            }
            //Any other object remove the info
            else
            {
                info.gameObject.SetActive(false);
            }
        }
        //Any other object remove the info
        else
        {
            info.gameObject.SetActive(false);
        }



        //If the phone canvas is active i.e. the user has picked up the phone
        if (phoneCanvasOn)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (statsScript.day == 2)
                {
                    if (phoneScript.calls == 1)
                    {
                        holding = true;
                        holdingPhone = true;
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;
                        robotDialogueTrigger.TriggerRobotDialogue2_3();
                        phoneCanvasOn = false;
                    }
                    else if (phoneScript.calls == 2)
                    {
                        robotDialogueTrigger.TriggerRobotDialogue2_13();
                        holding = true;
                        holdingPhone = true;
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;

                        prefab = Instantiate(paper, spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
                        prefab.transform.parent = GameObject.Find("SpawnPos").transform;
                        holding = true;

                        PolicyScript();

                        policyScript.UpdatePolicy(phoneScript.faxChanges, phoneScript.faxChangedNames);
                        policyScript.UpdateBin(phoneScript.binChanges, phoneScript.binChangedNames);

                        phoneCanvasOn = false;
                    }
                }
            }
        }

        if (statsScript.day == 2)
        {
            if (statsScript.time == 5)
            {
                if (triggerOnce)
                {
                    robotDialogueTrigger.TriggerRobotDialogue2_11();
                    triggerOnce = false;
                }
            }
            if (statsScript.time == 4)
            {
                if (triggerOnce2)
                {
                    robotDialogueTrigger.TriggerRobotDialogue2_12();
                    phoneScript.phoneIsActive = true;
                    triggerOnce2 = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    //Used to activate the EventSystem so that the buttons do not get clicked when the folder is inactive
    public void FolderOn()
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
        policyScript = prefab.GetComponent<PolicyScript>();

        earthCanvas.SetActive(true);
        marsCanvas.SetActive(true);
        venusCanvas.SetActive(true);
        moonCanvas.SetActive(true);
    }

    IEnumerator FolderOut(RotationScript rot)
    {
        rot.enabled = true;

        yield return new WaitForSeconds(1.25f);

        folderScript = folderCamera.GetComponent<FolderScript>();

        rot.endPos = GameObject.Find(folderScript.planet + "FolderStartPos").transform;

        rot.enabled = false;
        folder = true;

        FolderOn();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        folderScript.anim.Play("Open");

        this.transform.position = folderScript.playerSpawn.transform.position;

        folderCamera.SetActive(true);
        folderScript.enabled = true;
        gameObject.SetActive(false);

        statsScript.TimeForward();
    }

}

                //GameObject folderCamera = earthFolderCamera;

                //switch (hit.collider.transform.parent.transform.parent.gameObject.name)
                //{
                //    case "Earth Folder":
                //        folderCamera = earthFolderCamera;
                //        folderScript = earthFolderCamera.GetComponent<FolderScript>();

                //        GameObject.Find("Mars Folder Canvas").SetActive(false);
                //        GameObject.Find("Venus Folder Canvas").SetActive(false);
                //        GameObject.Find("Moon Folder Canvas").SetActive(false);
                //        break;

                //    case "Mars Folder":
                //        folderCamera = marsFolderCamera;
                //        folderScript = marsFolderCamera.GetComponent<FolderScript>();

                //        GameObject.Find("Earth Folder Canvas").SetActive(false);
                //        GameObject.Find("Venus Folder Canvas").SetActive(false);
                //        GameObject.Find("Moon Folder Canvas").SetActive(false);
                //        break;

                //    case "Venus Folder":
                //        folderCamera = venusFolderCamera;
                //        folderScript = venusFolderCamera.GetComponent<FolderScript>();

                //        GameObject.Find("Mars Folder Canvas").SetActive(false);
                //        GameObject.Find("Earth Folder Canvas").SetActive(false);
                //        GameObject.Find("Moon Folder Canvas").SetActive(false);
                //        break;
                //}

                //RotationScript rot = hit.collider.transform.parent.transform.parent.gameObject.GetComponent<RotationScript>();

                //rot.endPos = GameObject.Find("FolderEndPos").transform;
                //rot.startTime = Time.time;
                //rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                //StartCoroutine(FolderOut(rot));

                //folderCamera.SetActive(true);

                //GameObject.Find("MainCamera").transform.LookAt(hit.collider.gameObject.transform);