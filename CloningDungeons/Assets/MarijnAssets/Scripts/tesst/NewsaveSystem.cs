using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsaveSystem : MonoBehaviour
{

    public GameObject cameraPoint;
    public int range;

    public GameObject playerBig;
    public GameObject playerSmall;

    public GameObject eInteract;

    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraPoint.transform.position, cameraPoint.transform.forward, out hit, range))
        {
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

    }
}
