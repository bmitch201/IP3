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


    //public void TriggerConferenceDialogue1()
    //{
    //    dialogueManager.StartConferenceDialogue1(dialogue);
    //}

    //public void TriggerConferenceDialogue2()
    //{
    //    dialogueManager.StartConferenceDialogue2(dialogue);
    //}

    //public void TriggerConferenceDialogue3()
    //{
    //    dialogueManager.StartConferenceDialogue3(dialogue);
    //}

    //public void TriggerConferenceDialogue4()
    //{
    //    dialogueManager.StartConferenceDialogue4(dialogue);
    //}

    //public void TriggerConferenceDialogue5()
    //{
    //    dialogueManager.StartConferenceDialogue5(dialogue);
    //}

    public void TriggerDialogue6()
    {
        dialogueManager.StartDialogue6(dialogue);
    }

    //public void TriggerConferenceDialogue7()
    //{
    //    dialogueManager.StartConferenceDialogue7(dialogue);
    //}

    public void TriggerDialogue8()
    {
        dialogueManager.StartDialogue8(dialogue);
    }

    //public void TriggerConferenceDialogue9()
    //{
    //    dialogueManager.StartConferenceDialogue9(dialogue);
    //}

    public void TriggerDialogue10()
    {
        dialogueManager.StartDialogue10(dialogue);
    }
}
