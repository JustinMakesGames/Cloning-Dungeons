using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int toSpawnhere;

    public PlayerData(ToSpawnHere toSpawn)
    {
        toSpawnhere = toSpawn.toSpawnhere;
    }


    
    
}
