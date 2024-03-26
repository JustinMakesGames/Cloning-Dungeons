using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private string[] tags =
    {
        "Red",
        "Blue",
        "Green",
        "Yellow"

    };


    public Button[] buttons;
    public List<Transform> platforms;



    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            platforms.Add(transform.GetChild(0).GetChild(i));
        }
    }

    private void Update()
    {
        TurningLaserOff();
        TurningLasersOn();
    }

    private void TurningLaserOff()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].fullyPressed)
            {
                for (int x = 0; x < platforms.Count; x++)
                {
                    if (platforms[x].CompareTag(tags[i]))
                    {
                        PlatformChange(platforms[x].GetComponent<MeshRenderer>().material.color,
                            platforms[x].GetComponent<Collider>());
                    }
                }
                return;
            }
        }
    }

    private void TurningLasersOn()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            TurnOffPlatform(
                platforms[i].gameObject.GetComponent<MeshRenderer>().material.color,
                platforms[i].gameObject.GetComponent<Collider>());
        }
    }

    private void PlatformChange(Color colors, Collider collider)
    {
        colors = new Color(colors.r, colors.g, colors.b, 1f);
        collider.enabled = true;

    }

    private void TurnOffPlatform(Color colors, Collider collider)
    {
        colors = new Color(colors.r, colors.g, colors.b, 0.5f);
        collider.enabled = false;
    }
}
