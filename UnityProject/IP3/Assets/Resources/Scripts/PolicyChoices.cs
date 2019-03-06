using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyChoices : MonoBehaviour {

    public GameObject es, ms, vs, gio, ec, mc, vc;

    public string planetType = "";
    public string movementChoice = "";

    InteractionScript ints;

    void Start()
    {

    }

    public void UpdatePolicies()
    {
        ints = FindObjectOfType<InteractionScript>();

        gio = GameObject.Find("GameInfoObject DDL");
        es = GameObject.Find("Earth Folder DDL");
        ms = GameObject.Find("Mars Folder DDL");
        vs = GameObject.Find("Venus Folder DDL");

        gio.name = "GameInfoObject";
        es.name = "Earth Folder";
        ms.name = "Mars Folder";
        vs.name = "Venus Folder";

        ints.earthCamera = ec;
        ints.marsCamera = mc;
        ints.venusCamera = vc;
    }

}
