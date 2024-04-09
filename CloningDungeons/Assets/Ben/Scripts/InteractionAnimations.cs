using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InteractionAnimations : MonoBehaviour
{
    public GameObject chestKey;
    public GameObject doorKey;
    public GameObject openLock;

    public void DoorOpenInteract()
    {
        StartCoroutine(DoorOpen());
    }
    private IEnumerator DoorOpen()
    {

        Transform lockclosed = transform;
        Transform door = lockclosed.parent.GetChild(2).GetChild(0);

        Transform spawnobject = lockclosed.parent.GetChild(1);
        Transform spawnkey = lockclosed.parent.GetChild(3);

        AudioScript.instance.audiosources[2].Play();
        GameObject keyclone = Instantiate(doorKey, spawnkey.position, spawnkey.rotation, lockclosed.parent);
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

    public void ChestOpenInteract()
    {
        StartCoroutine(ChestOpen());
    }

    public IEnumerator ChestOpen()
    {
        Transform chest = transform;
        Transform chestlid = chest.parent.GetChild(0);
        Transform spawnobject = chest.parent.GetChild(2);
        DoorKeyFloating doorkey = chest.parent.GetComponentInChildren<DoorKeyFloating>();

        GameObject key = Instantiate(chestKey, spawnobject.position,
            Quaternion.identity, chest.parent);

        key.transform.localRotation = Quaternion.Euler(0, 180, 0);
        Animator keyanimator = key.transform.GetChild(0).GetComponent<Animator>();
        Animator chestanimator = chestlid.GetComponent<Animator>();


        keyanimator.Play("KeyGoingin");
        yield return new WaitForSeconds(2);
        Destroy(key);
        chestanimator.Play("ChestDeksel");
        yield return new WaitForSeconds(1);
        doorkey.ifOpened = true;

    }
}
