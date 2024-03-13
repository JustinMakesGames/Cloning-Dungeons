using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigClone : Movement
{
    [Header("BigCloneOnly")]
    RaycastHit hit;
    public LayerMask smallclone;
    public LayerMask pickup;
    public float maxDistance;
    public bool isGrabbing;
    public Transform objtoGet;

    //Inventory
    public bool inventoryspace;
    public LayerMask key;
    public LayerMask chest;
    

    
    public override void Update()
    {
        base.Update();
        if (isPlayer)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, smallclone) ||
                Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, pickup))
            {
                if (Input.GetKeyDown(KeyCode.E) && !isGrabbing)
                {
                    isGrabbing = true;
                    objtoGet = hit.collider.gameObject.transform;
                }
             


            }


            if (isGrabbing && Input.GetKeyDown(KeyCode.Q))
            {
                Throw(objtoGet);
            }

            

          
        }
        




    }


    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isPlayer)
        {
            if (isGrabbing)
            {
                GrabPlayer(objtoGet);
            }
        }
        
       
    }


    public float stuckagainstwalldistance;
    public float numberawayfromobject;
    void GrabPlayer(Transform obj)
    {

        
        float movespeed = 10f;
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();
        
        
        
        rigidobj.useGravity = false;
        rigidobj.isKinematic = true;
        

        Vector3 targetposition = cam.position + cam.forward * maxDistance;
        if (Physics.Raycast(obj.position, targetposition - obj.position, out hit, stuckagainstwalldistance))
        {
            Vector3 newtargetposition = (obj.position - targetposition).normalized * numberawayfromobject;
            targetposition = hit.point + newtargetposition;
            
        }
        Vector3 lerping = Vector3.Lerp(obj.position, targetposition, movespeed * Time.deltaTime);
        rigidobj.MovePosition(lerping);
        

        
    }

    public float throwingForceForward;
    
    void Throw(Transform obj)
    {
        

        
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();
        rigidobj.useGravity = true;
        rigidobj.isKinematic = false;
    
        rigidobj.AddForce(cam.forward * throwingForceForward, ForceMode.Impulse);
        
        isGrabbing = false;
        

    }

   
}
