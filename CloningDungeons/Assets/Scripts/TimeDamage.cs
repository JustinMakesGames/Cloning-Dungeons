using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDamageHit : MonoBehaviour
{
    public float awayhitpower;
    public float uphitpower;
    public TMP_Text showtimepunishment;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "SmallPlayer")
        {
            Transform player = collision.collider.transform;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            Timer.timer -= 10f;
            ContactPoint contact = collision.contacts[0];
            Vector3 contactposition = contact.point;
            Vector3 movetowards = player.position - contactposition;

            rb.AddForce(movetowards.normalized * awayhitpower + new Vector3(0,uphitpower,0), ForceMode.Impulse);


        }

    }
}
