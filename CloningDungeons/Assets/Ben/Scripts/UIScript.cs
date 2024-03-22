using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{   
    public RaycastHit hit;

    public Transform cam;
    public GameObject chestKeyImage;
    public GameObject doorKeyImage;
    public GameObject dropDoorKey;
    public GameObject dropChestKey;

    public int maxDis;

    // Start is called before the first frame update
    void Start()
    {
        chestKeyImage.SetActive(false);
        doorKeyImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
        {
            if (hit.collider.gameObject.tag == "ChestKey")
            {
                chestKeyImage.gameObject.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && chestKeyImage.gameObject.activeInHierarchy == true) 
        {
            
        }
    }
}
