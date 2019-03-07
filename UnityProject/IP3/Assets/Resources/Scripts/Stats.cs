using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour {

    [Header("Statistics")]
    public float[] stats = new float[8];
    public string[] statNames = new string[8];
    public string[] statDisplay = new string[8];

    [Header("Text")]
    public Text names;
    public Text PCnames;
    public Text nums;
    public Text PCnums;
    public Text whiteboardText;

    public Slider auto, rev, pubs, cabs, syst, earth, venus, mars;

    public string[] tasks;
    public List<string> chosenPlanets = new List<string>();
    public List<string> chosenPolicies = new List<string>();

    public List<string> contactNames = new List<string>();
    public List<string> contactPlanets = new List<string>();

    public string conPlanet;
    public float[] contactApprove = new float[8];
    public float[] contactDecline = new float[8];

    public List<string> phonecallAccept = new List<string>();
    public List<string> phonecallDecline = new List<string>();

    public bool conferenceAccept = false;
    public bool conferenceAcceptWithHaggle = false;

    public bool phone1Answered = false;
    public bool phone2Answered = false;

    public bool phone1Accept;
    public bool phone2Accept;

    public bool newDay;

    private float erOld, stOld, csOld, vrOld;
    private float erNew, stNew, csNew, vrNew;

    GameObject bigHand;
    public GameObject pcCamera, earthCam, marsCam, venusCam, moonCam, player;

    public int time = 10;
    public int day = 1;

    //Sets up the PC Screen initally to display the stats on screen
    void Start()
    {
        names = GameObject.Find("Text_Name").GetComponent<Text>();
        nums = GameObject.Find("Text_Numbers").GetComponent<Text>();

        whiteboardText = GameObject.Find("WhiteboardText").GetComponent<Text>();

        pcCamera = GameObject.Find("PC Camera");

        bigHand = GameObject.Find("Small Hand");

        auto = GameObject.Find("AutSlider").GetComponent<Slider>();
        rev = GameObject.Find("RevenueSlider").GetComponent<Slider>();
        pubs = GameObject.Find("PopSlider").GetComponent<Slider>();
        cabs = GameObject.Find("CabinetSlider").GetComponent<Slider>();
        syst = GameObject.Find("SystemSlider").GetComponent<Slider>();
        earth = GameObject.Find("EarthSlider").GetComponent<Slider>();
        mars = GameObject.Find("MarsSlider").GetComponent<Slider>();
        venus = GameObject.Find("VenusSlider").GetComponent<Slider>();

        for (int i = 0; i < statDisplay.Length; i++)
        {
            statDisplay[i] = statNames[i] + "(%)";
        }

        statDisplay[1] = statNames[1] + "(Billion_Moon_Bucks)";

        erOld = stats[5];
        stOld = stats[4];
        csOld = stats[3];
        vrOld = stats[7];

        erNew = stats[5];
        stNew = stats[4];
        csNew = stats[3];
        vrNew = stats[7];

        UpdateScreen();
        NewDay();
    }

    public void NewDay()
    {
        if (whiteboardText != null)
        {
            whiteboardText.text = "Day " + day + "\n" + "\n" + tasks[day - 1];
        }
    }

    void Tasks()
    {

        if(day == 1)
        {
            if(stats[5] >= 50)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }

            if (stats[6] >= 60)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }

            if (stats[2] >= 60)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }

            if (stats[0] >= 30)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }
        }
    }

    //Updates stats on the screen when called
    public void UpdateScreen()
    { 
        names.text = statDisplay[0] + "\n";
        nums.text = stats[0] + "\n";

        PCnames.text = statDisplay[0] + "\n";
        PCnums.text = stats[0] + "\n";

        for (int i = 1; i < statNames.Length; i++)
        {
            names.text = names.text + "\n" + statDisplay[i] + "\n";
            PCnames.text = PCnames.text + "\n" + statDisplay[i] + "\n";

            nums.text = nums.text + "\n" + stats[i] + "\n";
            PCnums.text = PCnums.text + "\n" + stats[i] + "\n";
        }

        auto.value = stats[0];
        pubs.value = stats[2];
        cabs.value = stats[3];
        syst.value = stats[4];
        earth.value = stats[5];
        mars.value = stats[6];
        venus.value = stats[7];

        erOld = stats[5] - erNew + erOld;
        stOld = stats[4] - stNew + stOld;
        csOld = stats[3] - csNew + csOld;
        vrOld = stats[7] - vrNew + vrOld;

        StatChanges();
    }

    public void StatChanges()
    {
        //for (int i = 0; i < statNames.Length; i++)
        //{
        //    if (statNames[i] == "Autonomy")
        //    {               
        //        if (stats[i] > 75)
        //        {
        //            stats[5] = erOld;
        //            stats[5] = stats[5] - 10;
        //        }
        //        else if (stats[i] > 50 && stats[i] <= 75)
        //        {
        //            stats[5] = erOld;
        //            stats[5] = stats[5] - 5;
        //        }
        //        else if (stats[i] > 25 && stats[i] <= 50)
        //        {
        //            stats[5] = erOld;
        //            stats[5] = stats[5] + 5;
        //        }
        //        else if (stats[i] <= 25)
        //        {
        //            stats[5] = erOld;
        //            stats[5] = stats[5] + 10;
        //        }

        //        erNew = stats[5];
        //    }

        //    if (statNames[i] == "Revenue")
        //    {             
        //        if (stats[i] > 75)
        //        {
        //            stats[4] = stOld;
        //            stats[4] = stats[4] + 10;
        //        }
        //        else if (stats[i] > 50 && stats[i] <= 75)
        //        {
        //            stats[4] = stOld;
        //            stats[4] = stats[4] + 5;
        //        }
        //        else if (stats[i] > 25 && stats[i] <= 50)
        //        {
        //            stats[4] = stOld;
        //            stats[4] = stats[4] - 5;
        //        }
        //        else if (stats[i] <= 25)
        //        {
        //            stats[4] = stOld;
        //            stats[4] = stats[4] - 10;
        //        }

        //        stNew = stats[4];
        //    }

        //    if (statNames[i] == "Public_Support")
        //    {             
        //        if (stats[i] > 75)
        //        {
        //            stats[3] = csOld;
        //            stats[3] = stats[3] - 10;
        //        }
        //        else if (stats[i] > 50 && stats[i] <= 75)
        //        {
        //            stats[3] = csOld;
        //            stats[3] = stats[3] - 5;
        //        }
        //        else if (stats[i] > 25 && stats[i] <= 50)
        //        {
        //            stats[3] = csOld;
        //            stats[3] = stats[3] + 5;
        //        }
        //        else if (stats[i] <= 25)
        //        {
        //            stats[3] = csOld;
        //            stats[3] = stats[3] + 10;
        //        }

        //        csNew = stats[3];
        //    }

        //    if (statNames[i] == "Mars_Relationship")
        //    {          
        //        if (stats[i] > 75)
        //        {
        //            stats[7] = vrOld;
        //            stats[7] = stats[7] - 10;
        //        }
        //        else if (stats[i] > 50 && stats[i] <= 75)
        //        {
        //            stats[7] = vrOld;
        //            stats[7] = stats[7] - 5;
        //        }
        //        else if (stats[i] > 25 && stats[i] <= 50)
        //        {
        //            stats[7] = vrOld;
        //            stats[7] = stats[7] + 5;
        //        }
        //        else if (stats[i] <= 25)
        //        {
        //            stats[7] = vrOld;
        //            stats[7] = stats[7] + 10;
        //        }

        //        vrNew = stats[7];
        //    }
        //}        
    }


    public void TimeForward()
    {
        if(bigHand == null)
        {
            bigHand = GameObject.Find("Small Hand");
        }

        bigHand.transform.rotation = bigHand.transform.rotation * Quaternion.Euler(0f, 30f, 0f);
        time--;
    }

    void Update()
    {
        if(player == null)
        {
            player = GameObject.Find("PlayerController");
        }

        if (time <= 0)
        {
            DontDestroyOnLoad(gameObject);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            day++;
            time = 9;
            newDay = true;
            SceneManager.LoadScene("End Of Day");

            if (day > 1)
            {
                if (conPlanet == "Earth" && stats[5] > 60)
                {
                    for (int i = 0; i < stats.Length; i++)
                    {
                        contactApprove[i] += stats[i];
                    }
                }
                else if (conPlanet == "Mars" && stats[6] > 60)
                {
                    for (int i = 0; i < stats.Length; i++)
                    {
                        contactApprove[i] += stats[i];
                    }
                }
                else if (conPlanet == "Venus" && stats[7] > 60)
                {
                    for (int i = 0; i < stats.Length; i++)
                    {
                        contactApprove[i] += stats[i];
                    }
                }
                else if (conPlanet == "Earth" && stats[5] <= 60)
                {
                    for (int i = 0; i < stats.Length; i++)
                    {
                        contactDecline[i] += stats[i];
                    }
                }
                else if (conPlanet == "Mars" && stats[6] <= 60)
                {
                    for (int i = 0; i < stats.Length; i++)
                    {
                        contactDecline[i] += stats[i];
                    }
                }
                else if (conPlanet == "Venus" && stats[7] <= 60)
                {
                    for (int i = 0; i < stats.Length; i++)
                    {
                        contactDecline[i] += stats[i];
                    }
                }

                for (int i = 0; i < stats.Length; i++)
                {
                    contactApprove[i] = 0;
                    contactDecline[i] = 0;
                }
            }

        }

        if (SceneManager.GetActiveScene().name == "Actual Game")
        {
            if (names == null)
            {
                names = GameObject.Find("Text_Name").GetComponent<Text>();
                nums = GameObject.Find("Text_Numbers").GetComponent<Text>();

                bigHand = GameObject.Find("Small Hand");
            }

            if (pcCamera == null)
            {
                pcCamera = GameObject.Find("PC Camera");
            }

            if (PCnames == null && pcCamera != null)
            {
                pcCamera.SetActive(true);
                pcCamera.GetComponent<CameraScript>().statsPage.SetActive(true);
                PCnames = GameObject.Find("Text_Name_PC").GetComponent<Text>();
                PCnums = GameObject.Find("Text_Numbers_PC").GetComponent<Text>();
                pcCamera.GetComponent<CameraScript>().statsPage.SetActive(false);
                pcCamera.SetActive(false);
            }

            if (auto == null)
            {
                auto = GameObject.Find("AutSlider").GetComponent<Slider>();
                rev = GameObject.Find("RevenueSlider").GetComponent<Slider>();
                pubs = GameObject.Find("PopSlider").GetComponent<Slider>();
                cabs = GameObject.Find("CabinetSlider").GetComponent<Slider>();
                syst = GameObject.Find("SystemSlider").GetComponent<Slider>();
                earth = GameObject.Find("EarthSlider").GetComponent<Slider>();
                mars = GameObject.Find("MarsSlider").GetComponent<Slider>();
                venus = GameObject.Find("VenusSlider").GetComponent<Slider>();

                UpdateScreen();
            }

            if (whiteboardText == null)
            {
                whiteboardText = GameObject.Find("WhiteboardText").GetComponent<Text>();
                NewDay();
            }
        }
    }

    public void SaveGame()
    {
        SaveLoad.SavePlayer(this);
    }

    public void LoadGame()
    {
        PlayerData data = SaveLoad.LoadPlayer();

        day = data.day;
        time = data.time;

        stats[0] = data.statistics[0];
        stats[1] = data.statistics[1];
        stats[2] = data.statistics[2];
        stats[3] = data.statistics[3];
        stats[4] = data.statistics[4];
        stats[5] = data.statistics[5];
        stats[6] = data.statistics[6];
        stats[7] = data.statistics[7];
    }
}