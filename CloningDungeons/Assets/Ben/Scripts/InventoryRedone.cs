using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class InventoryRedone : MonoBehaviour
{
    public RaycastHit hit;

    public Transform cam;
    public GameObject image;
    public GameObject dropKey;
    public GameObject doorKey;
    public GameObject chestKey;

    public GameObject eInteractingKey;

    public GameObject eInteractDoor;
    public LayerMask interactLayer;

    public int maxDis;
    public bool keyActive;

    
    void Start()
    {
        keyActive = false;
        dropKey = null;
        eInteractingKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<BigClone>().isPlayer)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
            {
                if (hit.collider.gameObject.CompareTag("Key") && keyActive == false)
                {
                    eInteractingKey.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        eInteractingKey.SetActive(false);
                        Pickup();
                    }
                }
                else
                {
                    eInteractingKey.SetActive(false);
                }

            }
            

            Use();
        }
    }
    
    void Pickup()
    {
        AudioScript.instance.audiosources[4].Play();
        keyActive = true;
        dropKey = hit.collider.gameObject.GetComponent<Keys>().key;
        image = hit.collider.gameObject.GetComponent<Keys>().keyImage;
        image.gameObject.SetActive(true);
        Destroy(hit.collider.transform.parent.gameObject);
    }
    void Use()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDis, interactLayer) && dropKey != null) 
        {
            eInteractDoor.SetActive(true);
            if (dropKey == chestKey)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.gameObject.tag == "Chest")
                    {
                        keyActive = false;
                        dropKey = null;
                        image.gameObject.SetActive(false);
                        image = null;
                        hit.collider.gameObject.GetComponent<InteractionAnimations>().ChestOpenInteract();
                    }
                }

            }
            if (dropKey == doorKey)
            {
                if (hit.collider.gameObject.tag == "Door")
                {
                    keyActive = false;
                    dropKey = null;
                    image.gameObject.SetActive(false);
                    image = null;
                    hit.collider.gameObject.GetComponent<InteractionAnimations>().DoorOpenInteract();
                }
            }
        }
        else
        {
            eInteractDoor.SetActive(false);
        }
        
    }
}
    

