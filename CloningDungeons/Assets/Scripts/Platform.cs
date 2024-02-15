using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Platform : MonoBehaviour
{

    public GameObject[] platforms;

    private void Start()
    {
        if (gameObject.tag == "RedButton")
        {
            platforms = GameObject.FindGameObjectsWithTag("Red");
        }
        else if (gameObject.tag == "GreenButton")
        {
            platforms = GameObject.FindGameObjectsWithTag("Green");
        }
        else if (gameObject.tag == "BlueButton")
        {
            platforms = GameObject.FindGameObjectsWithTag("Blue");
        }
        else if (gameObject.tag == "YellowButton")
        {
            platforms = GameObject.FindGameObjectsWithTag("Yellow");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            foreach (GameObject color in platforms)
            {
                color.GetComponent<BoxCollider>().enabled = true;
                Renderer render = color.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r,render.material.color.g,render.material.color.b,1f);
                
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            foreach (GameObject color in platforms)
            {
                color.GetComponent<BoxCollider>().enabled = false;
                Renderer render = color.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, render.material.color.g, render.material.color.b, 0.5f);
            }
        }
    }
}
