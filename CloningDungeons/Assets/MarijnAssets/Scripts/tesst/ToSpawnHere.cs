using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ToSpawnHere : MonoBehaviour
{
    public static ToSpawnHere instance;
    public Transform bigClone;
    public Transform smallClone;
    public int spawnPlace;

    Rigidbody bigRb;
    Rigidbody smallRb;

    private void Awake()
    {
        instance = this;
        bigRb = bigClone.GetComponent<Rigidbody>();
        smallRb = smallClone.GetComponent<Rigidbody>();
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("SavePoint"))
        {
            StartCoroutine(SpawnPlayer());
        }
        else
        {
            bigRb.constraints = ~RigidbodyConstraints.FreezePosition;
            smallRb.constraints = ~RigidbodyConstraints.FreezePosition;
            Camera.main.transform.GetComponent<CameraComponent>().enabled = true;
        }
        
        print(spawnPlace);
        
    }

    

    public IEnumerator SpawnPlayer()
    {
        print("Yes loaded");

        int getSavedInt = PlayerPrefs.GetInt("SavePoint");
        spawnPlace = getSavedInt;

        yield return new WaitForSeconds(0.4f);

        
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == spawnPlace)
            {
                print(i + " is the right number to spawn to");
                bigClone.position = transform.GetChild(i).GetChild(0).position;
                smallClone.position = transform.GetChild(i).GetChild(1).position;
                break;
            }
        }

        yield return new WaitForSeconds(0.2f);

        bigRb.constraints = ~RigidbodyConstraints.FreezePosition;
        smallRb.constraints = ~RigidbodyConstraints.FreezePosition;
        Camera.main.transform.GetComponent<CameraComponent>().enabled = true;
    }

    
 
    
}
