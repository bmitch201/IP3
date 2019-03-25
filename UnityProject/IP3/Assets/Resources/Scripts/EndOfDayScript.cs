using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfDayScript : MonoBehaviour
{
    Stats statsScript;
    //PolicyChoices policyChoices;

    public int noOfTasks = 0;

    public string A;
    public string B;
    public string C;
    public string D;

    public string A_2;
    public string B_2;
    public string C_2;
    public string D_2;

    public string E;
    public string F;

    public string phone1A;
    public string phone1B;

    public string phone2A;
    public string phone2B;
    public string phone2C;

    public string conferenceA;
    public string conferenceB;
    public string conferenceC;

    public string conferenceA_2;
    public string conferenceB_2;

    public string[] policyName;
    public string[] policyDescription;
    List<int> description = new List<int>();

    public Text taskText;
    public Text taskText_2;

    public Text policy1Text;
    public Text policyText_2;

    public Text phone1Text;
    public Text phone2Text;

    public Text conferenceText;
    public Text conferenceText_2;

    public Text wifeText;

    public Text contactText;

    public Button saveButton;

    public GameObject day1Panel;
    public GameObject day2Panel;

    public GameObject loadingPanel;
    public GameObject savePanel;

    bool save;

    void Start()
    {
        statsScript = GameObject.FindObjectOfType<Stats>();
        //policyChoices = GameObject.FindObjectOfType<PolicyChoices>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        loadingPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);

        save = false;

        saveButton.onClick.AddListener(statsScript.SaveGame);

        noOfTasks = 0;

        if (statsScript.day - 1 == 1)
        {
            day1Panel.gameObject.SetActive(true);
            day2Panel.gameObject.SetActive(false);

            CheckTasks();
            CheckPolicy();
            CheckPhone();
            CheckConferenceCall();
        }
        else if (statsScript.day - 1 == 2)
        {
            day1Panel.gameObject.SetActive(false);
            day2Panel.gameObject.SetActive(true);

            CheckTasks();
            CheckWife();
            CheckContacts();
            CheckPolicy();
            CheckConferenceCall();
        }
    }

    public void CheckTasks()
    {
        if (statsScript.day - 1 == 1)
        {
            if (statsScript.stats[5] >= 50)
            {
                noOfTasks++;
                statsScript.stats[3] += 5;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }

            if (statsScript.stats[6] >= 60)
            {
                noOfTasks++;
                statsScript.stats[3] += 5;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }

            if (statsScript.stats[2] >= 60)
            {
                noOfTasks++;
                statsScript.stats[3] += 5;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }

            if (statsScript.stats[0] >= 30)
            {
                noOfTasks++;
                statsScript.stats[3] += 5;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }
        }

        if (statsScript.day - 1 == 2)
        {
            if (statsScript.stats[1] >= 2.5)
            {
                noOfTasks++;
                statsScript.stats[3] += 5;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }

            if (statsScript.stats[4] <= 20)
            {
                noOfTasks++;
                statsScript.stats[3] += 5;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }

            if (statsScript.stats[7] >= 55)
            {
                noOfTasks++;
                statsScript.stats[3] += 5;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }
            
            if (statsScript.hEText == "Approved" || statsScript.hMText == "Approved" || statsScript.hVText == "Approved")
            {
                noOfTasks++;
            }
            else
            {
                statsScript.stats[3] -= 5;
            }
        }

        //Determines what text to display based on the number of tasks completed
        if (statsScript.day - 1 == 1)
        {
            if (noOfTasks == 0)
            {
                taskText.text = "On your first day you managed to complete " + noOfTasks + " of your daily tasks, which is " + A;
            }
            else if (noOfTasks == 1)
            {
                taskText.text = "On your first day you managed to complete  " + noOfTasks + " of your daily tasks, which is " + B;
            }
            else if (noOfTasks == 2 || noOfTasks == 3)
            {
                taskText.text = "On your first day you managed to complete  " + noOfTasks + " of your daily tasks, which is " + C;
            }
            else if (noOfTasks == 4)
            {
                taskText.text = "On your first day you managed to complete  " + noOfTasks + " of your daily tasks, which is " + D;
            }
        }
        else if (statsScript.day - 1 == 2)
        {
            if (noOfTasks == 0)
            {
                taskText_2.text = "Second day on the job and you managed to complete " + noOfTasks + " of your daily tasks, which is " + A_2;
            }
            else if (noOfTasks == 1)
            {
                taskText_2.text = "Second day on the job and you managed to complete  " + noOfTasks + " of your daily tasks, which is " + B_2;
            }
            else if (noOfTasks == 2 || noOfTasks == 3)
            {
                taskText_2.text = "Second day on the job and you managed to complete  " + noOfTasks + " of your daily tasks, which is " + C_2;
            }
            else if (noOfTasks == 4)
            {
                taskText_2.text = "Second day on the job and you managed to complete  " + noOfTasks + " of your daily tasks, which is " + D_2;
            }
        }
    }

    public void CheckPolicy()
    {
        foreach (string j in statsScript.chosenPolicies)
        {
            for (int i = 0; i < policyName.Length; i++)
            {
                if (j == policyName[i])
                {
                    description.Add(i);
                }
            }
        }

        if (statsScript.day - 1 == 1)
        {
            if (statsScript.chosenPolicies.Count == 1)
            {
                policy1Text.text = "You also took your first steps into shaping the future of the independent moon by enacting the " + statsScript.chosenPolicies[0] + " policy for Earth, which means " + policyDescription[description[0]];
                statsScript.policyCounter = 1;
            }
            else if (statsScript.chosenPolicies.Count == 2)
            {
                policy1Text.text = "You also took your first steps into shaping the future of the independent moon by enacting the " + statsScript.chosenPolicies[0] + " policy for Earth, which means " + policyDescription[description[0]] + " Following that, you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]];
                statsScript.policyCounter = 2;
            }
            else if (statsScript.chosenPolicies.Count == 3)
            {
                policy1Text.text = "You also took your first steps into shaping the future of the independent moon by enacting the " + statsScript.chosenPolicies[0] + " policy for Earth, which means " + policyDescription[description[0]] + " Following that, you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]] + " After that, you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]];
                statsScript.policyCounter = 3;
            }
        }

        else if (statsScript.day - 1 == 2)
        {
            if (statsScript.policyCounter == 1)
            {
                if (statsScript.chosenPolicies.Count == 2)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]];
                    statsScript.policyCounter = 2;
                }
                else if (statsScript.chosenPolicies.Count == 3)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]] + " You then enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]];
                    statsScript.policyCounter = 3;
                }
                else if (statsScript.chosenPolicies.Count == 4)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]] + " You then enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]] + "As you had some free time, you also enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]];
                    statsScript.policyCounter = 4;
                }
            }
            else if (statsScript.policyCounter == 2)
            {
                if (statsScript.chosenPolicies.Count == 3)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]];
                    statsScript.policyCounter = 3;
                }
                else if (statsScript.chosenPolicies.Count == 4)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]] + " You then enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]];
                    statsScript.policyCounter = 4;
                }
                else if (statsScript.chosenPolicies.Count == 5)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]] + " You then enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]] + "As you had some free time, you also enacted the " + statsScript.chosenPolicies[4] + " policy for " + statsScript.chosenPlanets[4] + ", which means " + policyDescription[description[4]];
                    statsScript.policyCounter = 5;
                }
            }
            else if (statsScript.policyCounter == 3)
            {
                if (statsScript.chosenPolicies.Count == 4)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]];
                    statsScript.policyCounter = 4;
                }
                else if (statsScript.chosenPolicies.Count == 5)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]] + " You then enacted the " + statsScript.chosenPolicies[4] + " policy for " + statsScript.chosenPlanets[4] + ", which means " + policyDescription[description[4]];
                    statsScript.policyCounter = 5;
                }
                else if (statsScript.chosenPolicies.Count == 6)
                {
                    policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]] + " You then enacted the " + statsScript.chosenPolicies[4] + " policy for " + statsScript.chosenPlanets[4] + ", which means " + policyDescription[description[4]] + "As you had some free time, you also enacted the " + statsScript.chosenPolicies[5] + " policy for " + statsScript.chosenPlanets[5] + ", which means " + policyDescription[description[5]];
                    statsScript.policyCounter = 6;
                }
            }
        }
    }

    public void CheckPhone()
    {
        if (statsScript.phone1Answered == true && statsScript.phone1Accept == true)
        {
            phone1Text.text = "Immediately after that, you " + phone1A; 
        }
        else if (statsScript.phone1Answered == true && statsScript.phone1Accept == false)
        {
            phone1Text.text = "Immediately after that, you " + phone1B;
        }

        if (statsScript.phone2Answered == true && statsScript.phone2Accept == true)
        {
            phone2Text.text = phone2A;
        }
        else if (statsScript.phone2Answered == true && statsScript.phone2Accept == false)
        {
            phone2Text.text = phone2B;
        }
        else if (statsScript.phone2Answered == false)
        {
            phone2Text.text = phone2C;
        }
    }

    public void CheckConferenceCall()
    {
        if (statsScript.day - 1 == 1)
        {
            //Checks if player chose to open or close the border during the conference call
            if (statsScript.conferenceAccept == true && statsScript.conferenceAcceptWithHaggle == true)
            {
                conferenceText.text = "The result of your conference call from Earth made headlines as their president made the following announcement on social media: " + conferenceB;
            }
            else if (statsScript.conferenceAccept == true)
            {
                conferenceText.text = "The result of your conference call from Earth made headlines as their president made the following announcement on social media: " + conferenceA;
            }
            else if (statsScript.conferenceAccept == false)
            {
                conferenceText.text = "The result of your conference call from Earth made headlines as their president made the following announcement on social media: " + conferenceC;
            }
        }
        else if (statsScript.day - 1 == 2)
        {
            if (statsScript.conferenceAccept == true)
            {
                conferenceText_2.text = "Your negotiations with the Martians went " + conferenceA_2;
            }
            else
            {
                conferenceText_2.text = "Your negotiations with the Martians went " + conferenceB_2;
            }
        }
    }

    public void CheckWife()
    {
        if (statsScript.day - 1 == 2)
        {
            if (statsScript.wifeCounter == 1)
            {
                wifeText.text = "Your wife called you today, asking if you could ignore or discard Earth’s request, which you " + E + " There will probably be fallout from this action.";
            }
            else
            {
                wifeText.text = "Your wife called you today, asking if you could ignore or discard Earth’s request, which you " + F + " There will probably be fallout from this action.";
            }
        }
    }

    public void CheckContacts()
    {
        if (statsScript.day - 1 == 2)
        {
            if (statsScript.hEText != "Open" && statsScript.hMText != "Open" && statsScript.hVText != "Open")
            {
                contactText.text = "You learned how to use the Outbound Contact system, and asked Earth, Venus and Mars to provide Moon citizens with Free Healthcare abroad.";
            }
            else if (statsScript.hEText != "Open" && statsScript.hMText != "Open")
            {
                contactText.text = "You learned how to use the Outbound Contact system, and asked Earth and Mars to provide Moon citizens with Free Healthcare abroad.";
            }
            else if (statsScript.hEText != "Open" && statsScript.hVText != "Open")
            {
                contactText.text = "You learned how to use the Outbound Contact system, and asked Earth and Venus to provide Moon citizens with Free Healthcare abroad.";
            }
            else if (statsScript.hMText != "Open" && statsScript.hVText != "Open")
            {
                contactText.text = "You learned how to use the Outbound Contact system, and asked Mars and Venus to provide Moon citizens with Free Healthcare abroad.";
            }
            else if (statsScript.hEText != "Open")
            {
                contactText.text = "You learned how to use the Outbound Contact system, and asked Earth to provide Moon citizens with Free Healthcare abroad.";
            }
            else if (statsScript.hMText != "Open")
            {
                contactText.text = "You learned how to use the Outbound Contact system, and asked Mars to provide Moon citizens with Free Healthcare abroad.";
            }
            else if (statsScript.hVText != "Open")
            {
                contactText.text = "You learned how to use the Outbound Contact system, and asked Venus to provide Moon citizens with Free Healthcare abroad.";
            }
        }
    }
    
    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        statsScript.phone1Accept = false;
        statsScript.phone1Answered = false;
        statsScript.phone2Accept = false;
        statsScript.phone1Answered = false;
        statsScript.conferenceAccept = false;
        statsScript.conferenceAcceptWithHaggle = false;
        loadingPanel.gameObject.SetActive(true);
        SceneManager.LoadScene("Actual Game");
    }

    public void SaveGame()
    {
        statsScript.SaveGame();
        save = true;
        savePanel.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (save)
        {
            if (Input.GetMouseButtonDown(0))
            {
                savePanel.gameObject.SetActive(false);
                save = false;
            }
        }
    }
}
