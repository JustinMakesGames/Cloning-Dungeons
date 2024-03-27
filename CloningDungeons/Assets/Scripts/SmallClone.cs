using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmallClone : Movement
{
    [Header("Dragging")]
    RaycastHit hitSmallClone;
    public LayerMask pickupable;
    public float speedOfPickUp;
    public float maxGrabbingDistance;
    public bool ableToDrag;
    public float camClamp;
    
    public bool isCameraClamped;
    private bool dragging;
    public Transform obj;
    public float distanceFromPosition;
    

    


    public override void Update()
    {
        base.Update();
        if (isPlayer)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hitSmallClone, maxGrabbingDistance, pickupable))
            {
                obj = hitSmallClone.collider.transform;
                ableToDrag = true;
            }

            if (!Input.GetMouseButton(0))
            {
                ableToDrag = false;
                speed = 2000f;
                if (obj != null)
                {
                    obj.GetComponent<Rigidbody>().useGravity = true;

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
            camClamp = script.yRotation;
            distanceFromPosition = Vector3.Distance(transform.position, obj.position);
            isCameraClamped = true;
        }
    }


    void Pickup()
    {      
        Rigidbody objrigid = obj.GetComponent<Rigidbody>();
        Vector3 positiontoBe = new Vector3(cam.position.x, obj.position.y, cam.position.z) + moveCam.forward * distanceFromPosition;
        Vector3 movingplace = positiontoBe - obj.position;
        Vector3 velocity = movingplace * speedOfPickUp * Time.deltaTime;
        objrigid.velocity = velocity;
        speed = 1200f;       
    }    
}
