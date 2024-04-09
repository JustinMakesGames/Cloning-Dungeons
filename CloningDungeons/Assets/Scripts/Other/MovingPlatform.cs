using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Button[] buttons;
    public float speed;
    Transform platform;
    Rigidbody platformRb;
    // Start is called before the first frame update
    void Start()
    {
        
        buttons = GetComponentsInChildren<Button>();
        platform = transform.GetChild(0);
        platformRb = platform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool buttonpressed = false;
        foreach (Button button in buttons)
        {
            if (button.fullyPressed)
            {
                buttonpressed = true;
                if (button.transform.parent.name == "Forward")
                {
                    platformRb.velocity = platform.forward * speed * Time.deltaTime;
                }
                else if (button.transform.parent.name == "Right")
                {
                    platformRb.velocity = platform.right * speed * Time.deltaTime;
                }
                else if (button.transform.parent.name == "Left")
                {
                    platformRb.velocity = -platform.right * speed * Time.deltaTime;
                }
                else if (button.transform.parent.name == "Backwards")
                {
                    platformRb.velocity = -platform.forward * speed * Time.deltaTime;
                }
            }
            
        }

        if (!buttonpressed)
        {
            platformRb.velocity = Vector3.zero;
        }
    }
}
