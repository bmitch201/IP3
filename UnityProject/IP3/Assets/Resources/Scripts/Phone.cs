﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    [Header("Phone Calls")]
    [TextArea(3, 154)]
    public string[] phoneCalls;
    public Text phoneCallText;

    [Header("Booleans")]
    public bool isRinging;
    public bool timeUntilRingTimerActive;
    public bool ringTimerActive;
    public bool stopAudio;
    public bool newAudio;
    public bool firstCall;
    public bool callMissed;
    public bool dayOne;
    public bool phoneIsActive = false;

    [Header ("Timers")]
    public float timer;
    public float ringTimer;

    [Header("Audio")]
    public AudioClip phoneRing;
    public AudioClip marsPhoneCall;
    public AudioClip earthPhoneCall;

    public List<float> faxChanges = new List<float>();
    public List<string> faxChangedNames = new List<string>();

    public List<float> binChanges = new List<float>();
    public List<string> binChangedNames = new List<string>();

    public int calls = 0;

    AudioSource audioSource;

    GameObject playerObj;
    GameObject gameInfoObj;

    InteractionScript interactionScript;
    Stats statsScript;
    DayOneScript dayOneScript;
    RobotDialogueTrigger robotDialogueTrigger;

    void Start()
    {
        //timeUntilRingTimerActive = true;
        ringTimerActive = false;
        isRinging = false;
        firstCall = true;

        playerObj = GameObject.FindGameObjectWithTag("Player");
        interactionScript = playerObj.GetComponent<InteractionScript>();

        gameInfoObj = GameObject.Find("GameInfoObject");
        statsScript = gameInfoObj.GetComponent<Stats>();
        dayOneScript = FindObjectOfType<DayOneScript>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();

        audioSource = GameObject.FindGameObjectWithTag("Phone").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dayOne)
        {
            if (dayOneScript.phoneActive == true)
            {   
                audioSource.clip = phoneRing;
                audioSource.Play();

                isRinging = true;
                //timeUntilRingTimerActive = false;

                if (firstCall)
                {                  
                    phoneCallText.GetComponent<Text>().text = phoneCalls[0];

                    faxChanges.Add(0.2f);
                    faxChanges.Add(10);
                    faxChanges.Add(-5);

                    faxChangedNames.Add("Revenue");
                    faxChangedNames.Add("Mars_Relationship");
                    faxChangedNames.Add("Public_Support");

                    binChanges.Add(-10);

                    binChangedNames.Add("Mars_Relationship");

                }
                else if (!firstCall)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[1];
                    ringTimerActive = true;

                    faxChanges.Add(10);
                    faxChanges.Add(-5);
                    faxChanges.Add(-5);

                    faxChangedNames.Add("Venus_Relationship");
                    faxChangedNames.Add("System_Tension");
                    faxChangedNames.Add("Autonomy");

                    binChanges.Add(-5);

                    binChangedNames.Add("Earth_Relationship");
                }

                calls++;
                dayOneScript.phoneActive = false;
            }
        }

        if (timeUntilRingTimerActive)
        {
            timer -= Time.deltaTime;           
        }
        
        if (timer < 0)
        {
            phoneIsActive = true;
            timeUntilRingTimerActive = false;
        }

        //if (phoneIsActive)
        //{
        //    if (statsScript.day == 2)
        //    {
        //        audioSource.clip = phoneRing;
        //        audioSource.Play();
        //        isRinging = true;
        //        ringTimerActive = true;
        //        phoneIsActive = false;

        //        if (firstCall)
        //        {
        //            phoneCallText.GetComponent<Text>().text = phoneCalls[1];
        //        }
        //        else
        //        {
        //            phoneCallText.GetComponent<Text>().text = phoneCalls[2];
        //        }               
        //    }
        //}

        if (ringTimerActive == true)
        {
            ringTimer -= Time.deltaTime;
        }

       if(ringTimer < 0)
       {
            //interactionScript.answered = false;
            statsScript.phone2Answered = false;
            ringTimerActive = false;
            isRinging = false;
            stopAudio = true;
            callMissed = true;
            firstCall = false;
            ringTimer = 15;
            if (dayOne)
            {
                statsScript.stats[5] -= 5;
                dayOneScript.phoneActive = false;
            }
            //statsScript.TimeForward();
        }

        if (dayOne)
        {
            if (dayOneScript.answered == true && newAudio == true)
            {
                isRinging = false;

                if (firstCall)
                {
                    audioSource.clip = marsPhoneCall;
                    audioSource.PlayOneShot(marsPhoneCall);
                }
                else
                {
                    audioSource.clip = earthPhoneCall;
                    audioSource.PlayOneShot(earthPhoneCall);
                }
                newAudio = false;
                dayOneScript.phoneActive = false;
                ringTimer = 15;
            }

            if (callMissed == true && stopAudio == true)
            {
                audioSource.Stop();
                callMissed = false;
                ringTimer = 15;
                dayOneScript.policyIntractable = true;
            }
        }

        //if (callMissed == true && stopAudio == true)
        //{
        //    audioSource.Stop();
        //    audioSource2.Stop();
        //    callMissed = false;
        //    statsScript.stats[7] -= 5;
        //    ringTimer = 15;
        //    timer = 7;
        //    timeUntilRingTimerActive = true;           
        //}

        if (stopAudio == true)
        {
            audioSource.Stop();
            stopAudio = false;
        }
    }
}