using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsaveSystem : MonoBehaviour
{

    public GameObject cameraPoint;
    public int range;
    public GameObject player;
    public Button loadButton;


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
                    PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
                    PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
                    PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                eInteract.SetActive(false);
            }
        }
        
    }
}
