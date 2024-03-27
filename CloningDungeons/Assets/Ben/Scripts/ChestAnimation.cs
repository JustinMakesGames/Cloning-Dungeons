using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ChestAnimation : MonoBehaviour, iInteractable
{
    public GameObject chestKey;
    
    public void Interactable()
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
