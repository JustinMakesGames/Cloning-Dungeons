using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ToSpawnHere : MonoBehaviour
{
    public Transform bigclone;
    public Transform smallclone;
    public int toSpawnhere;

    
    void Start()
    {
        StartCoroutine(SpawnPlayer());
        print(toSpawnhere);
        
    }

    

    public IEnumerator SpawnPlayer()
    {
        
        print("Yes loaded");
        PlayerData data = SaveSystem.LoadPlayer();

         
        toSpawnhere = data.toSpawnhere;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == toSpawnhere)
            {
                print(i + " is the right number to spawn to");
                bigclone.position = transform.GetChild(i).GetChild(0).position;
                smallclone.position = transform.GetChild(i).GetChild(1).position;
                break;
            }
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
 
    
}
