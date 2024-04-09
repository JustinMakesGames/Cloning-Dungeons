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

    public GameObject bigclone;
    public GameObject smallclone;

    public GameObject gameoverscreen;







    private void Start()
    {
        timer = 300f;
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
        

        if (timer <= 1)
        {
            if (!blackscreenhappened)
            {
                image.color += new Color(0, 0, 0, blackscreenspeed * Time.deltaTime);
                if (image.color.a >= 1f)
                {
                    blackscreenhappened = true;
                    gameoverscreen.SetActive(true);
                }
            }
            

            if (blackscreenhappened)
            {
                image.color -= new Color(0, 0, 0, blackscreenspeed * Time.deltaTime);

                List<MonoBehaviour> movementclasses = FindScripts();

                for (int i = 0; i < movementclasses.Count; i++)
                {
                    movementclasses[i].enabled = false;
                    
                }

                
                


            }

            if (blackscreenhappened && image.color.a < 0.01f)
            {
                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                blackscreen.SetActive(false);
                
            }


            
        }
    }

    List<MonoBehaviour> FindScripts()
    {
        List<MonoBehaviour> scripts = new List<MonoBehaviour>();
        BigClone bigclonescript = bigclone.GetComponent<BigClone>();
        SmallClone smallclonescript = smallclone.GetComponent<SmallClone>();

        scripts.Add(bigclonescript);
        scripts.Add(smallclonescript);

        return scripts;
        
    }




}
