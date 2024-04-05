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
    public GameObject chestKeyImage;
    public GameObject doorKeyImage;
    public GameObject dropKey;
    public GameObject doorKey;
    public GameObject chestKey;


    public LayerMask doorLayer;
    public LayerMask chestLayer;

    public int maxDis;
    public bool keyActive;

    // Start is called before the first frame update
    void Start()
    {
        chestKeyImage.gameObject.SetActive(false);
        doorKeyImage.gameObject.SetActive(false);
        keyActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<BigClone>().isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
            {
                Pickup();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Use();
            }
        }
    }
    
    void Pickup()
    {
        if (hit.collider.gameObject.tag == "ChestKey" && keyActive == false)
        {
            keyActive = true;
            chestKeyImage.gameObject.SetActive(true);
            dropKey = chestKey;
            Destroy(hit.collider.transform.parent.gameObject);
        }
        if (hit.collider.gameObject.tag == "DoorKey" && keyActive == false)
        {
            keyActive = true;
            doorKeyImage.gameObject.SetActive(true);
            dropKey = doorKey;
            Destroy(hit.collider.transform.parent.gameObject);
        }
    }
    void Drop()
    {
        if (keyActive == true)
        {
            keyActive = false;
            chestKeyImage.SetActive(false);
            doorKeyImage.SetActive(false);
            Instantiate(dropKey, cam.position, cam.rotation);
            dropKey = null;
        }
    }
    void Use()
    {
        if (dropKey == chestKey && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, chestLayer))
        {
            chestKeyImage.SetActive(false);
            keyActive = false;
            dropKey = null;
            hit.collider.gameObject.GetComponent<ChestAnimation>().Use();
        }
        if (dropKey == doorKey && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, doorLayer))
        {
            doorKeyImage.SetActive(false);
            keyActive = false;
            dropKey = null;
            hit.collider.gameObject.GetComponent<DoorAnimation>().Use();
        }
    }
}
    

