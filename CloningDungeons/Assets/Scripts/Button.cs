using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private Vector3 startposition;
    private Vector3 endposition;
    public float buttonSpeed;
    public float howmuchPressed;
    private bool pressed;
    private bool fullyPressed;
    public float howMuchDistance;

    private void Start()
    {
        startposition = transform.position;
        endposition = new Vector3(transform.position.x, transform.position.y - howmuchPressed, transform.position.z);
    }
    private void Update()
    {
        if (pressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, endposition, buttonSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endposition) < howMuchDistance)
            {
                fullyPressed = true;
            }

            
        }
        else
        {
            fullyPressed = false;
            transform.position = Vector3.MoveTowards(transform.position, startposition, buttonSpeed * Time.deltaTime);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            pressed = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            pressed = false;
        }
    }


}
