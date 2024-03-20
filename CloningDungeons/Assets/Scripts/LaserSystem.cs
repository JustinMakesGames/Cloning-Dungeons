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
                        lasers[x].GetComponent<TimeDamageHit>().buttonpressed = true;
                        lasers[x].GetComponent<Collider>().enabled = false;
                        lasers[x].GetComponent<MeshRenderer>().enabled = false;
                        print("Laser System works");
                        
                    }
                }
                return;




            }

        }
        for (int i = 0; i < lasers.Count; i++)
        {
            lasers[i].GetComponent<TimeDamageHit>().buttonpressed = false;
            lasers[i].GetComponent<Collider>().enabled = true;
            lasers[i].GetComponent<MeshRenderer>().enabled = true;
            print("Yes");
        }





    }
}
