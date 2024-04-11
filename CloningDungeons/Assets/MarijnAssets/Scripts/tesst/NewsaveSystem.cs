using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsaveSystem : MonoBehaviour
{
    public float range;
    public GameObject eInteract;
    public GameObject savedText;
    private bool isInteracting;

    public TMP_Text timePlus;
    RaycastHit hit;
    private GameObject hitObjectSaved;

    private void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.transform.CompareTag("SavePoint") && !hit.collider.gameObject == hitObjectSaved)
            {
                eInteract.SetActive(true);
                isInteracting = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    AudioScript.instance.audiosources[6].Play();
                    ToSpawnHere.instance.spawnPlace = hit.collider.transform.GetSiblingIndex();
                    PlayerPrefs.SetInt("SavePoint", ToSpawnHere.instance.spawnPlace);
                    hit.collider.transform.GetComponentInChildren<ParticleSystem>().Play();
                    print("Saved");
                    hitObjectSaved = hit.collider.gameObject;
                    StartCoroutine(GameSaved());
                    StartCoroutine(ShowTimePlus());
                }
            }
            else
            {
                if (isInteracting)
                {
                    eInteract.SetActive(false);
                    isInteracting = false;
                }
                
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

    IEnumerator ShowTimePlus()
    {
        timePlus.gameObject.SetActive(true);
        timePlus.text = "+30";
        Timer.timer += 30;      
        yield return new WaitForSeconds(1);
        timePlus.gameObject.SetActive(false);

    }
}
