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
        

        if (!dooropened)
        {
            foreach (Button b in buttonscripts)
            {
                if (!b.fullyPressed)
                {
                    dooropened = false;
                    break;
                }
            }

            dooropened = true;
        }
        

        if (dooropened)
        {
            print("Cool");
            
            

        }

        
    }
}
