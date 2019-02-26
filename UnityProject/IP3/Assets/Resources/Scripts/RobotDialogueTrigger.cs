using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDialogueTrigger : MonoBehaviour {

    public RobotDialogue robotDialogue;
    public RobotDialogueManager robotDialogueManager;

	// Use this for initialization
	void Start ()
    {
        robotDialogueManager = FindObjectOfType<RobotDialogueManager>();
	}

    public void TriggerRobotDialogue1()
    {
        robotDialogueManager.StartRobotDialogue1(robotDialogue);
    }

    public void TriggerRobotDialogue2()
    {
        robotDialogueManager.StartRobotDialogue2(robotDialogue);
    }

    public void TriggerRobotDialogue3()
    {
        robotDialogueManager.StartRobotDialogue3(robotDialogue);
    }

    public void TriggerRobotDialogue4()
    {
        robotDialogueManager.StartRobotDialogue4(robotDialogue);
    }

    public void TriggerRobotDialogue5()
    {
        robotDialogueManager.StartRobotDialogue5(robotDialogue);
    }

    public void TriggerRobotDialogue6()
    {
        robotDialogueManager.StartRobotDialogue6(robotDialogue);
    }

    public void TriggerRobotDialogue7()
    {
        robotDialogueManager.StartRobotDialogue7(robotDialogue);
    }

    public void TriggerRobotDialogue8()
    {
        robotDialogueManager.StartRobotDialogue8(robotDialogue);
    }

    public void TriggerRobotDialogue9()
    {
        robotDialogueManager.StartRobotDialogue9(robotDialogue);
    }

    public void TriggerRobotDialogue10()
    {
        robotDialogueManager.StartRobotDialogue10(robotDialogue);
    }

    public void TriggerRobotDialogue11()
    {
        robotDialogueManager.StartRobotDialogue11(robotDialogue);
    }

    public void TriggerRobotDialogue12()
    {
        robotDialogueManager.StartRobotDialogue12(robotDialogue);
    }

    public void TriggerRobotDialogue13()
    {
        robotDialogueManager.StartRobotDialogue13(robotDialogue);
    }

    public void TriggerRobotDialogue14()
    {
        robotDialogueManager.StartRobotDialogue14(robotDialogue);
    }

    public void TriggerRobotDialogue2_1()
    {
        robotDialogueManager.StartRobotDialogue2_1(robotDialogue);
    }

    //public void TriggerRobotDialogue16()
    //{
    //    robotDialogueManager.StartRobotDialogue14(robotDialogue);
    //}

    // Update is called once per frame
    void Update () {
		
	}
}
