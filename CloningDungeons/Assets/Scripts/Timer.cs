using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timer;
    public TMP_Text timertext;


    private void Start()
    {
        timer = 300f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        TimerCountdown();
    }

    void TimerCountdown()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timertext.text = minutes.ToString() + ":" + seconds.ToString();
    }
}
