﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RobotDialogueManager : MonoBehaviour {

    public GameObject panel;

    public Text robotDialogueText;

    private Queue<string> robotSentences1;
    private Queue<string> robotSentences2;
    private Queue<string> robotSentences3;
    private Queue<string> robotSentences4;
    private Queue<string> robotSentences5;
    private Queue<string> robotSentences6;
    private Queue<string> robotSentences7;
    private Queue<string> robotSentences8;
    private Queue<string> robotSentences9;
    private Queue<string> robotSentences10;
    private Queue<string> robotSentences11;
    private Queue<string> robotSentences12;
    private Queue<string> robotSentences13;
    private Queue<string> robotSentences14;
    //private Queue<string> robotSentences15;
    //private Queue<string> robotSentences16;

    private Queue<string> robotSentences2_1;
    private Queue<string> robotSentences2_2;
    private Queue<string> robotSentences2_3;
    private Queue<string> robotSentences2_4;
    private Queue<string> robotSentences2_5;
    private Queue<string> robotSentences2_6;
    private Queue<string> robotSentences2_7;
    private Queue<string> robotSentences2_8;
    private Queue<string> robotSentences2_9;
    private Queue<string> robotSentences2_10;
    private Queue<string> robotSentences2_11;
    private Queue<string> robotSentences2_12;
    private Queue<string> robotSentences2_13;
    private Queue<string> robotSentences2_14;
    private Queue<string> robotSentences2_15;

    AudioSource robotAudioSource;

    public AudioClip[] robotClip1, robotClip2, robotClip3, robotClip4, robotClip5, robotClip6, robotClip7, robotClip8, robotClip9, robotClip10, robotClip11, robotClip12, robotClip13, robotClip14;//, robotClip15, robotClip16;

    private Queue<AudioClip> robotAudio1;
    private Queue<AudioClip> robotAudio2;
    private Queue<AudioClip> robotAudio3;
    private Queue<AudioClip> robotAudio4;
    private Queue<AudioClip> robotAudio5;
    private Queue<AudioClip> robotAudio6;
    private Queue<AudioClip> robotAudio7;
    private Queue<AudioClip> robotAudio8;
    private Queue<AudioClip> robotAudio9;
    private Queue<AudioClip> robotAudio10;
    private Queue<AudioClip> robotAudio11;
    private Queue<AudioClip> robotAudio12;
    private Queue<AudioClip> robotAudio13;
    private Queue<AudioClip> robotAudio14;
    //private Queue<AudioClip> robotAudio15;
    //private Queue<AudioClip> robotAudio16;

    bool dialogue1;
    bool dialogue2;
    bool dialogue3;
    bool dialogue4;
    bool dialogue5;
    bool dialogue6;
    bool dialogue7;
    bool dialogue8;
    bool dialogue9;
    bool dialogue10;
    bool dialogue11;
    bool dialogue12;
    bool dialogue13;
    bool dialogue14;
    //bool dialogue15;
    //bool dialogue16;

    bool dialogue2_1;
    bool dialogue2_2;
    bool dialogue2_3;
    bool dialogue2_4;
    bool dialogue2_5;
    bool dialogue2_6;
    bool dialogue2_7;
    bool dialogue2_8;
    bool dialogue2_9;
    bool dialogue2_10;
    bool dialogue2_11;
    bool dialogue2_12;
    bool dialogue2_13;
    bool dialogue2_14;
    bool dialogue2_15;

    public bool conferencePhoneRing = false;

    Stats statsScript;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    Phone phoneScript;

    float timerForDialogue = 5f;

    // Use this for initialization
    void Awake ()
    {
        robotDialogueTrigger = GameObject.Find("Robot").GetComponent<RobotDialogueTrigger>();
        dayOneScript = FindObjectOfType<DayOneScript>();
        phoneScript = FindObjectOfType<Phone>();
        robotAudioSource = GameObject.Find("Robot").GetComponent<AudioSource>();

        robotSentences1 = new Queue<string>();
        robotSentences2 = new Queue<string>();
        robotSentences3 = new Queue<string>();
        robotSentences4 = new Queue<string>();
        robotSentences5 = new Queue<string>();
        robotSentences6 = new Queue<string>();
        robotSentences7 = new Queue<string>();
        robotSentences8 = new Queue<string>();
        robotSentences9 = new Queue<string>();
        robotSentences10 = new Queue<string>();
        robotSentences11 = new Queue<string>();
        robotSentences12 = new Queue<string>();
        robotSentences13 = new Queue<string>();
        robotSentences14 = new Queue<string>();
        //robotSentences15 = new Queue<string>();
        //robotSentences16 = new Queue<string>();

        robotAudio1 = new Queue<AudioClip>();
        robotAudio2 = new Queue<AudioClip>();
        robotAudio3 = new Queue<AudioClip>();
        robotAudio4 = new Queue<AudioClip>();
        robotAudio5 = new Queue<AudioClip>();
        robotAudio6 = new Queue<AudioClip>();
        robotAudio7 = new Queue<AudioClip>();
        robotAudio8 = new Queue<AudioClip>();
        robotAudio9 = new Queue<AudioClip>();
        robotAudio10 = new Queue<AudioClip>();
        robotAudio11 = new Queue<AudioClip>();
        robotAudio12 = new Queue<AudioClip>();
        robotAudio13 = new Queue<AudioClip>();
        robotAudio14 = new Queue<AudioClip>();
        //robotAudio15 = new Queue<AudioClip>();
        //robotAudio16 = new Queue<AudioClip>();

        robotSentences2_1 = new Queue<string>();

    }

    void Start()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
    }

    #region DayOne

    public void StartRobotDialogue1(RobotDialogue robotDialogue)
    {
        dialogue1 = true;
        robotSentences1.Clear();
        robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences1)
        {
            robotSentences1.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip1)
        {
            robotAudio1.Enqueue(clip);
        }

        DisplayNextRobotSentence1();
    }

    public void DisplayNextRobotSentence1()
    {  
        if (robotSentences1.Count == 0)
        {
            EndRobotDialogue1();
            return;
        }

        string robotSentence1 = robotSentences1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence1));

        robotAudioSource.Stop();

        if (robotAudio1.Count > 0)
        {
            AudioClip robotAudio = robotAudio1.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    IEnumerator TypeSentence(string robotSentence)
    {
        robotDialogueText.text = "";
        foreach (char letter in robotSentence.ToCharArray())
        {
            robotDialogueText.text += letter;
            yield return null;
        }
    }

    public void EndRobotDialogue1()
    {
        dialogue1 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
        robotDialogueTrigger.TriggerRobotDialogue2();
    }

    public void StartRobotDialogue2(RobotDialogue robotDialogue)
    {
        dayOneScript.wbActive = true;
        dayOneScript.Light();

        dialogue2 = true;
        panel.SetActive(true);
        robotSentences1.Clear();
        robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2)
        {
            robotSentences2.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2)
        {
            robotAudio2.Enqueue(clip);
        }

        DisplayNextRobotSentence2();
    }

    public void DisplayNextRobotSentence2()
    {
        if (robotSentences2.Count == 0)
        {
            EndRobotDialogue2();
            return;
        }

        string robotSentence2 = robotSentences2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2));

        robotAudioSource.Stop();

        if (robotAudio2.Count > 0)
        {
            AudioClip robotAudio = robotAudio2.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2()
    {
        dialogue2 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue3(RobotDialogue robotDialogue)
    {
        dayOneScript.wbActive = false;
        dayOneScript.pcActive = true;
        dayOneScript.Light();

        dialogue3 = true;
        panel.SetActive(true);
        robotSentences2.Clear();
        robotAudio2.Clear();

        foreach (string sentence in robotDialogue.robotSentences3)
        {
            robotSentences3.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip3)
        {
            robotAudio3.Enqueue(clip);
        }

        DisplayNextRobotSentence3();
    }

    public void DisplayNextRobotSentence3()
    {
        if (robotSentences3.Count == 0)
        {
            EndRobotDialogue3();
            return;
        }

        string robotSentence3 = robotSentences3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence3));

        robotAudioSource.Stop();

        if (robotAudio3.Count > 0)
        {
            AudioClip robotAudio = robotAudio3.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue3()
    {
        dayOneScript.pcIntractable = true;
        dialogue3 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue4(RobotDialogue robotDialogue)
    {
        dayOneScript.boardActive = true;
        dayOneScript.Light();

        dialogue4 = true;
        panel.SetActive(true);
        robotSentences3.Clear();
        robotAudio3.Clear();

        foreach (string sentence in robotDialogue.robotSentences4)
        {
            robotSentences4.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip4)
        {
            robotAudio4.Enqueue(clip);
        }

        DisplayNextRobotSentence4();
    }

    public void DisplayNextRobotSentence4()
    {
        if (robotSentences4.Count == 0)
        {
            EndRobotDialogue4();
            return;
        }

        string robotSentence4 = robotSentences4.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence4));

        robotAudioSource.Stop();

        if (robotAudio4.Count > 0)
        {
            AudioClip robotAudio = robotAudio4.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue4()
    {
        dayOneScript.boardIntractable = true;

        dialogue4 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue5(RobotDialogue robotDialogue)
    {
        dayOneScript.faxActive = true;
        dayOneScript.Light();

        dialogue5 = true;
        panel.SetActive(true);
        robotSentences4.Clear();
        robotAudio4.Clear();

        foreach (string sentence in robotDialogue.robotSentences5)
        {
            robotSentences5.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip5)
        {
            robotAudio5.Enqueue(clip);
        }

        DisplayNextRobotSentence5();
    }

    public void DisplayNextRobotSentence5()
    {
        if (robotSentences5.Count == 0)
        {
            EndRobotDialogue5();
            return;
        }

        string robotSentence5 = robotSentences5.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence5));

        robotAudioSource.Stop();

        if (robotAudio5.Count > 0)
        {
            AudioClip robotAudio = robotAudio5.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue5()
    {
        dialogue5 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue6(RobotDialogue robotDialogue)
    {
        dayOneScript.clockActive = true;
        dayOneScript.Light();

        dialogue6 = true;
        panel.SetActive(true);
        robotSentences5.Clear();
        robotAudio5.Clear();

        foreach (string sentence in robotDialogue.robotSentences6)
        {
            robotSentences6.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip6)
        {
            robotAudio6.Enqueue(clip);
        }

        DisplayNextRobotSentence6();
    }

    public void DisplayNextRobotSentence6()
    {
        if (robotSentences6.Count == 0)
        {
            EndRobotDialogue6();
            return;
        }

        string robotSentence6 = robotSentences6.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence6));

        robotAudioSource.Stop();

        if (robotAudio6.Count > 0)
        {
            AudioClip robotAudio = robotAudio6.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue6()
    {
        dialogue6 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();

        dayOneScript.clockActive = false;
        robotDialogueTrigger.TriggerRobotDialogue7();
    }

    public void StartRobotDialogue7(RobotDialogue robotDialogue)
    {
        dayOneScript.policyActive = true;
        dayOneScript.Light();

        dialogue7 = true;
        panel.SetActive(true);
        robotSentences6.Clear();
        robotAudio6.Clear();

        foreach (string sentence in robotDialogue.robotSentences7)
        {
            robotSentences7.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip7)
        {
            robotAudio7.Enqueue(clip);
        }

        DisplayNextRobotSentence7();
    }

    public void DisplayNextRobotSentence7()
    {
        if (robotSentences7.Count == 0)
        {
            EndRobotDialogue7();
            return;
        }

        string robotSentence7 = robotSentences7.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence7));

        robotAudioSource.Stop();

        if (robotAudio7.Count > 0)
        {
            AudioClip robotAudio = robotAudio7.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue7()
    {
        dayOneScript.policyIntractable = true;
        dialogue7 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue8(RobotDialogue robotDialogue)
    {
        dayOneScript.policyActive = false;
        dayOneScript.Light();

        dialogue8 = true;
        panel.SetActive(true);
        robotSentences7.Clear();
        robotAudio7.Clear();

        foreach (string sentence in robotDialogue.robotSentences8)
        {
            robotSentences8.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip8)
        {
            robotAudio8.Enqueue(clip);
        }

        DisplayNextRobotSentence8();
    }

    public void DisplayNextRobotSentence8()
    {
        if (robotSentences8.Count == 0)
        {
            EndRobotDialogue8();
            return;
        }

        string robotSentence8 = robotSentences8.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence8));

        robotAudioSource.Stop();

        if (robotAudio8.Count > 0)
        {
            AudioClip robotAudio = robotAudio8.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue8()
    {
        dialogue8 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue9(RobotDialogue robotDialogue)
    {
        dialogue9 = true;
        panel.SetActive(true);
        robotSentences8.Clear();
        robotAudio8.Clear();

        foreach (string sentence in robotDialogue.robotSentences9)
        {
            robotSentences9.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip9)
        {
            robotAudio9.Enqueue(clip);
        }

        DisplayNextRobotSentence9();
    }

    public void DisplayNextRobotSentence9()
    {
        if (robotSentences9.Count == 0)
        {
            EndRobotDialogue9();
            return;
        }

        string robotSentence9 = robotSentences9.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence9));

        robotAudioSource.Stop();

        if (robotAudio9.Count > 0)
        {
            AudioClip robotAudio = robotAudio9.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue9()
    {
        dialogue9 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue10(RobotDialogue robotDialogue)
    {
        dayOneScript.phoneLActive = true;
        dayOneScript.Light();

        dialogue10 = true;
        panel.SetActive(true);
        robotSentences9.Clear();
        robotAudio9.Clear();

        foreach (string sentence in robotDialogue.robotSentences10)
        {
            robotSentences10.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip10)
        {
            robotAudio10.Enqueue(clip);
        }

        DisplayNextRobotSentence10();
    }

    public void DisplayNextRobotSentence10()
    {
        if (robotSentences10.Count == 0)
        {
            EndRobotDialogue10();
            return;
        }

        string robotSentence10 = robotSentences10.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence10));

        robotAudioSource.Stop();

        if (robotAudio10.Count > 0)
        {
            AudioClip robotAudio = robotAudio10.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue10()
    {
        dialogue10 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue11(RobotDialogue robotDialogue)
    {
        dayOneScript.phoneLActive = false;

        dialogue11 = true;
        panel.SetActive(true);
        robotSentences10.Clear();
        robotAudio10.Clear();

        foreach (string sentence in robotDialogue.robotSentences11)
        {
            robotSentences11.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip11)
        {
            robotAudio11.Enqueue(clip);
        }

        DisplayNextRobotSentence11();
    }

    public void DisplayNextRobotSentence11()
    {
        if (robotSentences11.Count == 0)
        {
            EndRobotDialogue11();
            return;
        }

        string robotSentence11 = robotSentences11.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence11));

        robotAudioSource.Stop();

        if (robotAudio11.Count > 0)
        {
            AudioClip robotAudio = robotAudio11.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue11()
    {
        dialogue11 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue12(RobotDialogue robotDialogue)
    {
        dayOneScript.policyIntractable = true;

        dialogue12 = true;
        panel.SetActive(true);
        robotSentences11.Clear();
        robotAudio11.Clear();

        foreach (string sentence in robotDialogue.robotSentences12)
        {
            robotSentences12.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip12)
        {
            robotAudio12.Enqueue(clip);
        }

        DisplayNextRobotSentence12();
    }

    public void DisplayNextRobotSentence12()
    {
        if (robotSentences12.Count == 0)
        {
            EndRobotDialogue12();
            return;
        }

        string robotSentence12 = robotSentences12.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence12));

        robotAudioSource.Stop();

        if (robotAudio12.Count > 0)
        {
            AudioClip robotAudio = robotAudio12.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue12()
    {
        robotAudioSource.Stop();

        dialogue12 = false;
        panel.SetActive(false);
    }

    public void StartRobotDialogue13(RobotDialogue robotDialogue)
    {
        dialogue13 = true;
        panel.SetActive(true);
        robotSentences12.Clear();
        robotAudio12.Clear();

        foreach (string sentence in robotDialogue.robotSentences13)
        {
            robotSentences13.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip13)
        {
            robotAudio13.Enqueue(clip);
        }

        DisplayNextRobotSentence13();
    }

    public void DisplayNextRobotSentence13()
    {
        if (robotSentences13.Count == 0)
        {
            EndRobotDialogue13();
            return;
        }

        string robotSentence13 = robotSentences13.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence13));

        robotAudioSource.Stop();

        if (robotAudio13.Count > 0)
        {
            AudioClip robotAudio = robotAudio13.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue13()
    {
        dayOneScript.conferenceCallInteractable = true;
        dialogue13 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    public void StartRobotDialogue14(RobotDialogue robotDialogue)
    {
        dialogue14 = true;
        panel.SetActive(true);
        robotSentences13.Clear();
        robotAudio13.Clear();
        dayOneScript.conferenceCallInteractable = false;

        foreach (string sentence in robotDialogue.robotSentences14)
        {
            robotSentences14.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip14)
        {
            robotAudio14.Enqueue(clip);
        }

        DisplayNextRobotSentence14();
    }

    public void DisplayNextRobotSentence14()
    {
        if (robotSentences14.Count == 0)
        {
            EndRobotDialogue14();
            return;
        }

        string robotSentence14 = robotSentences14.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence14));

        robotAudioSource.Stop();

        if (robotAudio14.Count > 0)
        {
            AudioClip robotAudio = robotAudio14.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue14()
    {
        dialogue14 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
        phoneScript.phoneIsActive = true;
        phoneScript.firstCall = true;

        GameObject.Find("GameInfoObject").name = "GameInfoObject DDL";
        GameObject.Find("Earth Folder").name = "Earth Folder DDL";
        GameObject.Find("Mars Folder").name = "Mars Folder DDL";
        GameObject.Find("Venus Folder").name = "Venus Folder DDL";

        DontDestroyOnLoad(GameObject.Find("GameInfoObject DDL"));
        DontDestroyOnLoad(GameObject.Find("Earth Folder DDL"));
        DontDestroyOnLoad(GameObject.Find("Mars Folder DDL"));
        DontDestroyOnLoad(GameObject.Find("Venus Folder DDL"));

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        statsScript.time = 9;
        statsScript.day++;
        SceneManager.LoadScene("End Of Day");
        statsScript.newDay = true;
    }

    //public void StartRobotDialogue15(RobotDialogue robotDialogue)
    //{
    //    dialogue15 = true;
    //    robotSentences14.Clear();
    //    robotAudio14.Clear();

    //    foreach (string sentence in robotDialogue.robotSentences15)
    //    {
    //        robotSentences15.Enqueue(sentence);
    //    }

    //    foreach (AudioClip clip in robotClip15)
    //    {
    //        robotAudio15.Enqueue(clip);
    //    }

    //    DisplayNextRobotSentence15();
    //}

    //public void DisplayNextRobotSentence15()
    //{
    //    if (robotSentences15.Count == 0)
    //    {
    //        EndRobotDialogue15();
    //        return;
    //    }

    //    string robotSentence = robotSentences15.Dequeue();
    //    StopAllCoroutines();
    //    StartCoroutine(TypeSentence(robotSentence));

    //    robotAudioSource.Stop();

    //    if (robotAudio15.Count > 0)
    //    {
    //        AudioClip robotAudio = robotAudio15.Dequeue();
    //        robotAudioSource.clip = robotAudio;
    //        robotAudioSource.PlayOneShot(robotAudio);
    //    }
    //}

    //public void EndRobotDialogue15()
    //{
    //    dialogue15 = false;
    //    panel.SetActive(false);
    //    robotAudioSource.Stop();
    //    robotDialogueTrigger.TriggerRobotDialogue16();
    //}

    //public void StartRobotDialogue16(RobotDialogue robotDialogue)
    //{
    //    dialogue16 = true;
    //    robotSentences15.Clear();
    //    robotAudio15.Clear();

    //    foreach (string sentence in robotDialogue.robotSentences16)
    //    {
    //        robotSentences16.Enqueue(sentence);
    //    }

    //    foreach (AudioClip clip in robotClip16)
    //    {
    //        robotAudio16.Enqueue(clip);
    //    }

    //    DisplayNextRobotSentence16();
    //}

    //public void DisplayNextRobotSentence16()
    //{
    //    if (robotSentences16.Count == 0)
    //    {
    //        EndRobotDialogue16();
    //        return;
    //    }

    //    string robotSentence = robotSentences16.Dequeue();
    //    StopAllCoroutines();
    //    StartCoroutine(TypeSentence(robotSentence));

    //    robotAudioSource.Stop();

    //    if (robotAudio16.Count > 0)
    //    {
    //        AudioClip robotAudio = robotAudio16.Dequeue();
    //        robotAudioSource.clip = robotAudio;
    //        robotAudioSource.PlayOneShot(robotAudio);
    //    }
    //}

    //public void EndRobotDialogue16()
    //{
    //    dialogue16 = false;
    //    panel.SetActive(false);
    //    robotAudioSource.Stop();
    //    phoneScript.phoneIsActive = true;
    //    phoneScript.firstCall = true;
    //}

    #endregion

    #region DayTwo

    public void StartRobotDialogue2_1(RobotDialogue robotDialogue)
    {
        dialogue2_1 = true;
        panel.SetActive(true);
        robotSentences2_1.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_1)
        {
            robotSentences2_1.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_1();
    }

    public void DisplayNextRobotSentence2_1()
    {
        if (robotSentences2_1.Count == 0)
        {
            EndRobotDialogue2_1();
            return;
        }

        string robotSentence2_1 = robotSentences2_1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_1));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_1()
    {
        dialogue2_1 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_2(RobotDialogue robotDialogue)
    {
        dialogue2_2 = true;
        panel.SetActive(true);
        robotSentences2_2.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_2)
        {
            robotSentences2_2.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_2();
    }

    public void DisplayNextRobotSentence2_2()
    {
        if (robotSentences2_2.Count == 0)
        {
            EndRobotDialogue2_2();
            return;
        }

        string robotSentence2_2 = robotSentences2_2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_2));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_2()
    {
        dialogue2_2 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_3(RobotDialogue robotDialogue)
    {
        dialogue2_3 = true;
        panel.SetActive(true);
        robotSentences2_3.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_3)
        {
            robotSentences2_3.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_3();
    }

    public void DisplayNextRobotSentence2_3()
    {
        if (robotSentences2_3.Count == 0)
        {
            EndRobotDialogue2_3();
            return;
        }

        string robotSentence2_3 = robotSentences2_3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_3));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_3()
    {
        dialogue2_3 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_4(RobotDialogue robotDialogue)
    {
        dialogue2_4 = true;
        panel.SetActive(true);
        robotSentences2_3.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_4)
        {
            robotSentences2_4.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_4();
    }

    public void DisplayNextRobotSentence2_4()
    {
        if (robotSentences2_4.Count == 0)
        {
            EndRobotDialogue2_4();
            return;
        }

        string robotSentence2_4 = robotSentences2_4.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_4));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_4()
    {
        dialogue2_4 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_5(RobotDialogue robotDialogue)
    {
        dialogue2_5 = true;
        panel.SetActive(true);
        robotSentences2_4.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_5)
        {
            robotSentences2_5.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_5();
    }

    public void DisplayNextRobotSentence2_5()
    {
        if (robotSentences2_5.Count == 0)
        {
            EndRobotDialogue2_5();
            return;
        }

        string robotSentence2_5 = robotSentences2_5.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_5));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_5()
    {
        dialogue2_5 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_6(RobotDialogue robotDialogue)
    {
        dialogue2_6 = true;
        panel.SetActive(true);
        robotSentences2_5.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_6)
        {
            robotSentences2_6.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_6();
    }

    public void DisplayNextRobotSentence2_6()
    {
        if (robotSentences2_6.Count == 0)
        {
            EndRobotDialogue2_6();
            return;
        }

        string robotSentence2_6 = robotSentences2_6.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_6));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_6()
    {
        dialogue2_6 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_7(RobotDialogue robotDialogue)
    {
        dialogue2_7 = true;
        panel.SetActive(true);
        robotSentences2_6.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_7)
        {
            robotSentences2_7.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_7();
    }

    public void DisplayNextRobotSentence2_7()
    {
        if (robotSentences2_7.Count == 0)
        {
            EndRobotDialogue2_7();
            return;
        }

        string robotSentence2_7 = robotSentences2_7.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_7));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_7()
    {
        dialogue2_7 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_8(RobotDialogue robotDialogue)
    {
        dialogue2_8 = true;
        panel.SetActive(true);
        robotSentences2_7.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_8)
        {
            robotSentences2_8.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_8();
    }

    public void DisplayNextRobotSentence2_8()
    {
        if (robotSentences2_8.Count == 0)
        {
            EndRobotDialogue2_8();
            return;
        }

        string robotSentence2_8 = robotSentences2_8.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_8));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_8()
    {
        dialogue2_8 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_9(RobotDialogue robotDialogue)
    {
        dialogue2_9 = true;
        panel.SetActive(true);
        robotSentences2_8.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_9)
        {
            robotSentences2_9.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_9();
    }

    public void DisplayNextRobotSentence2_9()
    {
        if (robotSentences2_9.Count == 0)
        {
            EndRobotDialogue2_9();
            return;
        }

        string robotSentence2_9 = robotSentences2_9.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_9));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_9()
    {
        dialogue2_9 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_10(RobotDialogue robotDialogue)
    {
        dialogue2_10 = true;
        panel.SetActive(true);
        robotSentences2_9.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_10)
        {
            robotSentences2_10.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_10();
    }

    public void DisplayNextRobotSentence2_10()
    {
        if (robotSentences2_10.Count == 0)
        {
            EndRobotDialogue2_10();
            return;
        }

        string robotSentence2_10 = robotSentences2_10.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_10));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_10()
    {
        dialogue2_10 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_11(RobotDialogue robotDialogue)
    {
        dialogue2_11 = true;
        panel.SetActive(true);
        robotSentences2_10.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_11)
        {
            robotSentences2_11.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_11();
    }

    public void DisplayNextRobotSentence2_11()
    {
        if (robotSentences2_11.Count == 0)
        {
            EndRobotDialogue2_11();
            return;
        }

        string robotSentence2_11 = robotSentences2_11.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_11));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_11()
    {
        dialogue2_11 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_12(RobotDialogue robotDialogue)
    {
        dialogue2_12 = true;
        panel.SetActive(true);
        robotSentences2_11.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_12)
        {
            robotSentences2_12.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_12();
    }

    public void DisplayNextRobotSentence2_12()
    {
        if (robotSentences2_12.Count == 0)
        {
            EndRobotDialogue2_12();
            return;
        }

        string robotSentence2_12 = robotSentences2_12.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_12));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_12()
    {
        dialogue2_12 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_13(RobotDialogue robotDialogue)
    {
        dialogue2_13 = true;
        panel.SetActive(true);
        robotSentences2_12.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_13)
        {
            robotSentences2_13.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_13();
    }

    public void DisplayNextRobotSentence2_13()
    {
        if (robotSentences2_13.Count == 0)
        {
            EndRobotDialogue2_13();
            return;
        }

        string robotSentence2_13 = robotSentences2_13.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_13));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_13()
    {
        dialogue2_13 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_14(RobotDialogue robotDialogue)
    {
        dialogue2_14 = true;
        panel.SetActive(true);
        robotSentences2_13.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_14)
        {
            robotSentences2_14.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_14();
    }

    public void DisplayNextRobotSentence2_14()
    {
        if (robotSentences2_14.Count == 0)
        {
            EndRobotDialogue2_14();
            return;
        }

        string robotSentence2_14 = robotSentences2_14.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_14));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_14()
    {
        dialogue2_14 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_15(RobotDialogue robotDialogue)
    {
        dialogue2_15 = true;
        panel.SetActive(true);
        robotSentences2_14.Clear();
        //robotAudio1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_15)
        {
            robotSentences2_15.Enqueue(sentence);
        }

        //foreach (AudioClip clip in robotClip2)
        //{
        //    robotAudio2.Enqueue(clip);
        //}

        DisplayNextRobotSentence2_15();
    }

    public void DisplayNextRobotSentence2_15()
    {
        if (robotSentences2_4.Count == 0)
        {
            EndRobotDialogue2_15();
            return;
        }

        string robotSentence2_15 = robotSentences2_15.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_15));

        //robotAudioSource.Stop();

        //if (robotAudio2.Count > 0)
        //{
        //    AudioClip robotAudio = robotAudio2.Dequeue();
        //    robotAudioSource.clip = robotAudio;
        //    robotAudioSource.PlayOneShot(robotAudio);
        //}
    }

    public void EndRobotDialogue2_15()
    {
        dialogue2_15 = false;
        //robotAudioSource.Stop();
        panel.SetActive(false);
    }

    #endregion

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue1)
            {
                DisplayNextRobotSentence1();
            }
            else if (dialogue2)
            {
                DisplayNextRobotSentence2();
            }
            else if (dialogue3)
            {
                DisplayNextRobotSentence3();
            }
            else if (dialogue4)
            {
                DisplayNextRobotSentence4();
            }
            else if (dialogue5)
            {
                DisplayNextRobotSentence5();
            }
            else if (dialogue6)
            {
                DisplayNextRobotSentence6();
            }
            else if (dialogue7)
            {
                DisplayNextRobotSentence7();
            }
            else if (dialogue8)
            {
                DisplayNextRobotSentence8();
            }
            else if (dialogue9)
            {
                DisplayNextRobotSentence9();
            }
            else if (dialogue10)
            {
                DisplayNextRobotSentence10();
            }
            else if (dialogue11)
            {
                DisplayNextRobotSentence11();
            }
            else if (dialogue12)
            {
                DisplayNextRobotSentence12();
            }
            else if (dialogue13)
            {
                DisplayNextRobotSentence13();
            }
            else if (dialogue14)
            {
                DisplayNextRobotSentence14();
            }
            //else if (dialogue15)
            //{
            //    DisplayNextRobotSentence15();

            //    if(timerForDialogue > 0)
            //    {
            //        timerForDialogue -= Time.deltaTime;
            //    }
            //    else
            //    {
            //        robotDialogueTrigger.TriggerRobotDialogue16();
            //        timerForDialogue = 5f;
            //    }
            //}
            //else if (dialogue16)
            //{
            //    DisplayNextRobotSentence16();
            //}
        }

        if (dayOneScript.wbActive == true)
        {
            if (timerForDialogue > 0)
            {
                timerForDialogue -= Time.deltaTime;
            }
            else
            {
                robotDialogueTrigger.TriggerRobotDialogue3();
                timerForDialogue = 5f;
            }
        }

        if(dayOneScript.faxActive == true)
        {
            if(timerForDialogue > 0)
            {
                timerForDialogue -= Time.deltaTime;
            }
            else
            {
                dayOneScript.faxActive = false;
                robotDialogueTrigger.TriggerRobotDialogue6();
                timerForDialogue = 5f;
            }
        }

        //if (dayOneScript.clockActive == true)
        //{
        //    if (timerForDialogue > 0)
        //    {
        //        timerForDialogue -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        dayOneScript.clockActive = false;
        //        robotDialogueTrigger.TriggerRobotDialogue7();
        //        timerForDialogue = 5f;
        //    }
        //}
    }
}