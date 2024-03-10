using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallClone : Movement
{
    [Header("Dragging")]
    RaycastHit hit;
    public LayerMask pickupable;
    public float speedofpickup;
    public float maxgrabbingdistance;
    public bool ableToDrag;
    public float camclamp;
    
    public bool isCameraClamped;
    private bool dragging;
    public Transform obj;
    public float distancefromposition;

    


    public override void Update()
    {
        base.Update();
        if (isPlayer)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, maxgrabbingdistance, pickupable))
            {
                
             
                obj = hit.collider.transform;
                obj.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ableToDrag = true;


            }

            else if (!Physics.Raycast(cam.position, cam.forward, out hit, maxgrabbingdistance, pickupable) && !Input.GetMouseButton(0))
            {

                ableToDrag = false;
                speed = 2000f;
                if (obj != null)
                {
                    obj.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");

                }
                obj = null;
            }

            if (ableToDrag)
            {
                if (Input.GetMouseButton(0))
                {
                    dragging = true;
                }

            }

            else
            {
                isCameraClamped = false;
                dragging = false;

            }

            if (Input.GetKeyDown(KeyCode.F) && ableToDrag)
            {
                obj.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            }
        }
        else
        {
            isCameraClamped = false;
            dragging = false;
        }
        
       

    }



    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isPlayer)
        {
            if (dragging)
            {
                CameraClamping();
                Pickup();
            }
        }
        
        

    }
    void CameraClamping()
    {
        if (!isCameraClamped)
        {
            
            camclamp = script.yRotation;
            distancefromposition = Vector3.Distance(transform.position, obj.position);
            isCameraClamped = true;
        }
    }


    void Pickup()
    {


        
        Rigidbody objrigid = obj.GetComponent<Rigidbody>();

        
        Vector3 positiontoBe = new Vector3(cam.position.x, obj.position.y, cam.position.z) + movecam.forward * distancefromposition;
        Vector3 movingplace = positiontoBe - obj.position;

        Vector3 velocity = movingplace * speedofpickup * Time.deltaTime;

        objrigid.velocity = velocity;


        speed = 1200f;

        
 
        

        




        
    }

    
}
