using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DoorAnimation : MonoBehaviour, iInteractable
{
    public GameObject doorKey;
    public GameObject openLock;

    public void interactable()
    {
        StartCoroutine(DoorOpen());
    }
    private IEnumerator DoorOpen()
    {

        Transform lockclosed = transform;
        Transform door = lockclosed.parent.GetChild(2).GetChild(0);

        Transform spawnobject = lockclosed.parent.GetChild(1);
        Transform spawnkey = lockclosed.parent.GetChild(3);



        GameObject keyclone = Instantiate(doorKey, spawnkey.position, Quaternion.identity, lockclosed.parent);
        Animator keyanimator = keyclone.GetComponentInChildren<Animator>();
        Animator dooranimator = door.GetComponent<Animator>();
        keyanimator.Play("KeyGoingin");
        yield return new WaitForSeconds(2);
        Destroy(keyclone);
        lockclosed.GetComponent<MeshRenderer>().enabled = false;
        GameObject openlockclone = Instantiate(openLock, spawnobject.position, Quaternion.Euler(0, 180, 0));
        yield return new WaitForSeconds(1);
        dooranimator.Play("DoorOpening");
        yield return new WaitForSeconds(2);
        Destroy(openlockclone);
        Destroy(lockclosed.gameObject);
    }
}
