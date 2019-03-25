using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public int day;
    public int time;
    public float[] statistics = new float[8];

    public string[] policies;
    public string[] policyPlanet;

    public string[] contact;
    public string[] contactPlanet;

    public string[] phoneCallAccept;
    public string[] phoneCallDecline;

    public string[] conferenceCallAccept;
    public string[] conferenceCallDecline;

    public void Load()
    {
        PlayerData data = SaveLoad.LoadPlayer();

        day = data.day;
        time = data.time;

        statistics[0] = data.statistics[0];
        statistics[1] = data.statistics[1];
        statistics[2] = data.statistics[2];
        statistics[3] = data.statistics[3];
        statistics[4] = data.statistics[4];
        statistics[5] = data.statistics[5];
        statistics[6] = data.statistics[6];
        statistics[7] = data.statistics[7];

        policies = new string[data.policies.Length];

        for (int i = 0; i < data.policies.Length; i++)
        {
            policies[i] = data.policies[i];
        }

        policyPlanet = new string[data.policyPlanet.Length];

        for (int i = 0; i < data.policyPlanet.Length; i++)
        {
            policyPlanet[i] = data.policyPlanet[i];
        }

        contact = new string[data.contact.Length];

        for (int i = 0; i < data.contact.Length; i++)
        {
            contact[i] = data.contact[i];
        }

        contactPlanet = new string[data.contactPlanet.Length];

        for (int i = 0; i < data.contactPlanet.Length; i++)
        {
            contactPlanet[i] = data.contactPlanet[i];
        }

        phoneCallAccept = new string[data.phoneCallAccept.Length];

        for (int i = 0; i < data.phoneCallAccept.Length; i++)
        {
            phoneCallAccept[i] = data.phoneCallAccept[i];
        }

        phoneCallDecline = new string[data.phoneCallDecline.Length];

        for (int i = 0; i < data.phoneCallDecline.Length; i++)
        {
            phoneCallDecline[i] = data.phoneCallDecline[i];
        }

        conferenceCallAccept = new string[data.conferenceCallAccept.Length];

        for (int i = 0; i < data.conferenceCallAccept.Length; i++)
        {
            conferenceCallAccept[i] = data.conferenceCallAccept[i];
        }

        conferenceCallDecline = new string[data.conferenceCallDecline.Length];

        for (int i = 0; i < data.conferenceCallDecline.Length; i++)
        {
            conferenceCallDecline[i] = data.conferenceCallDecline[i];
        }

        DontDestroyOnLoad(this);

        SceneManager.LoadScene("Actual Game");

    }

    public void UpdateObjects(MoonFolderScript mfs)
    {
        MoonFolderScript moonFolderScript = mfs;
        CameraScript cameraScript = GameObject.Find("PC Camera").GetComponent<CameraScript>();

        for (int i = 0; i < policyPlanet.Length; i++)
        {
            if(policyPlanet[i] == "Earth")
            {
                
            }
            else if(policyPlanet[i] == "Mars")
            {

            }
            else if(policyPlanet[i] == "Venus")
            {

            }
            else if(policyPlanet[i] == "Moon")
            {
                moonFolderScript.currentPage = moonFolderScript.frontPage;

                if(policies[i] == "Tax Decrease" || policies[i] == "Tax Increase" || policies[i] == "Pension Decrease" || policies[i] == "Pension Increase" || policies[i] == "Wage Decrease" || policies[i] == "Wage Increase")
                {
                    moonFolderScript.type = "PopFunds";
                    moonFolderScript.buttons = 3;
                    moonFolderScript.lastPage = moonFolderScript.fundsPage;

                    if (policies[i] == "Wage Decrease" || policies[i] == "Wage Increase")
                    {
                        if(policies[i] == "Wage Increase")
                        {
                            moonFolderScript.buttonClicked = "Wage Increase";
                        }
                        else
                        {
                            moonFolderScript.buttonClicked = "Wage Decrease";
                        }
                    }
                    else if (policies[i] == "Pension Decrease" || policies[i] == "Pension Increase")
                    {
                        if (policies[i] == "Pension Increase")
                        {
                            moonFolderScript.buttonClicked = "Pension Increase";
                        }
                        else
                        {
                            moonFolderScript.buttonClicked = "Pension Decrease";
                        }
                    }
                    else if (policies[i] == "Tax Decrease" || policies[i] == "Tax Increase")
                    {
                        if (policies[i] == "Tax Increase")
                        {
                            moonFolderScript.buttonClicked = "Tax Increase";
                        }
                        else
                        {
                            moonFolderScript.buttonClicked = "Tax Decrease";
                        }
                    }

                    moonFolderScript.DisableButton();
                }
                else
                {
                    moonFolderScript.buttons = 1;

                    if (policies[i] == "Education")
                    {
                        moonFolderScript.type = "Education";
                        moonFolderScript.lastPage = moonFolderScript.eduPage;
                    }
                    else if (policies[i] == "Healthcare")
                    {
                        moonFolderScript.type = "Healthcare";
                        moonFolderScript.lastPage = moonFolderScript.healPage;
                    }
                    else if (policies[i] == "National Services")
                    {
                        moonFolderScript.type = "National Services";
                        moonFolderScript.lastPage = moonFolderScript.nsPage;
                    }
                    else if (policies[i] == "Border Control")
                    {
                        moonFolderScript.type = "Border Control";
                        moonFolderScript.lastPage = moonFolderScript.bcPage;
                    }
                    else if (policies[i] == "Worker Regualtions")
                    {
                        moonFolderScript.type = "Worker Regulations";
                        moonFolderScript.lastPage = moonFolderScript.wrPage;
                    }
                    moonFolderScript.DisableButton();
                }
                
            }
        }

        for (int i = 0; i < contactPlanet.Length; i++)
        {
            if (contactPlanet[i] == "Earth")
            {

            }
            else if (contactPlanet[i] == "Mars")
            {

            }
            else if (contactPlanet[i] == "Venus")
            {

            }

            GameObject.Find("PC Camera").SetActive(false);
        }
    }
}
