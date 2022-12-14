using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TMP_Text timerCounter;

    private TimeSpan timePlaying;

    private float elapsedTime;

    // Start is called before the first frame update
    private void Start()
    {
        timerCounter.text = "Time: 05:00.00";
        elapsedTime = 300f;
    }
 
    // Update is called once per frame
    void Update()
    {
        elapsedTime -= Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        timerCounter.text = timePlayingStr;
    }
}
