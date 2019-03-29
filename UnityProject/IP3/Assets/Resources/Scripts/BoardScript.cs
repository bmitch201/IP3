using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {

    public GameObject player;

    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    Stats statsScript;

    bool firstBoardUse;

    // Use this for initialization
    void Start ()
    {
        dayOneScript = player.GetComponent<DayOneScript>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        statsScript = FindObjectOfType<Stats>();
        firstBoardUse = true;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.SetActive(true);
            gameObject.SetActive(false);

            if (statsScript.day == 1 && firstBoardUse == true)
            {
                //robotDialogueTrigger.TriggerRobotDialogue5();
                firstBoardUse = false;
                //dayOneScript.Light();
                dayOneScript.boardActive = false;
            }
        }
    }
}
