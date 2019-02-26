using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    DialogueManager dialogueManager;

    public void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }

    public void TriggerDialogue2()
    {
        dialogueManager.StartDialogue2(dialogue);
    }

    public void TriggerDialogue3()
    {
        dialogueManager.StartDialogue3(dialogue);
    }

    public void TriggerDialogue4()
    {
        dialogueManager.StartDialogue4(dialogue);
    }

    public void TriggerDialogue5()
    {
        dialogueManager.StartDialogue5(dialogue);
    }

    public void TriggerDialogue7()
    {
        dialogueManager.StartDialogue7(dialogue);
    }

    public void TriggerDialogue9()
    {
        dialogueManager.StartDialogue9(dialogue);
    }


    public void TriggerConferenceDialogue1()
    {
        dialogueManager.StartConference1(dialogue);
    }

    public void TriggerConferenceDialogue2()
    {
        dialogueManager.StartConference2(dialogue);
    }

    public void TriggerConferenceDialogue3()
    {
        dialogueManager.StartConference3(dialogue);
    }

    public void TriggerConferenceDialogue4()
    {
        dialogueManager.StartConference4(dialogue);
    }

    public void TriggerConferenceDialogue5()
    {
        dialogueManager.StartConference5(dialogue);
    }

    public void TriggerConferenceDialogue6()
    {
        dialogueManager.StartConference6(dialogue);
    }

    public void TriggerConferenceDialogue7()
    {
        dialogueManager.StartConference7(dialogue);
    }

    public void TriggerConferenceDialogue8()
    {
        dialogueManager.StartConference8(dialogue);
    }

    public void TriggerConferenceDialogue9()
    {
        dialogueManager.StartConference9(dialogue);
    }

    public void TriggerConferenceDialogue10()
    {
        dialogueManager.StartConference10(dialogue);
    }
}
