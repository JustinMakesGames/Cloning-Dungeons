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
            SpawnPlayer();
        }
        
        
        print(spawnPlace);
        
    }

    

    public void SpawnPlayer()
    {
        print("Yes loaded");

        int getSavedInt = PlayerPrefs.GetInt("SavePoint");
        spawnPlace = getSavedInt;


        
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == spawnPlace)
            {
                print(i + " is the right number to spawn to");
                bigRb.position = transform.GetChild(i).GetChild(0).position;
                smallRb.position = transform.GetChild(i).GetChild(1).position;
                break;
            }
        }


        
    }

    
 
    
}
