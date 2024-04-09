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

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(SpawnPlayer());
        print(spawnPlace);
        
    }

    

    public IEnumerator SpawnPlayer()
    {
        print("Yes loaded");

        int getSavedInt = PlayerPrefs.GetInt("SavePoint");
        spawnPlace = getSavedInt;
        yield return new WaitForSeconds(0.3f);
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
    }

    
 
    
}
