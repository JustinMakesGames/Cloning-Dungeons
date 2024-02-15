using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallClone : Movement
{
    RaycastHit hit;
    public LayerMask pickupable;
    public float speedofpickup;
    public float maxdistance;
    public bool ableToDrag;
    
    public Transform obj;
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (Physics.Raycast(cam.position, cam.forward, out hit, 2f, pickupable))
        {
            
            obj = hit.collider.transform;
            ableToDrag = true;
        }

        else if (!Physics.Raycast(cam.position, cam.forward, out hit, 2f, pickupable) && !Input.GetMouseButton(0))
        {
            
            ableToDrag = false;
            speed = 1000f;
        }
        

        if (ableToDrag)
        {
            if (Input.GetMouseButton(0))
            {
                Pickup();
            }
            
        }

       
        
        
    }


    void Pickup()
    {

        
        
        Rigidbody objrigid = obj.GetComponent<Rigidbody>();
        
        Vector3 positiontoBe = new Vector3(cam.position.x, obj.position.y, cam.position.z) + movecam.forward * 0.5f;
        Vector3 movingplace = positiontoBe - obj.position;

        Vector3 velocity = movingplace * speedofpickup * Time.deltaTime;

        objrigid.velocity = velocity;


        speed = 700f;




        
    }

    
}
