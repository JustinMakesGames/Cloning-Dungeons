using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timer;
    public TMP_Text timertext;
    public bool cutscene;

    private void Start()
    {
        timer = 300f;
    }

    void Update()
    {
        if (!cutscene)
        {
            TimerCountdown();
        }
        
    }

    //FloorToInt zorgt ervoor dat ie getal omlaag afrondt
    void TimerCountdown()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timertext.text = minutes.ToString() + ":" + seconds.ToString("00");
    }
}
