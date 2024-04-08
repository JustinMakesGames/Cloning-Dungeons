using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsaveSystem : MonoBehaviour
{


    public float range;

    public GameObject playerBig;
    public GameObject playerSmall;

    public GameObject eInteract;
    RaycastHit hit;
    private void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            print("HITTING");
            if(hit.transform.CompareTag("SavePoint"))
            {
                eInteract.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerPrefs.SetFloat("PlayerBigX", playerBig.transform.position.x);
                    PlayerPrefs.SetFloat("PlayerBigY", playerBig.transform.position.y);
                    PlayerPrefs.SetFloat("PlayerBigZ", playerBig.transform.position.z);

                    PlayerPrefs.SetFloat("PlayerSmallX", playerSmall.transform.position.x);
                    PlayerPrefs.SetFloat("PlayerSmallY", playerSmall.transform.position.y);
                    PlayerPrefs.SetFloat("PlayerSmallZ", playerSmall.transform.position.z);
                }
            }
            else
            {
                eInteract.SetActive(false);
            }
        }

        Debug.DrawRay(transform.position, transform.forward * range, Color.red);

    }
}
