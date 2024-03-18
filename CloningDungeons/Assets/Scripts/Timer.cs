using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timer;
    public TMP_Text timertext;
    public bool cutscene;
    public GameObject blackscreen;
    public Image image;
    private Color black;
    [SerializeField] private float blackscreenspeed;
    private bool blackscreenhappened;

    private void Start()
    {
        timer = 3f;
        image = blackscreen.GetComponent<Image>();
        black = image.color;

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
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60.0f);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            timertext.text = minutes.ToString() + ":" + seconds.ToString("00");
        }
        

        if (timer <= 0)
        {
            if (!blackscreenhappened)
            {
                image.color += new Color(0, 0, 0, blackscreenspeed * Time.deltaTime);
                if (image.color.a >= 1f)
                {
                    blackscreenhappened = true;
                }
            }
            

            if (blackscreenhappened)
            {
                image.color -= new Color(0, 0, 0, blackscreenspeed * Time.deltaTime);
            }


            
        }
    }
}
