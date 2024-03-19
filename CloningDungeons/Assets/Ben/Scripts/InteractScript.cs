using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class InteractScript : MonoBehaviour
{
    public InventoryScriptableObj item;

    public RaycastHit hit;

    public Transform cam;
    public GameObject dropKey;
    public LayerMask layerMask;

    public int maxDis;
    

    private void Start()
    {
        cam = GameObject.Find("MainCamera").transform;
    }

    private void Update()
    {
        KeepValues();
        Interact();
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
        {
             if (hit.collider.gameObject.tag == "ChestKey")
             {
                Destroy(hit.collider.transform.parent.gameObject);
                item = Resources.Load<InventoryScriptableObj>("ChestKeyData");
             }
        }     
        if (Input.GetKeyDown(KeyCode.G) && item != null)
        {
            Instantiate(dropKey, cam.position, cam.rotation);
            item = null;
        }

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis))
        {
            if (hit.collider.gameObject.tag == "DoorKey")
            {
                Destroy(hit.collider.transform.parent.gameObject);
                item = Resources.Load<InventoryScriptableObj>("DoorKeyData");
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && item != null)
        {
            Instantiate(dropKey, cam.position, cam.rotation);
            item = null;
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, layerMask))
        {
            if (hit.collider.gameObject.GetComponent<iInteractable>() != null)
            {
                iInteractable script = hit.collider.gameObject.GetComponent<iInteractable>();
                script.interactable();
            }
        }
    }

    private void KeepValues ()
    {
        if (item != null)
        {
            dropKey = item.itemPrefab;
            layerMask = item.layerMask;
        }
        else 
        {
            dropKey = null;
            layerMask = 0;  
        }
    }
}

