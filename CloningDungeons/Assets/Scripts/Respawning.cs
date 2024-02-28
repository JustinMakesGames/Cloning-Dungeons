using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    public bool respawntime;
    public bool toRespawnHere;
    Transform bigclone;
    Transform smallclone;
    Transform bigclonespawn;
    Transform smallclonespawn;
    // Start is called before the first frame update
    void Start()
    {
        bigclone = GameObject.Find("Clones").transform.GetChild(0);
        smallclone = GameObject.Find("Clones").transform.GetChild(1);
        bigclonespawn = transform.GetChild(0);
        smallclonespawn = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (respawntime && toRespawnHere) 
        {
            bigclone.position = bigclonespawn.position;
            smallclone.position = smallclonespawn.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "SmallPlayer")
        {
            toRespawnHere = true;
        }
    }
}
