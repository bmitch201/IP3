using System.Collections;
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

    private Queue<string> robotSentences3_1;
    private Queue<string> robotSentences3_2;
    private Queue<string> robotSentences3_3;
    private Queue<string> robotSentences3_4;
    private Queue<string> robotSentences3_5;
    private Queue<string> robotSentences3_6;

    private Queue<string> robotSentences4_1;
    private Queue<string> robotSentences4_2;
    private Queue<string> robotSentences4_3;
    private Queue<string> robotSentences4_4;
    private Queue<string> robotSentences4_5;

    private Queue<string> robotSentences5_1;
    private Queue<string> robotSentences5_2;

    AudioSource robotAudioSource;

    [Header("Day One Audio")]
    public AudioClip[] robotClip1;
    public AudioClip[] robotClip2;
    public AudioClip[] robotClip3;
    public AudioClip[] robotClip4;
    public AudioClip[] robotClip5;
    public AudioClip[] robotClip6;
    public AudioClip[] robotClip7;
    public AudioClip[] robotClip8;
    public AudioClip[] robotClip9;
    public AudioClip[] robotClip10;
    public AudioClip[] robotClip11;
    public AudioClip[] robotClip12;
    public AudioClip[] robotClip13;
    public AudioClip[] robotClip14;

    [Header("Day Two Audio")]
    public AudioClip[] robotClip2_1;
    public AudioClip[] robotClip2_2;
    public AudioClip[] robotClip2_3;
    public AudioClip[] robotClip2_4;
    public AudioClip[] robotClip2_5;
    public AudioClip[] robotClip2_6;
    public AudioClip[] robotClip2_7;
    public AudioClip[] robotClip2_8;
    public AudioClip[] robotClip2_9;
    public AudioClip[] robotClip2_10;
    public AudioClip[] robotClip2_11;
    public AudioClip[] robotClip2_12;
    public AudioClip[] robotClip2_13;
    public AudioClip[] robotClip2_14;
    public AudioClip[] robotClip2_15;

    [Header("Day Three Audio")]
    public AudioClip[] robotClip3_1;
    public AudioClip[] robotClip3_2;
    public AudioClip[] robotClip3_3;
    public AudioClip[] robotClip3_4;
    public AudioClip[] robotClip3_5;
    public AudioClip[] robotClip3_6;

    [Header("Day Four Audio")]
    public AudioClip[] robotClip4_1;
    public AudioClip[] robotClip4_2;
    public AudioClip[] robotClip4_3;
    public AudioClip[] robotClip4_4;
    public AudioClip[] robotClip4_5;

    [Header("Day Five Audio")]
    public AudioClip[] robotClip5_1;
    public AudioClip[] robotClip5_2;

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

    private Queue<AudioClip> robotAudio2_1;
    private Queue<AudioClip> robotAudio2_2;
    private Queue<AudioClip> robotAudio2_3;
    private Queue<AudioClip> robotAudio2_4;
    private Queue<AudioClip> robotAudio2_5;
    private Queue<AudioClip> robotAudio2_6;
    private Queue<AudioClip> robotAudio2_7;
    private Queue<AudioClip> robotAudio2_8;
    private Queue<AudioClip> robotAudio2_9;
    private Queue<AudioClip> robotAudio2_10;
    private Queue<AudioClip> robotAudio2_11;
    private Queue<AudioClip> robotAudio2_12;
    private Queue<AudioClip> robotAudio2_13;
    private Queue<AudioClip> robotAudio2_14;
    private Queue<AudioClip> robotAudio2_15;

    private Queue<AudioClip> robotAudio3_1;
    private Queue<AudioClip> robotAudio3_2;
    private Queue<AudioClip> robotAudio3_3;
    private Queue<AudioClip> robotAudio3_4;
    private Queue<AudioClip> robotAudio3_5;
    private Queue<AudioClip> robotAudio3_6;

    private Queue<AudioClip> robotAudio4_1;
    private Queue<AudioClip> robotAudio4_2;
    private Queue<AudioClip> robotAudio4_3;
    private Queue<AudioClip> robotAudio4_4;
    private Queue<AudioClip> robotAudio4_5;

    private Queue<AudioClip> robotAudio5_1;
    private Queue<AudioClip> robotAudio5_2;

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

    bool dialogue3_1;
    bool dialogue3_2;
    bool dialogue3_3;
    bool dialogue3_4;
    bool dialogue3_5;
    bool dialogue3_6;

    bool dialogue4_1;
    bool dialogue4_2;
    bool dialogue4_3;
    bool dialogue4_4;
    bool dialogue4_5;

    bool dialogue5_1;
    bool dialogue5_2;

    public bool conferencePhoneRing = false;
    bool timer1 = false;
    bool timer2 = false;
    bool timer3 = false;
    bool timer4 = false;

    public Stats statsScript;
    public ChairCameraScript chairCameraScript;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    InteractionScript interactionScript;
    Phone phoneScript;

    float timerForDialogue = 5f;

    // Use this for initialization
    void Awake ()
    {
        robotDialogueTrigger = GameObject.Find("Robot").GetComponent<RobotDialogueTrigger>();
        dayOneScript = FindObjectOfType<DayOneScript>();
        interactionScript = FindObjectOfType<InteractionScript>();
        phoneScript = FindObjectOfType<Phone>();

        robotAudioSource = GameObject.Find("Robot").GetComponent<AudioSource>();
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        panel = GameObject.Find("RobotPanel");

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

        robotSentences2_1 = new Queue<string>();
        robotSentences2_2 = new Queue<string>();
        robotSentences2_3 = new Queue<string>();
        robotSentences2_4 = new Queue<string>();
        robotSentences2_5 = new Queue<string>();
        robotSentences2_6 = new Queue<string>();
        robotSentences2_7 = new Queue<string>();
        robotSentences2_8 = new Queue<string>();
        robotSentences2_9 = new Queue<string>();
        robotSentences2_10 = new Queue<string>();
        robotSentences2_11 = new Queue<string>();
        robotSentences2_12 = new Queue<string>();
        robotSentences2_13 = new Queue<string>();
        robotSentences2_14 = new Queue<string>();
        robotSentences2_15 = new Queue<string>();

        robotSentences3_1 = new Queue<string>();
        robotSentences3_2 = new Queue<string>();
        robotSentences3_3 = new Queue<string>();
        robotSentences3_4 = new Queue<string>();
        robotSentences3_5 = new Queue<string>();
        robotSentences3_6 = new Queue<string>();

        robotSentences4_1 = new Queue<string>();
        robotSentences4_2 = new Queue<string>();
        robotSentences4_3 = new Queue<string>();
        robotSentences4_4 = new Queue<string>();
        robotSentences4_5 = new Queue<string>();

        robotSentences5_1 = new Queue<string>();
        robotSentences5_2 = new Queue<string>();


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

        robotAudio2_1 = new Queue<AudioClip>();
        robotAudio2_2 = new Queue<AudioClip>();
        robotAudio2_3 = new Queue<AudioClip>();
        robotAudio2_4 = new Queue<AudioClip>();
        robotAudio2_5 = new Queue<AudioClip>();
        robotAudio2_6 = new Queue<AudioClip>();
        robotAudio2_7 = new Queue<AudioClip>();
        robotAudio2_8 = new Queue<AudioClip>();
        robotAudio2_9 = new Queue<AudioClip>();
        robotAudio2_10 = new Queue<AudioClip>();
        robotAudio2_11 = new Queue<AudioClip>();
        robotAudio2_12 = new Queue<AudioClip>();
        robotAudio2_13 = new Queue<AudioClip>();
        robotAudio2_14 = new Queue<AudioClip>();
        robotAudio2_15 = new Queue<AudioClip>();

        robotAudio3_1 = new Queue<AudioClip>();
        robotAudio3_2 = new Queue<AudioClip>();
        robotAudio3_3 = new Queue<AudioClip>();
        robotAudio3_4 = new Queue<AudioClip>();
        robotAudio3_5 = new Queue<AudioClip>();
        robotAudio3_6 = new Queue<AudioClip>();

        robotAudio4_1 = new Queue<AudioClip>();
        robotAudio4_2 = new Queue<AudioClip>();
        robotAudio4_3 = new Queue<AudioClip>();
        robotAudio4_4 = new Queue<AudioClip>();
        robotAudio4_5 = new Queue<AudioClip>();

        robotAudio5_1 = new Queue<AudioClip>();
        robotAudio5_2 = new Queue<AudioClip>();
    }

    void Start()
    {
        
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
        timer1 = true;
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
        //dayOneScript.Light();

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

        timer3 = true;
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
        timer2 = true;
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

        statsScript.time--;

        //GameObject.Find("GameInfoObject").name = "GameInfoObject DDL";
        //GameObject.Find("Earth Folder").name = "Earth Folder DDL";
        //GameObject.Find("Mars Folder").name = "Mars Folder DDL";
        //GameObject.Find("Venus Folder").name = "Venus Folder DDL";

        //DontDestroyOnLoad(GameObject.Find("GameInfoObject DDL"));
        //DontDestroyOnLoad(GameObject.Find("Earth Folder DDL"));
        //DontDestroyOnLoad(GameObject.Find("Mars Folder DDL"));
        //DontDestroyOnLoad(GameObject.Find("Venus Folder DDL"));

        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        //phoneScript.dayOne = false;
        //statsScript.time = 10;
        //statsScript.day++;
        //SceneManager.LoadScene("End Of Day");
        //statsScript.newDay = true;
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
        robotAudio2_1.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_1)
        {
            robotSentences2_1.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_1)
        {
            robotAudio2_1.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_1.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_1.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_1()
    {
        dialogue2_1 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        phoneScript.phoneIsActive = true;
        timerForDialogue = 2f;
        timer1 = true;
    }

    public void StartRobotDialogue2_2(RobotDialogue robotDialogue)
    {
        dialogue2_2 = true;
        panel.SetActive(true);
        robotSentences2_1.Clear();
        robotAudio2_2.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_2)
        {
            robotSentences2_2.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_2)
        {
            robotAudio2_2.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_2.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_2.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_2()
    {
        dialogue2_2 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        interactionScript.phoneInteractable = true;
    }

    public void StartRobotDialogue2_3(RobotDialogue robotDialogue)
    {
        dialogue2_3 = true;
        panel.SetActive(true);
        robotSentences2_3.Clear();
        robotAudio2_3.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_3)
        {
            robotSentences2_3.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_3)
        {
            robotAudio2_3.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_3.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_3.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_3()
    {
        dialogue2_3 = false;
        robotAudioSource.Stop();
        statsScript.Family();
        chairCameraScript.moonFolderFirst = true;
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_4(RobotDialogue robotDialogue)
    {
        dialogue2_4 = true;
        panel.SetActive(true);
        robotSentences2_3.Clear();
        robotAudio2_4.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_4)
        {
            robotSentences2_4.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_4)
        {
            robotAudio2_4.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_4.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_4.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_4()
    {
        dialogue2_4 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        robotDialogueTrigger.TriggerRobotDialogue2_5();
    }

    public void StartRobotDialogue2_5(RobotDialogue robotDialogue)
    {
        dialogue2_5 = true;
        panel.SetActive(true);
        robotSentences2_4.Clear();
        robotAudio2_5.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_5)
        {
            robotSentences2_5.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_5)
        {
            robotAudio2_5.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_5.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_5.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_5()
    {
        dialogue2_5 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_6(RobotDialogue robotDialogue)
    {
        dialogue2_6 = true;
        panel.SetActive(true);
        robotSentences2_5.Clear();
        robotAudio2_6.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_6)
        {
            robotSentences2_6.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_6)
        {
            robotAudio2_6.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_6.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_6.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_6()
    {
        dialogue2_6 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_7(RobotDialogue robotDialogue)
    {
        dialogue2_7 = true;
        panel.SetActive(true);
        robotSentences2_6.Clear();
        robotAudio2_7.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_7)
        {
            robotSentences2_7.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_7)
        {
            robotAudio2.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_7.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_7.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_7()
    {
        dialogue2_7 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        timer2 = true;
    }

    public void StartRobotDialogue2_8(RobotDialogue robotDialogue)
    {
        dialogue2_8 = true;
        panel.SetActive(true);
        robotSentences2_7.Clear();
        robotAudio2_8.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_8)
        {
            robotSentences2_8.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_8)
        {
            robotAudio2_8.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_8.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_8.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_8()
    {
        dialogue2_8 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_9(RobotDialogue robotDialogue)
    {
        dialogue2_9 = true;
        panel.SetActive(true);
        robotSentences2_8.Clear();
        robotAudio2_9.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_9)
        {
            robotSentences2_9.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_9)
        {
            robotAudio2_9.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_9.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_9.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_9()
    {
        dialogue2_9 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_10(RobotDialogue robotDialogue)
    {
        dialogue2_10 = true;
        panel.SetActive(true);
        robotSentences2_9.Clear();
        robotAudio2_10.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_10)
        {
            robotSentences2_10.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_10)
        {
            robotAudio2_10.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_10.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_10.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_10()
    {
        dialogue2_10 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        interactionScript.folderInteractable = true;
    }

    public void StartRobotDialogue2_11(RobotDialogue robotDialogue)
    {
        dialogue2_11 = true;
        panel.SetActive(true);
        robotSentences2_10.Clear();
        robotAudio2_11.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_11)
        {
            robotSentences2_11.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_11)
        {
            robotAudio2_11.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_11.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_11.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_11()
    {
        dialogue2_11 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_12(RobotDialogue robotDialogue)
    {
        dialogue2_12 = true;
        panel.SetActive(true);
        robotSentences2_11.Clear();
        robotAudio2_12.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_12)
        {
            robotSentences2_12.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_12)
        {
            robotAudio2_12.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_12.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_12.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_12()
    {
        dialogue2_12 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        interactionScript.phoneInteractable = true;
    }

    public void StartRobotDialogue2_13(RobotDialogue robotDialogue)
    {
        dialogue2_13 = true;
        panel.SetActive(true);
        robotSentences2_12.Clear();
        robotAudio2_13.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_13)
        {
            robotSentences2_13.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_13)
        {
            robotAudio2_13.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_13.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_13.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_13()
    {
        dialogue2_13 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_14(RobotDialogue robotDialogue)
    {
        dialogue2_14 = true;
        panel.SetActive(true);
        robotSentences2_13.Clear();
        robotAudio2_14.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_14)
        {
            robotSentences2_14.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_14)
        {
            robotAudio2_14.Enqueue(clip);
        }

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

        robotAudioSource.Stop();

        if (robotAudio2_14.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_14.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_14()
    {
        dialogue2_14 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue2_15(RobotDialogue robotDialogue)
    {
        dialogue2_15 = true;
        panel.SetActive(true);
        robotSentences2_14.Clear();
        robotAudio2_15.Clear();

        foreach (string sentence in robotDialogue.robotSentences2_15)
        {
            robotSentences2_15.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip2_15)
        {
            robotAudio2_15.Enqueue(clip);
        }

        DisplayNextRobotSentence2_15();
    }

    public void DisplayNextRobotSentence2_15()
    {
        if (robotSentences2_15.Count == 0)
        {
            EndRobotDialogue2_15();
            return;
        }

        string robotSentence2_15 = robotSentences2_15.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence2_15));

        robotAudioSource.Stop();

        if (robotAudio2_15.Count > 0)
        {
            AudioClip robotAudio = robotAudio2_15.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue2_15()
    {
        statsScript.time= statsScript.time - 1;

        dialogue2_15 = false;
        panel.SetActive(false);
        robotAudioSource.Stop();
    }

    #endregion

    #region Day Three

    public void StartRobotDialogue3_1(RobotDialogue robotDialogue)
    {
        dialogue3_1 = true;
        panel.SetActive(true);
        robotSentences3_1.Clear();
        robotAudio3_1.Clear();

        foreach (string sentence in robotDialogue.robotSentences3_1)
        {
            robotSentences3_1.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip3_1)
        {
            robotAudio3_1.Enqueue(clip);
        }

        DisplayNextRobotSentence3_1();
    }

    public void DisplayNextRobotSentence3_1()
    {
        if (robotSentences3_1.Count == 0)
        {
            EndRobotDialogue3_1();
            return;
        }

        string robotSentence = robotSentences3_1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio3_1.Count > 0)
        {
            AudioClip robotAudio = robotAudio3_1.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue3_1()
    {
        dialogue3_1 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        phoneScript.phoneIsActive = true;
        timerForDialogue = 1.5f;
        timer3 = true;
    }

    public void StartRobotDialogue3_2(RobotDialogue robotDialogue)
    {
        dialogue3_2 = true;
        panel.SetActive(true);
        robotSentences3_2.Clear();
        robotAudio3_2.Clear();

        foreach (string sentence in robotDialogue.robotSentences3_2)
        {
            robotSentences3_2.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip3_2)
        {
            robotAudio3_2.Enqueue(clip);
        }

        DisplayNextRobotSentence3_2();
    }

    public void DisplayNextRobotSentence3_2()
    {
        if (robotSentences3_2.Count == 0)
        {
            EndRobotDialogue3_2();
            return;
        }

        string robotSentence = robotSentences3_2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio3_2.Count > 0)
        {
            AudioClip robotAudio = robotAudio3_2.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue3_2()
    {
        dialogue3_2 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        interactionScript.phoneInteractable = true;
    }

    public void StartRobotDialogue3_3(RobotDialogue robotDialogue)
    {
        dialogue3_3 = true;
        panel.SetActive(true);
        robotSentences3_3.Clear();
        robotAudio3_3.Clear();

        foreach (string sentence in robotDialogue.robotSentences3_3)
        {
            robotSentences3_3.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip3_3)
        {
            robotAudio3_3.Enqueue(clip);
        }

        DisplayNextRobotSentence3_3();
    }

    public void DisplayNextRobotSentence3_3()
    {
        if (robotSentences3_3.Count == 0)
        {
            EndRobotDialogue3_3();
            return;
        }

        string robotSentence = robotSentences3_3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio3_3.Count > 0)
        {
            AudioClip robotAudio = robotAudio3_3.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue3_3()
    {
        dialogue3_3 = false;
        statsScript.Family();
        robotAudioSource.Stop();
        panel.SetActive(false);
        timerForDialogue = 1.5f;
        timer4 = true;
    }

    public void StartRobotDialogue3_4(RobotDialogue robotDialogue)
    {
        dialogue3_4 = true;
        panel.SetActive(true);
        robotSentences3_4.Clear();
        robotAudio3_4.Clear();

        foreach (string sentence in robotDialogue.robotSentences3_4)
        {
            robotSentences3_4.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip3_4)
        {
            robotAudio3_4.Enqueue(clip);
        }

        DisplayNextRobotSentence3_4();
    }

    public void DisplayNextRobotSentence3_4()
    {
        if (robotSentences3_4.Count == 0)
        {
            EndRobotDialogue3_4();
            return;
        }

        string robotSentence = robotSentences3_4.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio3_4.Count > 0)
        {
            AudioClip robotAudio = robotAudio3_4.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue3_4()
    {
        dialogue3_4 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue3_5(RobotDialogue robotDialogue)
    {
        dialogue3_5 = true;
        panel.SetActive(true);
        robotSentences3_5.Clear();
        robotAudio3_5.Clear();

        foreach (string sentence in robotDialogue.robotSentences3_5)
        {
            robotSentences3_5.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip3_5)
        {
            robotAudio3_5.Enqueue(clip);
        }

        DisplayNextRobotSentence3_5();
    }

    public void DisplayNextRobotSentence3_5()
    {
        if (robotSentences3_5.Count == 0)
        {
            EndRobotDialogue3_5();
            return;
        }

        string robotSentence = robotSentences3_5.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio3_5.Count > 0)
        {
            AudioClip robotAudio = robotAudio3_5.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue3_5()
    {
        dialogue3_5 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue3_6(RobotDialogue robotDialogue)
    {
        dialogue3_6 = true;
        panel.SetActive(true);
        robotSentences3_6.Clear();
        robotAudio3_6.Clear();

        foreach (string sentence in robotDialogue.robotSentences3_6)
        {
            robotSentences3_6.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip3_6)
        {
            robotAudio3_6.Enqueue(clip);
        }

        DisplayNextRobotSentence3_6();
    }

    public void DisplayNextRobotSentence3_6()
    {
        if (robotSentences3_6.Count == 0)
        {
            EndRobotDialogue3_6();
            return;
        }

        string robotSentence = robotSentences3_6.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio3_6.Count > 0)
        {
            AudioClip robotAudio = robotAudio3_6.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue3_6()
    {
        dialogue3_6 = false;
        interactionScript.door = true;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    #endregion

    #region Day Four

    public void StartRobotDialogue4_1(RobotDialogue robotDialogue)
    {
        dialogue4_1 = true;
        panel.SetActive(true);
        robotSentences4_1.Clear();
        robotAudio4_1.Clear();

        foreach (string sentence in robotDialogue.robotSentences4_1)
        {
            robotSentences4_1.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip4_1)
        {
            robotAudio4_1.Enqueue(clip);
        }

        DisplayNextRobotSentence4_1();
    }

    public void DisplayNextRobotSentence4_1()
    {
        if (robotSentences4_1.Count == 0)
        {
            EndRobotDialogue4_1();
            return;
        }

        string robotSentence = robotSentences4_1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio4_1.Count > 0)
        {
            AudioClip robotAudio = robotAudio4_1.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue4_1()
    {
        dialogue4_1 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        timerForDialogue = 2f;
        timer1 = true;
    }

    public void StartRobotDialogue4_2(RobotDialogue robotDialogue)
    {
        dialogue4_2 = true;
        panel.SetActive(true);
        robotSentences4_2.Clear();
        robotAudio4_2.Clear();

        foreach (string sentence in robotDialogue.robotSentences4_2)
        {
            robotSentences4_2.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip4_2)
        {
            robotAudio4_2.Enqueue(clip);
        }

        DisplayNextRobotSentence4_2();
    }

    public void DisplayNextRobotSentence4_2()
    {
        if (robotSentences4_2.Count == 0)
        {
            EndRobotDialogue4_2();
            return;
        }

        string robotSentence = robotSentences4_2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio4_2.Count > 0)
        {
            AudioClip robotAudio = robotAudio4_2.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue4_2()
    {
        dialogue4_2 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        interactionScript.folderInteractable = true;
        interactionScript.chairInteractable = true;
    }

    public void StartRobotDialogue4_3(RobotDialogue robotDialogue)
    {
        dialogue4_3 = true;
        panel.SetActive(true);
        robotSentences4_3.Clear();
        robotAudio4_3.Clear();

        foreach (string sentence in robotDialogue.robotSentences4_3)
        {
            robotSentences4_3.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip4_3)
        {
            robotAudio4_3.Enqueue(clip);
        }

        DisplayNextRobotSentence4_3();
    }

    public void DisplayNextRobotSentence4_3()
    {
        if (robotSentences4_3.Count == 0)
        {
            EndRobotDialogue4_3();
            return;
        }

        string robotSentence = robotSentences4_3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio4_3.Count > 0)
        {
            AudioClip robotAudio = robotAudio4_3.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue4_3()
    {
        dialogue4_3 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        phoneScript.phoneIsActive = true;
        interactionScript.folderInteractable = false;
        interactionScript.chairInteractable = false;
        timerForDialogue = 2f;
        timer2 = true;
    }

    public void StartRobotDialogue4_4(RobotDialogue robotDialogue)
    {
        dialogue4_4 = true;
        panel.SetActive(true);
        robotSentences4_4.Clear();
        robotAudio4_4.Clear();

        foreach (string sentence in robotDialogue.robotSentences4_4)
        {
            robotSentences4_4.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip4_4)
        {
            robotAudio4_4.Enqueue(clip);
        }

        DisplayNextRobotSentence4_4();
    }

    public void DisplayNextRobotSentence4_4()
    {
        if (robotSentences4_4.Count == 0)
        {
            EndRobotDialogue4_4();
            return;
        }

        string robotSentence = robotSentences4_4.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio4_4.Count > 0)
        {
            AudioClip robotAudio = robotAudio4_4.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue4_4()
    {
        dialogue4_4 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
        interactionScript.phoneInteractable = true;
    }

    public void StartRobotDialogue4_5(RobotDialogue robotDialogue)
    {
        dialogue4_5 = true;
        panel.SetActive(true);
        robotSentences4_5.Clear();
        robotAudio4_5.Clear();

        foreach (string sentence in robotDialogue.robotSentences4_5)
        {
            robotSentences4_5.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip4_5)
        {
            robotAudio4_5.Enqueue(clip);
        }

        DisplayNextRobotSentence4_5();
    }

    public void DisplayNextRobotSentence4_5()
    {
        if (robotSentences4_5.Count == 0)
        {
            EndRobotDialogue4_5();
            return;
        }

        string robotSentence = robotSentences4_5.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio4_5.Count > 0)
        {
            AudioClip robotAudio = robotAudio4_5.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue4_5()
    {
        dialogue4_5 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    #endregion

    #region Day Five

    public void StartRobotDialogue5_1(RobotDialogue robotDialogue)
    {
        dialogue5_1 = true;
        panel.SetActive(true);
        robotSentences5_1.Clear();
        robotAudio5_1.Clear();

        foreach (string sentence in robotDialogue.robotSentences5_1)
        {
            robotSentences5_1.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip5_1)
        {
            robotAudio5_1.Enqueue(clip);
        }

        DisplayNextRobotSentence5_1();
    }

    public void DisplayNextRobotSentence5_1()
    {
        if (robotSentences5_1.Count == 0)
        {
            EndRobotDialogue5_1();
            return;
        }

        string robotSentence = robotSentences5_1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio5_1.Count > 0)
        {
            AudioClip robotAudio = robotAudio5_1.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue5_1()
    {
        dialogue5_1 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    public void StartRobotDialogue5_2(RobotDialogue robotDialogue)
    {
        dialogue5_2 = true;
        panel.SetActive(true);
        robotSentences5_2.Clear();
        robotAudio5_2.Clear();

        foreach (string sentence in robotDialogue.robotSentences5_2)
        {
            robotSentences5_2.Enqueue(sentence);
        }

        foreach (AudioClip clip in robotClip5_2)
        {
            robotAudio5_2.Enqueue(clip);
        }

        DisplayNextRobotSentence5_2();
    }

    public void DisplayNextRobotSentence5_2()
    {
        if (robotSentences5_2.Count == 0)
        {
            EndRobotDialogue5_2();
            return;
        }

        string robotSentence = robotSentences5_2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(robotSentence));

        robotAudioSource.Stop();

        if (robotAudio5_2.Count > 0)
        {
            AudioClip robotAudio = robotAudio5_2.Dequeue();
            robotAudioSource.clip = robotAudio;
            robotAudioSource.PlayOneShot(robotAudio);
        }
    }

    public void EndRobotDialogue5_2()
    {
        dialogue5_2 = false;
        robotAudioSource.Stop();
        panel.SetActive(false);
    }

    #endregion

    // Update is called once per frame
    void Update ()
    {
        if(statsScript == null)
        {
            statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
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

            else if (dialogue2_1)
            {
                DisplayNextRobotSentence2_1();
            }
            else if (dialogue2_2)
            {
                DisplayNextRobotSentence2_2();
            }
            else if (dialogue2_3)
            {
                DisplayNextRobotSentence2_3();
            }
            else if (dialogue2_4)
            {
                DisplayNextRobotSentence2_4();
            }
            else if (dialogue2_5)
            {
                DisplayNextRobotSentence2_5();
            }
            else if (dialogue2_6)
            {
                DisplayNextRobotSentence2_6();
            }
            else if (dialogue2_7)
            {
                DisplayNextRobotSentence2_7();
            }
            else if (dialogue2_8)
            {
                DisplayNextRobotSentence2_8();
            }
            else if (dialogue2_9)
            {
                DisplayNextRobotSentence2_9();
            }
            else if (dialogue2_10)
            {
                DisplayNextRobotSentence2_10();
            }
            else if (dialogue2_11)
            {
                DisplayNextRobotSentence2_11();
            }
            else if (dialogue2_12)
            {
                DisplayNextRobotSentence2_12();
            }
            else if (dialogue2_13)
            {
                DisplayNextRobotSentence2_13();
            }
            else if (dialogue2_14)
            {
                DisplayNextRobotSentence2_14();
            }
            else if (dialogue2_15)
            {
                DisplayNextRobotSentence2_15();
            }

            else if (dialogue3_1)
            {
                DisplayNextRobotSentence3_1();
            }
            else if (dialogue3_2)
            {
                DisplayNextRobotSentence3_2();
            }
            else if (dialogue3_3)
            {
                DisplayNextRobotSentence3_3();
            }
            else if (dialogue3_4)
            {
                DisplayNextRobotSentence3_4();
            }
            else if (dialogue3_5)
            {
                DisplayNextRobotSentence3_5();
            }
            else if (dialogue3_6)
            {
                DisplayNextRobotSentence3_6();
            }


            else if (dialogue4_1)
            {
                DisplayNextRobotSentence4_1();
            }
            else if (dialogue4_2)
            {
                DisplayNextRobotSentence4_2();
            }
            else if (dialogue4_3)
            {
                DisplayNextRobotSentence4_3();
            }
            else if (dialogue4_4)
            {
                DisplayNextRobotSentence4_4();
            }
            else if (dialogue4_5)
            {
                DisplayNextRobotSentence4_5();
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

        if (statsScript.day == 2)
        {
            if (timer1)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue2_2();
                    timerForDialogue = 5f;
                    timer1 = false;
                }
            }

            if (timer2)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue2_8();
                    timerForDialogue = 5f;
                    timer2 = false;
                }
            }
        }
        if (statsScript.day == 3)
        {

            if (timer3)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue3_2();
                    timer3 = false;
                }
            }

            if (timer4)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue3_4();
                    timer4 = false;
                }
            }
        }
        if (statsScript.day == 4)
        {
            if (timer1)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue4_2();
                    timer1 = false;
                }
            }
            else if (timer2)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue4_4();
                    timer2 = false;
                }
            }
        }


        if (statsScript.day == 1)
        {
            if (timer1)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue3();
                    timerForDialogue = 3f;
                    timer1 = false;
                }
            }

            if (timer2)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    dayOneScript.faxActive = false;
                    robotDialogueTrigger.TriggerRobotDialogue6();
                    timerForDialogue = 3f;
                    timer2 = false;
                }
            }

            if (timer3)
            {
                if (timerForDialogue > 0)
                {
                    timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    robotDialogueTrigger.TriggerRobotDialogue5();
                    timerForDialogue = 3f;
                    timer3 = false;
                }
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
