﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Code used in Dialogue, Dialogue Manager, Dialogue Trigger, Robot Dialogue, Robot Dialogue Manager and Robot Dialogue Trigger was used and expanded upon from a video tutorial
// "How to make a dialogue system in Unity" - Brackeys https://www.youtube.com/watch?v=_nRzoTzeyxU

public class DialogueManager : MonoBehaviour {

    public Text planetText;
    public Text dialogueText;

    public GameObject speakerPanel;
    public GameObject answerPanel;

    public Stats statsScript;
    DialogueTrigger dialogueTrigger;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    InteractionScript interactionScript;

    public GameObject conferenceCall;
    public GameObject player;

    public Button option1;
    public Button option2;
    public Button option3;
    public Button continueButton;

    private Queue<string> sentences;
    private Queue<string> sentences2;
    private Queue<string> sentences3;
    private Queue<string> sentences4;
    private Queue<string> sentences5;
    private Queue<string> sentences7;
    private Queue<string> sentences9;

    private Queue<AudioClip> audio1;
    private Queue<AudioClip> audio2;
    private Queue<AudioClip> audio3;
    private Queue<AudioClip> audio4;
    private Queue<AudioClip> audio5;
    private Queue<AudioClip> audio7;
    private Queue<AudioClip> audio9;

    AudioSource audioSource;

    public AudioClip[] audioClip1, audioClip2, audioClip3, audioClip4, audioClip5, audioClip7, audioClip9;

    public string[] answers1;
    public string[] answers2;

    bool dialogue2Visited;
    bool dialogue5Visited;
    bool dialogue10Visited;
    bool dialogue8Visited;


    private Queue<string> call2sentences1;
    private Queue<string> call2sentences2;
    private Queue<string> call2sentences3;
    private Queue<string> call2sentences4;
    private Queue<string> call2sentences5;
    private Queue<string> call2sentences6;
    private Queue<string> call2sentences7;
    private Queue<string> call2sentences8;
    private Queue<string> call2sentences9;
    private Queue<string> call2sentences10;

    public string[] call2answers1;
    public string[] call2answers2;

    bool conferenceDialogue2Visited;
    bool conferenceDialogue4Visited;

    // Use this for initialization
    void Awake ()
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        dayOneScript = FindObjectOfType<DayOneScript>();
        interactionScript = FindObjectOfType<InteractionScript>();

        audioSource = GameObject.FindGameObjectWithTag("ConferenceCall").GetComponent<AudioSource>();

        sentences = new Queue<string>();
        sentences2 = new Queue<string>();
        sentences3 = new Queue<string>();
        sentences4 = new Queue<string>();
        sentences5 = new Queue<string>();
        sentences7 = new Queue<string>();
        sentences9 = new Queue<string>();

        audio1 = new Queue<AudioClip>();
        audio2 = new Queue<AudioClip>();
        audio3 = new Queue<AudioClip>();
        audio4 = new Queue<AudioClip>();
        audio5 = new Queue<AudioClip>();
        audio7 = new Queue<AudioClip>();
        audio9 = new Queue<AudioClip>();

        call2sentences1 = new Queue<string>();
        call2sentences2 = new Queue<string>();
        call2sentences3 = new Queue<string>();
        call2sentences4 = new Queue<string>();
        call2sentences5 = new Queue<string>();
        call2sentences6 = new Queue<string>();
        call2sentences7 = new Queue<string>();
        call2sentences8 = new Queue<string>();
        call2sentences9 = new Queue<string>();
        call2sentences10 = new Queue<string>();
    }

    void Start()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
    }

    #region Conference Call 1

    public void StartDialogue(Dialogue dialogue)
    {
        planetText.text = dialogue.planet1;
        continueButton.onClick.AddListener(DisplayNextSentence);

        sentences.Clear();
        audio1.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (AudioClip clip in audioClip1)
        {
            audio1.Enqueue(clip);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        audioSource.Stop();

        if (audio1.Count > 0)
        {
            AudioClip audio = audio1.Dequeue();
            audioSource.clip = audio;
            audioSource.PlayOneShot(audio);
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("1");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.GetComponentInChildren<Text>().text = answers1[1];
        option3.GetComponentInChildren<Text>().text = answers1[2];

        option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

        if (statsScript.stats[5] > 40)
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
        }
        else
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
        }

        if (statsScript.stats[5] > 39)
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
        }
        else
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
        }
    }

    public void StartDialogue2(Dialogue dialogue)
    {
        statsScript.stats[5] -= 5;

        statsScript.conferenceAcceptWithHaggle = true;
        dialogue2Visited = true;
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence2);

        planetText.text = dialogue.planet1;

        sentences2.Clear();
        audio2.Clear();

        foreach (string sentence2 in dialogue.sentences2)
        {
            sentences2.Enqueue(sentence2);
        }

        foreach (AudioClip clip in audioClip2)
        {
            audio2.Enqueue(clip);
        }

        DisplayNextSentence2();
    }

    public void DisplayNextSentence2()
    {
        if (sentences2.Count == 0)
        {
            EndDialogue2();
            return;
        }

        string sentence2 = sentences2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2));

        audioSource.Stop();

        if (audio2.Count > 0)
        {
            AudioClip audio = audio2.Dequeue();
            audioSource.clip = audio;
            audioSource.PlayOneShot(audio);
        }
    }

    public void EndDialogue2()
    {
        Debug.Log("2");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);
        option1.GetComponentInChildren<Text>().text = answers2[0];
        option2.GetComponentInChildren<Text>().text = answers2[1];
        option3.GetComponentInChildren<Text>().text = answers2[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

        option2.onClick.RemoveAllListeners();

        if (statsScript.stats[5] > 40)
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
        }
        else
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
        }

        option3.onClick.RemoveAllListeners();

        if (statsScript.stats[5] > 40)
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
        }
        else
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
        }
    }

    public void StartDialogue3(Dialogue dialogue)
    {
        statsScript.stats[5] -= 5;

        dialogue2Visited = true;
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence3);

        planetText.text = dialogue.planet1;

        sentences3.Clear();
        audio3.Clear();

        foreach (string sentence3 in dialogue.sentences3)
        {
            sentences3.Enqueue(sentence3);
        }

        foreach (AudioClip clip in audioClip3)
        {
            audio3.Enqueue(clip);
        }

        DisplayNextSentence3();
    }

    public void DisplayNextSentence3()
    {
        if (sentences3.Count == 0)
        {
            EndDialogue3();
            return;
        }

        string sentence3 = sentences3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence3));

        audioSource.Stop();

        if (audio3.Count > 0)
        {
            AudioClip audio = audio3.Dequeue();
            audioSource.clip = audio;
            audioSource.PlayOneShot(audio);
        }
    }

    public void EndDialogue3()
    {
        Debug.Log("3");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);
        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = answers1[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
    }

    public void StartDialogue4(Dialogue dialogue)
    {
        if (dialogue2Visited)
        {
            statsScript.stats[5] += 15;
            statsScript.stats[0] -= 10;
            statsScript.stats[4] -= 5;
            statsScript.stats[2] -= 5;
        }
        else if (dialogue10Visited)
        {
            statsScript.stats[5] += 15;
            statsScript.stats[0] -= 10;
            statsScript.stats[4] -= 10;
            statsScript.stats[1] += 0.2f;
            statsScript.stats[2] += 5;
        }
        else if (dialogue5Visited)
        {
            statsScript.stats[5] += 15;
            statsScript.stats[0] -= 10;
            statsScript.stats[4] -= 10;
            statsScript.stats[1] += 0.2f;
            statsScript.stats[2] += 5;
        }
        else
        {
            statsScript.stats[5] += 15;
            statsScript.stats[0] -= 10;
            statsScript.stats[4] -= 5;
            statsScript.stats[1] += 2;
            statsScript.stats[2] -= 5;
        }

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence4);

        planetText.text = dialogue.planet1;

        sentences4.Clear();
        audio4.Clear();

        foreach (string sentence4 in dialogue.sentences4)
        {
            sentences4.Enqueue(sentence4);
        }

        foreach (AudioClip clip in audioClip4)
        {
            audio4.Enqueue(clip);
        }

        DisplayNextSentence4();
    }

    public void DisplayNextSentence4()
    {
        if (sentences4.Count == 0)
        {
            EndDialogue4();
            return;
        }

        string sentence4 = sentences4.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence4));

        audioSource.Stop();

        if (audio4.Count > 0)
        {
            AudioClip audio = audio4.Dequeue();
            audioSource.clip = audio;
            audioSource.PlayOneShot(audio);
        }
    }

    public void EndDialogue4()
    {
        Debug.Log("4");
        conferenceCall.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        robotDialogueTrigger.TriggerRobotDialogue14();
        statsScript.conferenceAccept = true;
        statsScript.connferenceCallAccept.Add("Earth Moonpath");
    }

    public void StartDialogue5(Dialogue dialogue)
    {
        statsScript.stats[5] -= 5;

        dialogue5Visited = true;
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence5);

        planetText.text = dialogue.planet1;

        sentences5.Clear();
        audio5.Clear();

        foreach (string sentence5 in dialogue.sentences5)
        {
            sentences5.Enqueue(sentence5);
        }

        foreach (AudioClip clip in audioClip5)
        {
            audio5.Enqueue(clip);
        }

        DisplayNextSentence5();
    }

    public void DisplayNextSentence5()
    {
        if (sentences5.Count == 0)
        {
            EndDialogue5();
            return;
        }

        string sentence5 = sentences5.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence5));

        audioSource.Stop();

        if (audio5.Count > 0)
        {
            AudioClip audio = audio5.Dequeue();
            audioSource.clip = audio;
            audioSource.PlayOneShot(audio);
        }
    }

    public void EndDialogue5()
    {
        Debug.Log("5");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);
        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = answers1[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

        option3.onClick.RemoveAllListeners();

        if (statsScript.stats[5] > 40)
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
            dialogue10Visited = true;
        }
        else
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
        }
    }

    public void StartDialogue7(Dialogue dialogue)
    {
        statsScript.stats[5] -= 10;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence7);

        planetText.text = dialogue.planet1;

        sentences7.Clear();
        audio7.Clear();

        foreach (string sentence7 in dialogue.sentences7)
        {
            sentences7.Enqueue(sentence7);
        }

        foreach (AudioClip clip in audioClip7)
        {
            audio7.Enqueue(clip);
        }

        DisplayNextSentence7();
    }

    public void DisplayNextSentence7()
    {
        if (sentences7.Count == 0)
        {
            EndDialogue7();
            return;
        }

        string sentence7 = sentences7.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence7));

        audioSource.Stop();

        if (audio7.Count > 0)
        {
            AudioClip audio = audio7.Dequeue();
            audioSource.clip = audio;
            audioSource.PlayOneShot(audio);
        }
    }

    public void EndDialogue7()
    {
        Debug.Log("7");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);


        if (dialogue5Visited)
        {
            option1.GetComponentInChildren<Text>().text = answers1[0];
            option2.GetComponentInChildren<Text>().text = answers1[1];
            option3.GetComponentInChildren<Text>().text = answers1[2];

            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

            if (statsScript.stats[5] > 35)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
        }
        else if (dialogue10Visited)
        {
            option1.GetComponentInChildren<Text>().text = answers1[0];
            option2.gameObject.SetActive(false);
            option3.GetComponentInChildren<Text>().text = answers1[2];

            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
        }
        else
        {
            option1.GetComponentInChildren<Text>().text = answers1[0];
            option2.GetComponentInChildren<Text>().text = answers1[1];
            option3.GetComponentInChildren<Text>().text = answers1[2];

            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

            if (statsScript.stats[5] > 40)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
        }
    }

    public void StartDialogue9(Dialogue dialogue)
    {
        if (dialogue5Visited)
        {
            statsScript.stats[5] -= 10;
            statsScript.stats[0] += 10;
            statsScript.stats[4] += 5;
            statsScript.stats[2] += 5;
        }
        else
        {
            statsScript.stats[5] -= 10;
            statsScript.stats[0] += 10;
            statsScript.stats[4] += 5;
            statsScript.stats[2] += 5;
        }

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence9);

        planetText.text = dialogue.planet1;

        sentences9.Clear();
        audio9.Clear();

        foreach (string sentence9 in dialogue.sentences9)
        {
            sentences9.Enqueue(sentence9);
        }

        foreach (AudioClip clip in audioClip9)
        {
            audio9.Enqueue(clip);
        }

        DisplayNextSentence9();
    }

    public void DisplayNextSentence9()
    {
        if (sentences9.Count == 0)
        {
            EndDialogue9();
            return;
        }

        string sentence9 = sentences9.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence9));

        audioSource.Stop();

        if (audio9.Count > 0)
        {
            AudioClip audio = audio9.Dequeue();
            audioSource.clip = audio;
            audioSource.PlayOneShot(audio);
        }
    }

    public void EndDialogue9()
    {
        Debug.Log("9");
        conferenceCall.SetActive(false);
        dayOneScript.femaleHologram.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dayOneScript.conferenceCallInteractable = false;
        robotDialogueTrigger.TriggerRobotDialogue14();
        statsScript.conferenceAccept = false;
        statsScript.connferenceCallDecline.Add("Earth Moonpath");

    }

    #endregion

    public void StartConferenceDialogue1(Dialogue dialogue)
    {
        conferenceDialogue2Visited = false;
        conferenceDialogue4Visited = false;

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence1);

        call2sentences1.Clear();

        foreach (string sentence2_1 in dialogue.call2sentences1)
        {
            call2sentences1.Enqueue(sentence2_1);
        }

        DisplayNextConferenceSentence1();
    }

    public void DisplayNextConferenceSentence1()
    {
        if (call2sentences1.Count == 0)
        {
            EndConferenceDialogue1();
            return;
        }

        string sentence2_1 = call2sentences1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_1));
    }

    public void EndConferenceDialogue1()
    {
        Debug.Log("1");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers1[0];
        option2.GetComponentInChildren<Text>().text = call2answers1[1];
        option3.GetComponentInChildren<Text>().text = call2answers1[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option2.onClick.RemoveAllListeners();
        if (statsScript.stats[6] >= 39)
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue2);
        }
        else
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue3);
        }

        option3.onClick.RemoveAllListeners();
        if (statsScript.stats[6] >= 34)
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue7);
        }
        else
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
        }
    }

    public void StartConferenceDialogue2(Dialogue dialogue)
    {
        statsScript.stats[6] -= 5;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        conferenceDialogue2Visited = true;

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence2);

        call2sentences2.Clear();

        foreach (string sentence2_2 in dialogue.call2sentences2)
        {
            call2sentences2.Enqueue(sentence2_2);
        }

        DisplayNextConferenceSentence2();
    }

    public void DisplayNextConferenceSentence2()
    {
        if (call2sentences2.Count == 0)
        {
            EndConferenceDialogue2();
            return;
        }

        string sentence2_2 = call2sentences2.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_2));
    }

    public void EndConferenceDialogue2()
    {
        Debug.Log("2");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers2[0];
        option2.GetComponentInChildren<Text>().text = call2answers2[1];
        option3.GetComponentInChildren<Text>().text = call2answers2[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option2.onClick.RemoveAllListeners();
        if (statsScript.stats[6] > 34)
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue4);
        }
        else
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue5);
        }

        option3.onClick.RemoveAllListeners();
        if (statsScript.stats[6] > 34)
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue7);
        }
        else
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
        }
    }

    public void StartConferenceDialogue3(Dialogue dialogue)
    {
        statsScript.stats[6] -= 5;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence3);

        call2sentences3.Clear();

        foreach (string sentence2_3 in dialogue.call2sentences3)
        {
            call2sentences3.Enqueue(sentence2_3);
        }

        DisplayNextConferenceSentence3();
    }

    public void DisplayNextConferenceSentence3()
    {
        if (call2sentences3.Count == 0)
        {
            EndConferenceDialogue3();
            return;
        }

        string sentence2_3 = call2sentences3.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_3));
    }

    public void EndConferenceDialogue3()
    {
        Debug.Log("3");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers1[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = call2answers1[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
    }

    public void StartConferenceDialogue4(Dialogue dialogue)
    {
        statsScript.stats[6] -= 5;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        conferenceDialogue4Visited = true;

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence4);

        call2sentences4.Clear();

        foreach (string sentence2_4 in dialogue.call2sentences4)
        {
            call2sentences4.Enqueue(sentence2_4);
        }

        DisplayNextConferenceSentence4();
    }

    public void DisplayNextConferenceSentence4()
    {
        if (call2sentences4.Count == 0)
        {
            EndConferenceDialogue4();
            return;
        }

        string sentence2_4 = call2sentences4.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_4));
    }

    public void EndConferenceDialogue4()
    {
        Debug.Log("4");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers2[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = call2answers2[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option3.onClick.RemoveAllListeners();
        if (statsScript.stats[6] > 34)
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue8);
        }
        else if (statsScript.stats[6] <= 34)
        {
            option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
        }
    }

    public void StartConferenceDialogue5(Dialogue dialogue)
    {
        statsScript.stats[6] -= 5;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence5);

        call2sentences5.Clear();

        foreach (string sentence2_5 in dialogue.call2sentences5)
        {
            call2sentences5.Enqueue(sentence2_5);
        }

        DisplayNextConferenceSentence5();
    }

    public void DisplayNextConferenceSentence5()
    {
        if (call2sentences5.Count == 0)
        {
            EndConferenceDialogue5();
            return;
        }

        string sentence2_5 = call2sentences5.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_5));
    }

    public void EndConferenceDialogue5()
    {
        Debug.Log("5");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers2[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = call2answers2[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
    }

    public void StartConferenceDialogue6(Dialogue dialogue)
    {
        statsScript.stats[6] -= 5;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence6);

        call2sentences6.Clear();

        foreach (string sentence2_6 in dialogue.call2sentences6)
        {
            call2sentences6.Enqueue(sentence2_6);
        }

        DisplayNextConferenceSentence6();
    }

    public void DisplayNextConferenceSentence6()
    {
        if (call2sentences6.Count == 0)
        {
            EndConferenceDialogue6();
            return;
        }

        string sentence2_6 = call2sentences6.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_6));
    }

    public void EndConferenceDialogue6()
    {
        Debug.Log("6");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers1[0];
        option2.GetComponentInChildren<Text>().text = call2answers1[1];
        option3.GetComponentInChildren<Text>().text = call2answers1[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option2.onClick.RemoveAllListeners();
        if (statsScript.stats[6] >= 34)
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue2);
        }
        else
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue3);
        }

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
    }

    public void StartConferenceDialogue7(Dialogue dialogue)
    {
        statsScript.stats[6] -= 5;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence7);

        call2sentences7.Clear();

        foreach (string sentence2_7 in dialogue.call2sentences7)
        {
            call2sentences7.Enqueue(sentence2_7);
        }

        DisplayNextConferenceSentence7();
    }

    public void DisplayNextConferenceSentence7()
    {
        if (call2sentences6.Count == 0)
        {
            EndConferenceDialogue7();
            return;
        }

        string sentence2_7 = call2sentences7.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_7));
    }

    public void EndConferenceDialogue7()
    {
        Debug.Log("7");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers2[0];
        option2.GetComponentInChildren<Text>().text = call2answers2[1];
        option3.GetComponentInChildren<Text>().text = call2answers2[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option2.onClick.RemoveAllListeners();
        if (statsScript.stats[6] > 29)
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue4);
        }
        else
        {
            option2.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue5);
        }

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
    }

    public void StartConferenceDialogue8(Dialogue dialogue)
    {
        statsScript.stats[6] -= 5;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence8);

        call2sentences8.Clear();

        foreach (string sentence2_8 in dialogue.call2sentences8)
        {
            call2sentences8.Enqueue(sentence2_8);
        }

        DisplayNextConferenceSentence8();
    }

    public void DisplayNextConferenceSentence8()
    {
        if (call2sentences8.Count == 0)
        {
            EndConferenceDialogue8();
            return;
        }

        string sentence2_8 = call2sentences8.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_8));
    }

    public void EndConferenceDialogue8()
    {
        Debug.Log("8");
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = call2answers2[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = call2answers2[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue9);

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerConferenceDialogue10);
    }

    public void StartConferenceDialogue9(Dialogue dialogue)
    {
        statsScript.stats[4] += 10;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        if (conferenceDialogue2Visited)
        {
            statsScript.stats[1] += 0.5f;
            statsScript.stats[6] += 15;
            statsScript.stats[2] -= 5;
        }
        else if (conferenceDialogue2Visited && conferenceDialogue4Visited)
        {
            statsScript.stats[1] += 0.5f;
            statsScript.stats[6] += 15;
        }
        else
        {
            statsScript.stats[1] += 0.3f;
            statsScript.stats[6] += 15;
            statsScript.stats[0] -= 5;
            statsScript.stats[2] -= 10;
        }


        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence9);

        call2sentences9.Clear();

        foreach (string sentence2_9 in dialogue.call2sentences9)
        {
            call2sentences9.Enqueue(sentence2_9);
        }

        DisplayNextConferenceSentence9();
    }

    public void DisplayNextConferenceSentence9()
    {
        if (call2sentences9.Count == 0)
        {
            EndConferenceDialogue9();
            return;
        }

        string sentence2_9 = call2sentences9.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_9));
    }

    public void EndConferenceDialogue9()
    {
        Debug.Log("9");
        conferenceCall.SetActive(false);
        interactionScript.femaleHologram.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        interactionScript.conferenceCallInteractable = false;
        robotDialogueTrigger.TriggerRobotDialogue2_15();
        //statsScript.conferenceAccept = false;
    }

    public void StartConferenceDialogue10(Dialogue dialogue)
    {
        statsScript.stats[6] -= 15;
        statsScript.stats[0] += 10;
        statsScript.stats[2] += 10;

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        planetText.text = dialogue.planet2;
        continueButton.onClick.AddListener(DisplayNextConferenceSentence10);

        call2sentences10.Clear();

        foreach (string sentence2_10 in dialogue.call2sentences10)
        {
            call2sentences10.Enqueue(sentence2_10);
        }

        DisplayNextConferenceSentence10();
    }

    public void DisplayNextConferenceSentence10()
    {
        if (call2sentences10.Count == 0)
        {
            EndConferenceDialogue10();
            return;
        }

        string sentence2_10 = call2sentences10.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2_10));
    }

    public void EndConferenceDialogue10()
    {
        Debug.Log("10");
        conferenceCall.SetActive(false);
        interactionScript.femaleHologram.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        interactionScript.conferenceCallInteractable = false;
        robotDialogueTrigger.TriggerRobotDialogue2_15();
        //statsScript.conferenceAccept = false;
    }
}
