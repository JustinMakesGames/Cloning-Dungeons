using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float maxDis;
    public InventoryState state;
    public LayerMask keymask;
    public LayerMask chest;
    public RaycastHit hit;
    public Transform cam;
    public GameObject chestKey;
    public GameObject doorKey;
    public GameObject keyprefab;
    public enum InventoryState
    {
        None,
        ChestKey,
        DoorKey

    }
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case InventoryState.None:
                NoneFunction();
                break;
            case InventoryState.DoorKey:
                DoorKeyFunction();
                break;
            case InventoryState.ChestKey:
                ChestKeyFunction();
                break;
        }
    }

    private void NoneFunction()
    {
         if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit,maxDis,keymask))
        {
            if (hit.collider.gameObject.tag == "ChestKey")
            {
                Destroy(hit.collider.gameObject);
                state = InventoryState.ChestKey;
            }

            if (hit.collider.gameObject.tag == "DoorKey")
            {
                Destroy(hit.collider.gameObject);
                state = InventoryState.DoorKey;
            }
        }
    }

    private void ChestKeyFunction()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, chest))
        {
            state = InventoryState.None;
            StartCoroutine(ChestOpen());
        }

            if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(chestKey,cam.position,cam.rotation);
            state = InventoryState.None;
        }
    }

    private void DoorKeyFunction()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(doorKey, cam.position,cam.rotation);
            state = InventoryState.None;
        }
    }

    IEnumerator ChestOpen()
    {
        Transform chest = hit.collider.gameObject.transform;
        Transform chestlid = chest.parent.GetChild(0);
        Transform spawnobject = chest.parent.GetChild(2);
        DoorKeyFloating doorkey = chest.parent.GetComponentInChildren<DoorKeyFloating>();

        GameObject key = Instantiate(keyprefab, spawnobject.position,
            Quaternion.identity, chest.parent);

        key.transform.localRotation = Quaternion.Euler(0, 180, 0);
        Animator keyanimator = key.transform.GetChild(0).GetComponent<Animator>();
        Animator chestanimator = chestlid.GetComponent<Animator>();


        keyanimator.Play("KeyGoingin");
        yield return new WaitForSeconds(2);
        Destroy(key);
        chestanimator.Play("ChestDeksel");
        yield return new WaitForSeconds(1);
        doorkey.ifopened = true;

    }
}
