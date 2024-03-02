using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Button[] buttons;
    public float speed;
    Transform platform;
    Rigidbody platformrb;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        platform = transform.GetChild(0);
        platformrb = platform.GetComponent<Rigidbody>();
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
                    platformrb.velocity = platform.forward * speed * Time.deltaTime;
                }
                else if (button.transform.parent.name == "Right")
                {
                    platformrb.velocity = platform.right * speed * Time.deltaTime;
                }
                else if (button.transform.parent.name == "Left")
                {
                    platformrb.velocity = -platform.right * speed * Time.deltaTime;
                }
                else if (button.transform.parent.name == "Backwards")
                {
                    platformrb.velocity = -platform.forward * speed * Time.deltaTime;
                }
            }
            
        }

        if (!buttonpressed)
        {
            platformrb.velocity = Vector3.zero;
        }
    }
}
