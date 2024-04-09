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

    private float time = 2f;
    private float endTimer = 2f;
    private List<int> activatedButtonIndices = new List<int>(); // Store the indices of activated buttons

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
                activatedButtonIndices.Add(i);
                time = 0;
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

        time += Time.deltaTime;
        if (time >= endTimer)
        {
            TurnOffAllPlatforms();
            activatedButtonIndices.Clear();
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