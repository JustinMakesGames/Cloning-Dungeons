using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorKeyFloating : MonoBehaviour
{
    public float rotatespeed;
    public float range;
    public float floatingspeed;
    public float movespeed;
    Vector3 currentpos;
    public bool ifopened;
    public Transform endposition;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.GetComponent<ParticleSystem>().Stop();
        endposition = transform.parent.parent.GetChild(4).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifopened)
        {
            if (!transform.parent.GetComponent<ParticleSystem>().isPlaying) 
            {
                transform.parent.GetComponent<ParticleSystem>().Play();
            }
            
            currentpos = transform.parent.position;
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, endposition.position, movespeed * Time.deltaTime);
            float movement = Mathf.Sin(Time.time * floatingspeed) * range;

            transform.position = currentpos + new Vector3(0, movement, 0);
            transform.Rotate(new Vector3(0, rotatespeed, 0) * Time.deltaTime);
        }
        
        
    }
}
