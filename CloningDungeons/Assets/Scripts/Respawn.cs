using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform bigClone;
    public Transform smallClone;

    private void Start()
    {
        bigClone = GameObject.Find("Clones").transform.GetChild(0);
        smallClone = GameObject.Find("Clones").transform.GetChild(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer.timer -= 30;
            bigClone.position = transform.GetChild(0).position;
            smallClone.position = transform.GetChild(1).position;



        }
    }
}
