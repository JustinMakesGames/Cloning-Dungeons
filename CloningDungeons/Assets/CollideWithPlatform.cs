using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlatform : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player") 
            || collision.collider.gameObject.layer == LayerMask.NameToLayer("SmallPlayer"))
        {
            collision.collider.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.transform.parent == transform)
        {
            Transform clones = GameObject.Find("Clones").transform;
            collision.collider.transform.parent = clones;
        }
    }
}
