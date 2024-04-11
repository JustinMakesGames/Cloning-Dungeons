using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDamageHit : MonoBehaviour
{
    public float awayHitPower;
    public float upHitPower;
    public TMP_Text showTimePunishment;
    public bool buttonPressed;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "SmallPlayer")
        {
            if (!buttonPressed)
            {
                Transform player = collision.collider.transform;
                Rigidbody rb = player.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                Timer.timer -= 10f;
                StartCoroutine(ShowingText());
                ContactPoint contact = collision.contacts[0];
                Vector3 contactposition = contact.point;
                Vector3 movetowards = player.position - contactposition;
                
                rb.AddForce(movetowards.normalized * awayHitPower + new Vector3(0, upHitPower, 0), ForceMode.Impulse);
            }
            


        }

    }

    IEnumerator ShowingText()
    {
        showTimePunishment.gameObject.SetActive(true);
        showTimePunishment.text = "-10";
        yield return new WaitForSeconds(1);
        showTimePunishment.gameObject.SetActive(false);

    }
}
