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

    [SerializeField] private float[] time = new float[4];
    private float endTimer = 3f;
    private List<int> activatedButtonIndices = new List<int>();

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
            if (buttons[i].fullyPressed && !activatedButtonIndices.Contains(i))
            {
                time[i] = 0f;
                for (int x = 0; x < platforms.Count; x++)
                {
                    if (platforms[x].CompareTag(tags[i]))
                    {
                        PlatformChange(platforms[x].gameObject.GetComponent<MeshRenderer>().material,
                            platforms[x].gameObject.GetComponent<Collider>());
                    }
                }
            }
        }
        
        for (int i = 0; i < buttons.Length; i++)
        {
            if (!buttons[i].fullyPressed && !activatedButtonIndices.Contains(i))
            {

                time[i] += Time.deltaTime;

                if (time[i] > endTimer)
                {
                    for (int x = 0; x < platforms.Count; x++)
                    {
                        if (platforms[x].CompareTag(tags[i]))
                        {
                            TurnOffPlatform(platforms[x].gameObject.GetComponent<MeshRenderer>().material,
                                platforms[x].gameObject.GetComponent<Collider>());
                        }
                    }
                }
                
            }
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

    private void TurnOffAllPlatforms()
    {
        foreach (var platform in platforms)
        {
            TurnOffPlatform(
                platform.gameObject.GetComponent<MeshRenderer>().material,
                platform.gameObject.GetComponent<Collider>());
        }
    }
}