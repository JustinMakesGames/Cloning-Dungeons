using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigClone : Movement
{
    [Header("BigCloneOnly")]
    RaycastHit hitraycast;
    public LayerMask bigpickup;
    public LayerMask pickup;
    public float maxDistance;
    public bool isGrabbing;
    public Transform objtoGet;
    public LayerMask everything;

    //Inventory
    public bool inventoryspace;
    public LayerMask key;
    public LayerMask chest;

    //E to interact 
    public GameObject eInteract;

    //Wall Problems
    public float stuckagainstwalldistance;
    public float numberawayfromobject;
    public float throwingForceForward;




    public override void Update()
    {
        base.Update();
        if (isPlayer)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hitraycast, maxDistance, bigpickup) && !isGrabbing)
            {
                eInteract.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && !isGrabbing)
                {
                    isGrabbing = true;
                    objtoGet = hitraycast.collider.gameObject.transform;
                }
            }
            else
            {
                eInteract.SetActive(false);
            }
            if (isGrabbing && Input.GetKeyDown(KeyCode.Q))
            {
                Throw(objtoGet);
            }
            if (isGrabbing && Input.GetKeyDown(KeyCode.R))
            {
                Drop(objtoGet);
            }

            if (Input.GetKeyDown(KeyCode.F) && isGrabbing)
            {
                isGrabbing = false;
                Rigidbody rb = objtoGet.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;

                Collider[] colliders = FindObjectsOfType<Collider>();

                foreach (Collider collider in colliders)
                {
                    Physics.IgnoreCollision(objtoGet.GetComponent<Collider>(), collider, false);
                }
            }
        }
 
    }


    public override void FixedUpdate()
    {       
        if (isPlayer)
        {
            if (isGrabbing)
            {
                GrabPlayer(objtoGet);
            }
        }
        if (objtoGet != null)
        {
            objtograb = true;
        }
        else
        {
            objtograb = false;
        }
        base.FixedUpdate();
    }


    
    void GrabPlayer(Transform obj)
    {
        Collider[] colliders = FindObjectsOfType<Collider>();
        foreach (Collider collider in colliders)
        {
            Physics.IgnoreCollision(obj.GetComponent<Collider>(), collider, true);
        }        
        float movespeed = 10f;
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();       
        rigidobj.useGravity = false;
        rigidobj.isKinematic = true;
        Vector3 targetposition = cam.position + cam.forward * maxDistance;

        if (Physics.Raycast(obj.position, targetposition - obj.position, out hitraycast, stuckagainstwalldistance, everything))
        {
            Debug.DrawRay(obj.position, (targetposition - obj.position) * stuckagainstwalldistance, Color.yellow);
            print("Yes");
            Vector3 newtargetposition = (obj.position - targetposition).normalized * numberawayfromobject;
            targetposition = hitraycast.point + newtargetposition;
            
        }
        Vector3 lerping = Vector3.Lerp(obj.position, targetposition, movespeed * Time.deltaTime);
        rigidobj.MovePosition(lerping);        
    }

    
    
    void Throw(Transform obj)
    {       
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();
        rigidobj.useGravity = true;
        rigidobj.isKinematic = false;   
        rigidobj.AddForce(cam.forward * throwingForceForward, ForceMode.VelocityChange);      
        isGrabbing = false;
        Collider[] colliders = FindObjectsOfType<Collider>();
        foreach (Collider collider in colliders)
        {
            Physics.IgnoreCollision(obj.GetComponent<Collider>(), collider, false);
        }
        objtoGet = null;
    }

    void Drop(Transform obj)
    {
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();
        rigidobj.useGravity = true;
        rigidobj.isKinematic = false;
        isGrabbing = false;
        Collider[] colliders = FindObjectsOfType<Collider>();
        foreach (Collider collider in colliders)
        {
            Physics.IgnoreCollision(obj.GetComponent<Collider>(), collider, false);
        }
        objtoGet = null;
    }

   
}
