using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ToSpawnHere : MonoBehaviour
{
    public Transform bigClone;
    public Transform smallClone;
    public int spawnPlace;

    
    void Start()
    {
        StartCoroutine(SpawnPlayer());
        print(spawnPlace);
        
    }

    

    public IEnumerator SpawnPlayer()
    {
        
        print("Yes loaded");
        PlayerData data = SaveSystem.LoadPlayer();

         
        spawnPlace = data.toSpawnhere;
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

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);

       
    }
 
    
}
