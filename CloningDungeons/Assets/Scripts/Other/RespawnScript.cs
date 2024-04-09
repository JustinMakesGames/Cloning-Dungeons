using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDamage : MonoBehaviour
{
    public float awayHitPower;
    public float upHitPower;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "SmallPlayer")
        {
            Transform player = collision.collider.transform;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            Timer.timer -= 10f;
            

        }

    }
}
