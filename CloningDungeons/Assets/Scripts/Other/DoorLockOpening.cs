using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockOpening : MonoBehaviour
{
    public LayerMask door;
    public float maxDis;
    public Transform cam;
    public GameObject openLock;
    public GameObject key;
    public RaycastHit hit;


    private void Start()
    {
        cam = GameObject.Find("MainCamera").transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.position, cam.forward, out hit, maxDis, door))
        {
            StartCoroutine(DoorLockOpeningFunction());
        }
    }

    private IEnumerator DoorLockOpeningFunction()
    {
        
        Transform lockclosed = hit.collider.gameObject.transform;
        Transform door = lockclosed.parent.GetChild(2).GetChild(0);

        Transform spawnobject = lockclosed.parent.GetChild(1);
        Transform spawnkey = lockclosed.parent.GetChild(3);



        GameObject keyclone = Instantiate(key, spawnkey.position, Quaternion.identity, lockclosed.parent);
        Animator keyanimator = keyclone.GetComponentInChildren<Animator>();
        Animator dooranimator = door.GetComponent<Animator>();
        keyanimator.Play("KeyGoingin");
        yield return new WaitForSeconds(2);
        Destroy(keyclone);
        Destroy(lockclosed.gameObject);
        GameObject openlockclone = Instantiate(openLock, spawnobject.position, Quaternion.Euler(0,180,0));
        yield return new WaitForSeconds(1);
        dooranimator.Play("DoorOpening");
        yield return new WaitForSeconds(2);
        Destroy(openlockclone);






    }





}
