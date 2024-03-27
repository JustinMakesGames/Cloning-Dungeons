using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorKeyFloating : MonoBehaviour
{
    public float rotateSpeed;
    public float range;
    public float floatingSpeed;
    public float moveSpeed;
    Vector3 currentPos;
    public bool ifOpened;
    public Transform endPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.GetComponent<ParticleSystem>().Stop();
        endPosition = transform.parent.parent.GetChild(4).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifOpened)
        {
            if (!transform.parent.GetComponent<ParticleSystem>().isPlaying) 
            {
                transform.parent.GetComponent<ParticleSystem>().Play();
            }
            
            currentPos = transform.parent.position;
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, endPosition.position, moveSpeed * Time.deltaTime);
            float movement = Mathf.Sin(Time.time * floatingSpeed) * range;

            transform.position = currentPos + new Vector3(0, movement, 0);
            transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
        }
        
        
    }
}
