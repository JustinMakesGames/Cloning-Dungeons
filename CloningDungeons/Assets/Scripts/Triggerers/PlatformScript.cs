using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    private float time = 2f;
    private float endTimer = 2f;


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
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].fullyPressed)
            {
                time = 0;
                for (int x = 0; x < platforms.Count; x++)
                {
                    if (platforms[x].CompareTag(tags[i]))
                    {
                        print("It should fucking work");
                        PlatformChange(platforms[x].gameObject.GetComponent<MeshRenderer>().material,
                            platforms[x].gameObject.GetComponent<Collider>());
                    }
                }
                return;
            }
        }

        time += Time.deltaTime;
        if (time < endTimer)
        {
            return;
        }

        for (int i = 0; i < platforms.Count; i++)
        {
            TurnOffPlatform(
                platforms[i].gameObject.GetComponent<MeshRenderer>().material,
                platforms[i].gameObject.GetComponent<Collider>());
        }
    }

   

    private void PlatformChange(Material material, Collider collider)
    {
   
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1f);
        collider.enabled = true;

    }

    private void TurnOffPlatform(Material material, Collider collider)
    {
        
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
        collider.enabled = false;
    }
}
