﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairCameraScript : MonoBehaviour
{
    DayOneScript dos;
    InteractionScript ins;
    Stats statsScript;

    public float speedH = 1.0f;
    public float speedV = 1.0f;

    float yaw = -100f;
    float pitch;

    public GameObject pcCamera;
    public GameObject canvas;
    GameObject player;

    AudioSource pcAudio;
    public AudioClip typingFX;

    public Text info;

    bool dosEnabled;

    void Start()
    {
        player = GameObject.Find("MainCamera");

        dos = player.GetComponentInParent<DayOneScript>();
        ins = player.GetComponentInParent<InteractionScript>();
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();

        pcAudio = GameObject.FindGameObjectWithTag("PC").GetComponent<AudioSource>();

        if(dos.enabled)
        {
            dosEnabled = true;
        }
        else if (ins.enabled)
        {
            dosEnabled = false;
        }
    }

    void Update()
    {
        if (player.active)
        {
            player.SetActive(false);
            dos.enabled = false;
            ins.enabled = false;
        }

        if (yaw >= -175f && yaw <= -25f)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
        }
        else if (yaw < -174.9f)
        {
            yaw = -175f;
        }
        else if (yaw > -26.1f)
        {
            yaw = -25f;
        }

        if (pitch >= -45f && pitch <= 45f)
        {
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        else if (pitch < -45f)
        {
            pitch = -45f;
        }
        else if (pitch > 45f)
        {
            pitch = 45f;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        //Sets up a raycast for the position of the mouse
        Ray ray = this.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit = new RaycastHit();

        //If the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            //Get the distance to the object from the current position
            float dist = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);

            //If the object has a Tag of PC then display a message to the player telling them they can "open" this object 
            if (hit.collider.gameObject.tag == "PC")
            {
                //If the distance to the object is less than 2.5
                if (dist <= 1.25f)
                {
                    info.text = "Press 'F' to open";
                    info.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (dosEnabled == true)
                    {
                        dos.enabled = true;
                    }
                    else
                    {
                        ins.enabled = true;
                    }

                    pcCamera.SetActive(true);
                    canvas.SetActive(false);
                    statsScript.UpdateScreen();
                    pcAudio.clip = typingFX;
                    pcAudio.PlayOneShot(typingFX);
                    gameObject.SetActive(false);

                    if (dosEnabled == true)
                    {
                        dos.enabled = false;
                    }
                    else
                    {
                        ins.enabled = false;
                    }
                }
            }

            if (hit.collider.gameObject.tag != "PC")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (dosEnabled == true)
                    {
                        dos.enabled = true;
                    }
                    else
                    {
                        ins.enabled = true;
                    }

                    player.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}