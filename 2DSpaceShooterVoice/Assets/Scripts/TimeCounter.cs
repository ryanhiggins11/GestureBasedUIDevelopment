using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 *  keeps track of time
 */
public class TimeCounter : MonoBehaviour
{
    Text timeUI;
    float startTime;
    float elapsedTime;
    bool startCounter;
    int minutes;
    int seconds;


    void Start()
    {
        startCounter = false;
        timeUI = GetComponent < Text >();
    }
    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }
    public void StopTimeCounter()
    {
        startCounter = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (startCounter)
        {
            elapsedTime = Time.time - startTime;
            minutes = (int)elapsedTime / 60;
            seconds = (int)elapsedTime % 60;
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
