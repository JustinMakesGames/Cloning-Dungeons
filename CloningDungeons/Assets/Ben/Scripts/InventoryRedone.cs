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

    public LayerMask doorLayer;
    public LayerMask chestLayer;

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

        if (transform.GetComponent<BigClone>().isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
            {
                if (hit.collider.gameObject.tag == "ChestKey" && doorKeyImage.gameObject.activeInHierarchy == false)
                {
                    chestKeyImage.gameObject.SetActive(true);
                    Destroy(hit.collider.transform.parent.gameObject);
                }
                if (hit.collider.gameObject.tag == "DoorKey" && chestKeyImage.gameObject.activeInHierarchy == false)
                {
                    doorKeyImage.gameObject.SetActive(true);
                    Destroy(hit.collider.transform.parent.gameObject);
                }
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.E) && chestKeyImage.gameObject.activeInHierarchy == true)
                {
                    chestKeyImage.SetActive(false);
                    Instantiate(dropChestKey, cam.position, cam.rotation);
                }
                if (Input.GetKeyDown(KeyCode.E) && doorKeyImage.gameObject.activeInHierarchy == true)
                {
                    doorKeyImage.SetActive(false);
                    Instantiate(dropDoorKey, cam.position, cam.rotation);
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
            {
                if (chestKeyImage.gameObject.activeInHierarchy == true && Physics.Raycast(cam.position, cam.forward, out hit, maxDis,chestLayer))
                {
                    chestKeyImage.SetActive(false);
                    iInteractable script = hit.collider.gameObject.GetComponent<iInteractable>();
                    script.Interactable();
                }   
                if (doorKeyImage.gameObject.activeInHierarchy == true && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, doorLayer))
                {
                    doorKeyImage.SetActive(false);
                    iInteractable script = hit.collider.gameObject.GetComponent<iInteractable>();
                    script.Interactable();
                }
            }
        }
    }
}
    

