using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Button[] buttonscripts;
    public bool dooropened;

    private void Start()
    {
        buttonscripts = GetComponentsInChildren<Button>();
    }

    private void Update()
    {
        bool dooropened = true;
        foreach (Button b in buttonscripts)
        {
            if (!b.fullyPressed)
            {
                dooropened = false;
                break;
            }
        }

        if (dooropened)
        {
            print("Cool");
            transform.GetChild(0).transform.Translate(0, 1 * Time.deltaTime, 0);

        }

        
    }
}
