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
    public GameObject chestKey;
    public GameObject doorKey;
    public LayerMask layerMask;

    public int maxDis;
    

    private void Start()
    {
        cam = GameObject.Find("MainCamera").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, layerMask))
        {
           Destroy(hit.collider.transform.parent.gameObject);
           item = Resources.Load<InventoryScriptableObj>("ChestKeyData");
        }     
        if (Input.GetKeyDown(KeyCode.G) && item != null)
        {
            Instantiate(chestKey, cam.position, cam.rotation);
            item = null;
        }
    }
}

