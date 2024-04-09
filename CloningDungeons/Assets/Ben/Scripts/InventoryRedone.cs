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

    public LayerMask doorLayer;
    public LayerMask chestLayer;

    public int maxDis;
    public bool keyActive;

    // Start is called before the first frame update
    void Start()
    {
        image.gameObject.SetActive(false);
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
        if (hit.collider.gameObject.tag == "Key" && keyActive == false)
        {
            keyActive = true;
            dropKey = hit.collider.gameObject.GetComponent<Keys>().key;   
            image = hit.collider.gameObject.GetComponent<Keys>().keyImage;
            image.gameObject.SetActive(true);
            Destroy(hit.collider.transform.parent.gameObject);
            print("got it");
        }
    }
    void Drop()
    {
        if (keyActive == true)
        {
            keyActive = false;
            image.gameObject.SetActive(false);
            Instantiate(dropKey, cam.position, cam.rotation);
            dropKey = null;
            print("Drop");
        }
    }
    void Use()
    {
        if (dropKey == chestKey && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, chestLayer))
        {
            keyActive = false;
            dropKey = null;
            image.gameObject.SetActive(false);
            hit.collider.gameObject.GetComponent<ChestAnimation>().Use();
        }
        if (dropKey == doorKey && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, doorLayer))
        {
            keyActive = false;
            dropKey = null;
            image.gameObject.SetActive(false);
            hit.collider.gameObject.GetComponent<DoorAnimation>().Use();
        }
    }
}
    

