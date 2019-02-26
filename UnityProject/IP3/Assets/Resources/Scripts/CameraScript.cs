using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public GameObject canvas;

    bool firstPCUse = true;

    InteractionScript interactionScript;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    Stats statsScript;

    private void Start()
    {
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        interactionScript = GameObject.Find("PlayerController").GetComponentInParent<InteractionScript>();
        dayOneScript = GameObject.Find("PlayerController").GetComponent<DayOneScript>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();

        //dayOneScript.enabled = false;
        //interactionScript.enabled = false;
    }

    void Update ()
    {
        //if the player hits F then activate the player and deactivate the PC camera/screen
		if(Input.GetKeyDown(KeyCode.F))
        {
            player.SetActive(true);
            gameObject.SetActive(false);
            dayOneScript.pcAudio.Stop();

            if (statsScript.day == 1 && firstPCUse == true)
            {
                robotDialogueTrigger.TriggerRobotDialogue4();
                firstPCUse = false;
                dayOneScript.pcActive = false;
            }

            if (interactionScript.pcActive == true)
            {
                canvas.SetActive(true);
                interactionScript.pcActive = false;
            }

            if (statsScript.day == 1 && dayOneScript.pcIntractable == true)
            {
                canvas.SetActive(true);
                dayOneScript.Light();
            }
        }
	}
}
