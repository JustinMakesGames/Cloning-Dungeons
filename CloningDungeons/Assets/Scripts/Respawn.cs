using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform bigclone;
    public Transform smallclone;

    private void Start()
    {
        bigclone = GameObject.Find("Clones").transform.GetChild(0);
        smallclone = GameObject.Find("Clones").transform.GetChild(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("SmallPlayer"))
        {
            Timer.timer -= 30;
            bigclone.position = transform.GetChild(0).position;
            smallclone.position = transform.GetChild(1).position;



        }
    }
}
