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
    public Text names, nums;
    public Text PCnames, PCnums;
    public Text whiteboardText;

    [Header("Sliders")]
    public Slider auto, rev, pubs, cabs, syst, earth, venus, mars;

    [Header("Lists")]
    public string[] tasks;
    public List<string> chosenPlanets = new List<string>();
    public List<string> chosenPolicies = new List<string>();

    public List<string> contactNames = new List<string>();
    public List<string> contactPlanets = new List<string>();

    [Header("Outbound Contacts")]
    public string conPlanet, con;
    public float[] contactApprove = new float[8];
    public float[] contactDecline = new float[8];
    int conNum = 0;
    public Text healthEarth, travelEarth, workEarth, healthMars, travelMars, workMars, healthVenus, travelVenus, workVenus;
    public string hEText, tEText, wEText, hMText, tMText, wMText, hVText, tVText, wVText;

    public List<string> phonecallAccept = new List<string>();
    public List<string> phonecallDecline = new List<string>();

    public List<string> connferenceCallAccept = new List<string>();
    public List<string> connferenceCallDecline = new List<string>();

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
    public GameObject pcCamera, earthCam, marsCam, venusCam, moonCam, player, moonCanvas;

    public int time;
    public int day;

    public int wifeCounter;
    public int policyCounter;

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

        hEText = "Open";
        tEText = "Open";
        wEText = "Open";

        hMText = "Open";
        tMText = "Open";
        wMText = "Open";

        hVText = "Open";
        tVText = "Open";
        wVText = "Open";

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

        if (healthEarth != null)
        {
            healthEarth.text = hEText;
            healthMars.text = hMText;
            healthVenus.text = hVText;
        }

        if (travelMars != null)
        {
            travelEarth.text = tEText;
            travelMars.text = tMText;
            travelVenus.text = tVText;
        }

        if (workVenus != null)
        {
            workEarth.text = wEText;
            workMars.text = wMText;
            workVenus.text = wVText;
        }

        auto.value = stats[0];
        pubs.value = stats[2];
        cabs.value = stats[3];
        syst.value = stats[4];
        earth.value = stats[5];
        mars.value = stats[6];
        venus.value = stats[7];

        //erOld = stats[5] - erNew + erOld;
        //stOld = stats[4] - stNew + stOld;
        //csOld = stats[3] - csNew + csOld;
        //vrOld = stats[7] - vrNew + vrOld;

        //StatChanges();
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
            time = 10;
            newDay = true;
            SceneManager.LoadScene("End Of Day");

            if (day > 1)
            {
                for (int k = conNum; k < contactNames.Count; k++)
                {
                    if (contactPlanets[k] == "Earth" && stats[5] > 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactApprove[i] += stats[i];
                        }

                        if(contactNames[k] == "Healthcare")
                        {
                            hEText = "Approved";
                        }
                        else if(contactNames[k] == "Travel")
                        {
                            tEText = "Approved";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wEText = "Approved";
                        }
                    }
                    else if (contactPlanets[k] == "Earth" && stats[5] <= 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactDecline[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hEText = "Declined";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tEText = "Declined";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wEText = "Declined";
                        }
                    }
                    else if (contactPlanets[k] == "Mars" && stats[6] > 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactApprove[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hMText = "Approved";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tMText = "Approved";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wMText = "Approved";
                        }
                    }
                    else if (contactPlanets[k] == "Mars" && stats[6] <= 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactDecline[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hMText = "Declined";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tMText = "Declined";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wMText = "Declined";
                        }
                    }
                    else if (contactPlanets[k] == "Venus" && stats[7] > 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactApprove[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hVText = "Approved";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tVText = "Approved";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wVText = "Approved";
                        }
                    }
                    else if (contactPlanets[k] == "Venus" && stats[7] <= 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactDecline[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hVText = "Declined";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tVText = "Declined";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wVText = "Declined";
                        }
                    }

                    conNum = k++;
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

		if(day == 1)
		{
			moonCanvas.SetActive(false);
		}
    }

    public void Submitted()
    {
        if (conPlanet == "Earth")
        {
            if(con == "Healthcare")
            {
                healthEarth.text = "Submitted";
                hEText = "Submitted";
            }
            else if (con == "Travel")
            {
                travelEarth.text = "Submitted";
                tEText = "Submitted";
            }
            else if(con == "Worker Rights")
            {
                workVenus.text = "Submitted";
                wVText = "Submitted";
            }
        }
        else if (conPlanet == "Mars")
        {
            if (con == "Healthcare")
            {
                healthMars.text = "Submitted";
                hMText = "Submitted";
            }
            else if (con == "Travel")
            {
                travelMars.text = "Submitted";
                tMText = "Submitted";
            }
            else if (con == "Worker Rights")
            {
                workMars.text = "Submitted";
                wMText = "Submitted";
            }
        }
        else if(conPlanet == "Venus")
        {
            if (con == "Healthcare")
            {
                healthVenus.text = "Submitted";
                hVText = "Submitted";
            }
            else if (con == "Travel")
            {
                travelVenus.text = "Submitted";
                tVText = "Submitted";
            }
            else if (con == "Worker Rights")
            {
                workVenus.text = "Submitted";
                wVText = "Submitted";
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