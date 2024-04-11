using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSystem : MonoBehaviour
{
    private string[] tags =
    {
        "Red",
        "Blue",
        "Green",
        "Yellow"
    };
  

    public Button[] buttons;
    public List<Transform> lasers;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            lasers.Add(transform.GetChild(0).GetChild(i));
        }
    }

    private void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].fullyPressed)
            {
                for (int x = 0; x < lasers.Count; x++)
                {
                    if (lasers[x].CompareTag(tags[i]))
                    {
                        TurningLaserOn(lasers[x]);

                    }
                }
            }
            else
            {
                for (int x = 0; x < lasers.Count; x++)
                {
                    if (lasers[x].CompareTag(tags[i]))
                    {
                        TurningLaserOff(lasers[x]);

                    }
                }
            }
        }

        
    }

    private void TurningLaserOn(Transform laser)
    {
        laser.GetComponent<TimeDamageHit>().buttonPressed = true;
        laser.GetComponent<Collider>().enabled = false;
        laser.GetComponent<MeshRenderer>().enabled = false;
    }
    private void TurningLaserOff(Transform laser)
    {
        laser.GetComponent<TimeDamageHit>().buttonPressed = false;
        laser.GetComponent<Collider>().enabled = true;
        laser.GetComponent<MeshRenderer>().enabled = true;

    }
}

  

