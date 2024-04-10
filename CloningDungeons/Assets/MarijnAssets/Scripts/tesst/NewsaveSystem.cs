using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsaveSystem : MonoBehaviour
{
    public float range;
    public GameObject eInteract;
    public GameObject savedText;
    RaycastHit hit;

    private void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.transform.CompareTag("SavePoint"))
            {
                eInteract.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToSpawnHere.instance.spawnPlace = hit.collider.transform.GetSiblingIndex();
                    PlayerPrefs.SetInt("SavePoint", ToSpawnHere.instance.spawnPlace);

                    print("Saved");
                    StartCoroutine(GameSaved());
                }
            }
            else
            {
                eInteract.SetActive(false);
            }
        }

        Debug.DrawRay(transform.position, transform.forward * range, Color.red);

    }

    IEnumerator GameSaved()
    {
        savedText.SetActive(true);
        yield return new WaitForSeconds(1);
        savedText.SetActive(false);
    }
}
