using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryRedone : MonoBehaviour
{   
    public RaycastHit hit;

    public Transform cam;
    public GameObject chestKeyImage;
    public GameObject doorKeyImage;
    public GameObject dropDoorKey;
    public GameObject dropChestKey;

    public LayerMask doorlayer;

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
        if (Input.GetKeyDown(KeyCode.E) && doorKeyImage.gameObject.activeInHierarchy == false && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
        {
            if (hit.collider.gameObject.tag == "ChestKey")
            {
                chestKeyImage.gameObject.SetActive(true);
                Destroy(hit.collider.transform.parent.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && chestKeyImage.gameObject.activeInHierarchy == false && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
        {
            if (hit.collider.gameObject.tag == "DoorKey")
            {
                doorKeyImage.gameObject.SetActive(true);
                Destroy(hit.collider.transform.parent.gameObject);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G) && chestKeyImage.gameObject.activeInHierarchy == true)
            {
                chestKeyImage.SetActive(false);
                Instantiate(dropChestKey, cam.position, cam.rotation);
            }
            if (Input.GetKeyDown(KeyCode.G) && doorKeyImage.gameObject.activeInHierarchy == true)
            {
                doorKeyImage.SetActive(false);
                Instantiate(dropDoorKey, cam.position, cam.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
        {
            if (hit.collider.gameObject.tag == "Chest" && chestKeyImage.gameObject.activeInHierarchy == true)
            {
                chestKeyImage.SetActive(false);
                iInteractable script = hit.collider.gameObject.GetComponent<iInteractable>();
                script.Interactable();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, doorlayer))
        {
            
            
                doorKeyImage.SetActive(false);
                iInteractable doorscript = hit.collider.gameObject.GetComponent<iInteractable>();
                doorscript.Interactable();
            
        }
    }
    
    
}
