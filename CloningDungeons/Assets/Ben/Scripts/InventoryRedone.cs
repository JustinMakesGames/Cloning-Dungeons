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

    public LayerMask interactLayer;

    public int maxDis;
    public bool keyActive;

    // Start is called before the first frame update
    void Start()
    {
        keyActive = false;
        dropKey = null;
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

            if (Input.GetKeyDown(KeyCode.J))
            {
                keyActive = false;
                dropKey = null;
                image = null;
                image.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Use();
            }
        }
    }
    
    void Pickup()
    {
        if (hit.collider.gameObject.tag == "Key" && keyActive == false)
        {
            keyActive = true;
            dropKey = hit.collider.gameObject.GetComponent<Keys>().key;   
            image = hit.collider.gameObject.GetComponent<Keys>().keyImage;
            image.gameObject.SetActive(true);
            Destroy(hit.collider.transform.parent.gameObject);
        }
    }
    void Use()
    {
        if (dropKey == chestKey && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, interactLayer))
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
        if (dropKey == doorKey && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, interactLayer))
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
}
    

