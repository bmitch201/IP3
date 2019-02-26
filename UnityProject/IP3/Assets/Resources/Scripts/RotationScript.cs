using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    public Transform startPos;
    public Transform endPos;

    float speed = 0.5f;
    public float startTime;
    public float journeyLength;

    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startPos.position, endPos.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        float fracJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startPos.position, endPos.position, fracJourney);
        transform.rotation = Quaternion.Slerp(startPos.rotation, endPos.rotation, fracJourney);
    }
}
