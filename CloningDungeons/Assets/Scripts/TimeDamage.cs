using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDamage : MonoBehaviour
{
    public float awayhitpower;
    public float uphitpower;
    public TMP_Text showtimepunishment;

    private void Start()
    {
        showtimepunishment = Timer
    }
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
