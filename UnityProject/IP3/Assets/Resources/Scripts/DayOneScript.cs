using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayOneScript : MonoBehaviour {

    GameObject whiteboardLight;
    GameObject pcLight;
    GameObject faxLight;
    GameObject binLight;
    GameObject phoneLight;
    GameObject boardLight;
    GameObject clockLight;
    GameObject policyLight;
    GameObject paper;
    GameObject gameInfoObject;

    public bool wbActive = false;
    public bool pcActive = false;
    public bool faxActive = false;
    public bool phoneLActive = false;
    public bool boardActive = false;
    public bool clockActive = false;
    public bool policyActive = false;

    public bool pcIntractable = false;
    public bool phoneIntractable = false;
    public bool boardIntractable = false;
    public bool policyIntractable = false;
    public bool conferenceCallInteractable = false;

    public bool folder = false;
    public bool holding, holdingPolicy, holdingPhone, answeredPhone;
    public bool policy = false;
    public bool firstFolder = true;

    public bool firstPolicy = true;
    public bool withinAnswerDistance = false;
    public bool answered = false;
    public bool phoneActive = false;
    bool phoneCanvasOn = false;
    bool firstCallEnacted = false;

    public Text info;

    public GameObject pcCamera, chairCamera;
    public GameObject boardCamera;
    public GameObject canvas, earthCanvas, marsCanvas, venusCanvas, moonCanvas;
    public GameObject earthCamera, marsCamera, venusCamera, folderCamera;
    public GameObject conferenceCamera;
    public GameObject es;
    public GameObject prefab;
    public GameObject obj;
    public GameObject phonePanel;
    public GameObject robotPanel;
    public GameObject femaleHologram;

    public Transform spawnPos;

    float maxIntensity = 2.0f;

    public int uses = 0;

    Stats statsScript;
    RobotDialogueTrigger robotDialogueTrigger;
    RobotDialogueManager robotDialogueManager;
    DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;
    FolderScript folderScript;
    PolicyScript policyScript;
    Phone phoneScript;
    PolicyChoices policyChoices;
    public InteractionScript interactionScript;

    AudioSource trashAudio, faxAudio;

    public AudioSource conferenceCallAudio, pcAudio;

    public AudioClip trashFX, faxFX, typingFX, conferenceCallFX;

    void Start()
    {

        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        robotDialogueManager = FindObjectOfType<RobotDialogueManager>();
        phoneScript = FindObjectOfType<Phone>();
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        whiteboardLight = GameObject.Find("Highlight Whiteboard");
        pcLight = GameObject.Find("Highlight PC");
        faxLight = GameObject.Find("Highlight Fax");
        binLight = GameObject.Find("Highlight Bin");
        phoneLight = GameObject.Find("Highlight Phone");
        boardLight = GameObject.Find("Highlight Board");
        clockLight = GameObject.Find("Highlight Clock");
        policyLight = GameObject.Find("Highlight Folder");
        robotPanel = GameObject.Find("RobotPanel");

        trashAudio = GameObject.FindGameObjectWithTag("Bin").GetComponent<AudioSource>();
        faxAudio = GameObject.FindGameObjectWithTag("Fax").GetComponent<AudioSource>();
        pcAudio = GameObject.FindGameObjectWithTag("Fax").GetComponent<AudioSource>();
        conferenceCallAudio = GameObject.FindGameObjectWithTag("ConferenceCall").GetComponent<AudioSource>();

        Light();

        robotPanel.gameObject.SetActive(true);

        paper = (GameObject)Resources.Load("Policy", typeof(GameObject));

        if (GameObject.Find("GameInfoObject DDL") != null)
        {
            gameInfoObject = GameObject.Find("GameInfoObject DDL");
            pcCamera.GetComponent<CameraScript>().statsScript = GameObject.Find("GameInfoObject DDL").GetComponent<Stats>();
            pcCamera.GetComponent<CameraScript>().CheckScript();
        }
        else
        {
            gameInfoObject = GameObject.Find("GameInfoObject");
        }

        statsScript = gameInfoObject.GetComponent<Stats>();
        policyChoices = gameInfoObject.GetComponent<PolicyChoices>();

        if (statsScript.day > 1)
        {
            Load();
        }
        else
        {
            robotDialogueTrigger.TriggerRobotDialogue1();
        }
    }

    void Update()
    {
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

            if (hit.collider.gameObject.tag == "Chair" && pcIntractable)
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to sit";
                    info.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        info.gameObject.SetActive(false);
                        chairCamera.SetActive(true);
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Board" && boardIntractable)
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to open";
                    info.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    boardCamera.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
            else if (hit.collider.gameObject.tag == "Folder" && policyIntractable)
            {
                if (hit.collider.transform.parent.transform.parent.gameObject.name == "Earth Folder" && firstFolder)
                {
                    //If the distance to the object is less than 2.5
                    if (dist <= 2.5f)
                    {
                        info.text = "Press 'E' to open";
                        info.gameObject.SetActive(true);
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RotationScript rot = hit.collider.transform.parent.transform.parent.gameObject.GetComponent<RotationScript>();

                        rot.endPos = GameObject.Find("FolderEndPos").transform;
                        rot.startTime = Time.time;
                        rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                        folderCamera = earthCamera;

                        StartCoroutine(FolderOut(rot));

                        marsCanvas.SetActive(false);
                        venusCanvas.SetActive(false);

                        GameObject.Find("MainCamera").transform.LookAt(hit.collider.gameObject.transform);
                    }

                    
                }
                else if (!firstFolder)
                {
                    //If the distance to the object is less than 2.5
                    if (dist <= 2.5f)
                    {
                        info.text = "Press 'E' to open";
                        info.gameObject.SetActive(true);
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RotationScript rot = hit.collider.transform.parent.transform.parent.gameObject.GetComponent<RotationScript>();

                        rot.endPos = GameObject.Find("FolderEndPos").transform;
                        rot.startTime = Time.time;
                        rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                        if(hit.collider.transform.parent.transform.parent.gameObject.name == "Earth Folder")
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

                        GameObject.Find("MainCamera").transform.LookAt(hit.collider.gameObject.transform);
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Fax" && holding)
            {
                if (dist <= 1.25f)
                {
                    info.text = "Press 'E' to enact";
                    info.gameObject.SetActive(true);

                    //If the player hits F then Destroy the Policy, descrease the time and the stats, 
                    //Update the PC screen and set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(prefab);
                        holding = !holding;

                        for (int i = 0; i < policyScript.decreases.Length; i++)
                        {
                            statsScript.stats[i] += policyScript.decreases[i];
                        }

                        folderScript.buttons = policyScript.buttonAmount;
                        folderScript.type = policyScript.type;

                        policyChoices.movementChoice = policyScript.movement;
                        policyChoices.planetType = policyScript.pfm;                        

                        folderScript.DisableButton();
                        statsScript.UpdateScreen();
                        answered = false;
                        statsScript.TimeForward();

                        faxAudio.clip = faxFX;
                        faxAudio.PlayOneShot(faxFX);

                        if (policy)
                        {
                            statsScript.chosenPolicies.Add(policyScript.chosenPolicy);
                            statsScript.chosenPlanets.Add(policyScript.planet);
                            uses++;
                            policy = false;
                        }
                        else if (holdingPhone)
                        {
                            statsScript.phonecallAccept.Add(phoneScript.phonecall);
                            holdingPhone = false;
                        }                      

                        if (firstPolicy)
                        {
                            phoneActive = true;
                            phoneScript.firstCall = true;
                            phoneScript.dayOne = true;
                            firstFolder = false;
                            robotDialogueTrigger.TriggerRobotDialogue10();
                            firstPolicy = false;
                        }

                        if (firstCallEnacted)
                        {
                            robotDialogueTrigger.TriggerRobotDialogue12();
                            statsScript.phone1Accept = true;
                            firstCallEnacted = false;
                        }

                        if (uses == 2)
                        {
                            phoneActive = true;
                            phoneScript.firstCall = false;                            
                            uses = 0;
                        }

                        if (phoneScript.calls == 2)
                        {
                            robotDialogueTrigger.TriggerRobotDialogue13();
                            statsScript.phone2Accept = true;
                            conferenceCallAudio.clip = conferenceCallFX;
                            conferenceCallAudio.Play();
                            phoneScript.calls = 0;
                            phoneScript.dayOne = false;
                        }
                    }
                }


            }
            else if (hit.collider.gameObject.tag == "Bin" && holding)
            {
                //If the distance to the bin is less than 1
                if (dist <= 1.25f)
                {
                    info.text = "Press 'E' to scrap";
                    info.gameObject.SetActive(true);

                    //If the player hits E then Destroy the Policy, descrease the time, 
                    //set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(prefab);
                        holding = !holding;

                        if (holdingPhone)
                        {
                            statsScript.phonecallDecline.Add(phoneScript.phonecall);
                            holdingPhone = false;
                        }

                        policyIntractable = true;
                        statsScript.TimeForward();

                        trashAudio.clip = trashFX;
                        trashAudio.PlayOneShot(trashFX);

                        if (answered)
                        {
                            for (int i = 0; i < policyScript.scrap.Length; i++)
                            {
                                statsScript.stats[i] += policyScript.scrap[i];
                            }

                            answered = false;
                        }

                        if (policy)
                        {
                            if (uses == 1)
                            {
                                uses++;
                            }

                            policy = false;
                        }

                        if (firstCallEnacted)
                        {
                            robotDialogueTrigger.TriggerRobotDialogue12();
                            statsScript.phone1Accept = false;
                            firstCallEnacted = false;
                        }

                        if (uses == 2)
                        {
                            phoneActive = true;
                            phoneScript.firstCall = false;
                            uses = 0;
                        }

                        if (phoneScript.calls == 2)
                        {
                            robotDialogueTrigger.TriggerRobotDialogue13();
                            statsScript.phone2Accept = false;
                            conferenceCallAudio.clip = conferenceCallFX;
                            conferenceCallAudio.Play();
                            phoneScript.calls = 0;
                            phoneScript.dayOne = false;
                        }
                    }
                }
            }
            //If the phone is ringing and If the object hit is the phone and the distance to it is less than 2.5 then 
            //show the player a message to allow them to answer the phone
            else if (phoneScript.isRinging == true && hit.collider.gameObject.tag == "Phone" && dist <= 2.5f)
            {
                info.text = "Press 'E' to answer";
                info.gameObject.SetActive(true);

                //If the phone is ringing
                if (Input.GetKeyDown(KeyCode.E))
                {
                    answeredPhone = false;
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
            //If the conference call is hit, it is interactable and the distance is less than 2.5, then display info text
            else if (hit.collider.gameObject.tag == "ConferenceCall" && conferenceCallInteractable == true && dist <= 2.5f)
            {
                info.text = "Press 'E' to start call";
                info.gameObject.SetActive(true);

                //If the player presses E, start conference call
                if (Input.GetKeyDown(KeyCode.E))
                {
                    conferenceCallAudio.Stop();
                    conferenceCamera.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    dialogueManager.speakerPanel.SetActive(true);
                    femaleHologram.SetActive(true);
                    robotDialogueManager.conferencePhoneRing = false;
                    dialogueTrigger.TriggerDialogue();
                    folder = true;
                    FolderOn();
                    statsScript.TimeForward();
                    gameObject.SetActive(false);
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
            if (Input.GetKeyUp(KeyCode.E))
            {
                answeredPhone = true;
            }

            if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && answeredPhone)
            {
                phonePanel.SetActive(false);

                phoneScript.stopAudio = true;
                 
                prefab = Instantiate(paper, spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
                prefab.transform.parent = GameObject.Find("SpawnPos").transform;
                holding = true;
                holdingPhone = true;

                PolicyScript();

                policyScript.UpdatePolicy(phoneScript.faxChanges, phoneScript.faxChangedNames);
                policyScript.UpdateBin(phoneScript.binChanges, phoneScript.binChangedNames);

                phoneCanvasOn = false;

                if (phoneScript.firstCall)
                {
                    robotDialogueTrigger.TriggerRobotDialogue11();
                    firstCallEnacted = true;
                    statsScript.phone1Answered = true;
                }
                else
                {
                    statsScript.phone2Answered = true;
                }
            }
        }
    }

    #region Lights

    public void Light()
    {
        if (wbActive)
        {
            StartCoroutine(FlashWhiteboard());
            return;
        }
        else
        {
            whiteboardLight.GetComponent<Light>().intensity = 0;
        }

        if (pcActive)
        {
            StartCoroutine(FlashPC());
            return;
        }
        else
        {
            pcLight.GetComponent<Light>().intensity = 0;
        }

        if (faxActive)
        {
            StartCoroutine(FlashFax());
            return;
        }
        else
        {
            faxLight.GetComponent<Light>().intensity = 0;
            binLight.GetComponent<Light>().intensity = 0;
        }

        if (phoneLActive)
        {
            StartCoroutine(FlashPhone());
            return;
        }
        else
        {
            phoneLight.GetComponent<Light>().intensity = 0;
        }

        if (boardActive)
        {
            //StartCoroutine(FlashBoard());
            return;
        }
        else
        {
            boardLight.GetComponent<Light>().intensity = 0;
        }

        if (clockActive)
        {
            StartCoroutine(FlashClock());
            return;
        }
        else
        {
            clockLight.GetComponent<Light>().intensity = 0;
        }

        if (policyActive)
        {
            StartCoroutine(FlashFolder());
            return;
        }
        else
        {
            policyLight.GetComponent<Light>().intensity = 0;
        }
    }

    IEnumerator Whiteboard()
    {
        while (whiteboardLight.GetComponent<Light>().intensity <= 0)
        {
            whiteboardLight.GetComponent<Light>().intensity = 3f;
            yield return null;
        }

        while (whiteboardLight.GetComponent<Light>().intensity > 0)
        {
            whiteboardLight.GetComponent<Light>().intensity -= Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    IEnumerator PC()
    {
        while (pcLight.GetComponent<Light>().intensity > 0)
        {
            pcLight.GetComponent<Light>().intensity -= Time.deltaTime;
            yield return null;
        }

        if (pcLight.GetComponent<Light>().intensity <= 0)
        {
            pcLight.GetComponent<Light>().intensity = maxIntensity;
            yield return null;
        }

        yield return null;
    }

    IEnumerator FaxAndBin()
    {
        while (faxLight.GetComponent<Light>().intensity > 0)
        {
            faxLight.GetComponent<Light>().intensity -= Time.deltaTime;
            binLight.GetComponent<Light>().intensity -= Time.deltaTime;
            yield return null;
        }

        if (faxLight.GetComponent<Light>().intensity <= 0)
        {
            faxLight.GetComponent<Light>().intensity = maxIntensity;
            binLight.GetComponent<Light>().intensity = maxIntensity;
            yield return null;
        }

        yield return null;
    }

    IEnumerator Board()
    {
        while (boardLight.GetComponent<Light>().intensity > 0)
        {
            boardLight.GetComponent<Light>().intensity -= Time.deltaTime;
            yield return null;
        }

        if (boardLight.GetComponent<Light>().intensity <= 0)
        {
            boardLight.GetComponent<Light>().intensity = maxIntensity;

            yield return null;
        }

        yield return null;
    }

    IEnumerator Clock()
    {
        while (clockLight.GetComponent<Light>().intensity > 0)
        {
            clockLight.GetComponent<Light>().intensity -= Time.deltaTime;
            yield return null;
        }

        if (clockLight.GetComponent<Light>().intensity <= 0)
        {
            clockLight.GetComponent<Light>().intensity = 3f;

            yield return null;
        }

        yield return null;
    }

    IEnumerator Folder()
    {
        while (policyLight.GetComponent<Light>().intensity > 0)
        {
            policyLight.GetComponent<Light>().intensity -= Time.deltaTime;
            yield return null;
        }

        if (policyLight.GetComponent<Light>().intensity <= 0)
        {
            policyLight.GetComponent<Light>().intensity = maxIntensity;

            yield return null;
        }

        yield return null;
    }

    IEnumerator Phone()
    {
        while (phoneLight.GetComponent<Light>().intensity > 0)
        {
            phoneLight.GetComponent<Light>().intensity -= Time.deltaTime;
            yield return null;
        }

        if (phoneLight.GetComponent<Light>().intensity <= 0)
        {
            phoneLight.GetComponent<Light>().intensity = maxIntensity;

            yield return null;
        }

        yield return null;
    }

    IEnumerator FlashWhiteboard()
    {
        StartCoroutine(Whiteboard());
        yield return new WaitForSeconds(0.25f);
        Light();
    }

    IEnumerator FlashPC()
    {
        StartCoroutine(PC());
        yield return new WaitForSeconds(1f);
        Light();
    }

    IEnumerator FlashFax()
    {
        StartCoroutine(FaxAndBin());
        yield return new WaitForSeconds(1.25f);
        Light();
    }

    IEnumerator FlashBoard()
    {
        StartCoroutine(Board());
        yield return new WaitForSeconds(1.25f);
        Light();
    }

    IEnumerator FlashClock()
    {
        StartCoroutine(Clock());
        yield return new WaitForSeconds(1.25f);
        Light();
    }

    IEnumerator FlashFolder()
    {
        StartCoroutine(Folder());
        yield return new WaitForSeconds(1.25f);
        Light();
    }

    IEnumerator FlashPhone()
    {
        StartCoroutine(Phone());
        yield return new WaitForSeconds(1.25f);
        Light();
    }

    #endregion

    IEnumerator FolderOut(RotationScript rot)
    {
        policyIntractable = false;

        rot.enabled = true;

        yield return new WaitForSeconds(1.25f);

        folderScript = folderCamera.GetComponent<FolderScript>();

        rot.endPos = GameObject.Find(folderScript.planet + "FolderStartPos").transform;

        rot.enabled = false;
        folderScript.enabled = true;
        folder = true;

        FolderOn();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        folderScript.anim.Play("Open");

        this.transform.position = folderScript.playerSpawn.transform.position;

        folderCamera.SetActive(true);
        gameObject.SetActive(false);

        if (firstPolicy)
        {
            robotDialogueTrigger.TriggerRobotDialogue8();
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

    public void Load()
    {
        interactionScript.enabled = true;

        if (GameObject.Find("GameInfoObject DDL"))
        {
            GameObject.Destroy(GameObject.Find("Earth Folder"));
            GameObject.Destroy(GameObject.Find("Mars Folder"));
            GameObject.Destroy(GameObject.Find("Venus Folder"));
            GameObject.Destroy(GameObject.Find("GameInfoObject"));

            policyChoices.UpdatePolicies();
        }

        if(statsScript.day == 2)
        {
            robotDialogueTrigger.TriggerRobotDialogue2_1();
        }
        else if(statsScript.day == 3)
        {
            robotDialogueTrigger.TriggerRobotDialogue3_1();
        }
        else if (statsScript.day == 4)
        {
            robotDialogueTrigger.TriggerRobotDialogue4_1();
        }
        else if (statsScript.day == 5)
        {
            robotDialogueTrigger.TriggerRobotDialogue5_1();
        }

        this.enabled = false;
    }
}
