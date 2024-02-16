using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigClone : Movement
{
    RaycastHit hit;
    public LayerMask smallclone;
    public float maxDistance;
    public bool isGrabbing;
    public Transform objtoGet;
    public override void Update()
    {
        base.Update();
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, smallclone) && Input.GetKeyDown(KeyCode.E) && !isGrabbing)
        {
            isGrabbing = true;
            objtoGet = hit.collider.gameObject.transform;
            

        }

        

        if (isGrabbing && Input.GetKeyDown(KeyCode.Q))
        {
            Throw(objtoGet);
        }

        


    }


    private void FixedUpdate()
    {
        if (isGrabbing)
        {
            GrabPlayer(objtoGet);
        }
    }



    void GrabPlayer(Transform obj)
    {
        obj.parent = cam;
        obj.rotation = Quaternion.identity;
        
        float movespeed = 100f;
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();
        rigidobj.useGravity = false;
        rigidobj.isKinematic = true;
        rigidobj.interpolation = RigidbodyInterpolation.None;
        Vector3 targetposition = cam.position + cam.forward * 2f;
        Vector3 lerping = Vector3.Lerp(obj.position, targetposition, movespeed * Time.deltaTime);
        rigidobj.MovePosition(lerping);

        
    }

    public float throwingForceForward;
    
    void Throw(Transform obj)
    {
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();
        rigidobj.useGravity = true;
        rigidobj.isKinematic = false;
        rigidobj.interpolation = RigidbodyInterpolation.Interpolate;
        rigidobj.AddForce(cam.forward * throwingForceForward, ForceMode.Impulse);
        obj.parent = null;
        isGrabbing = false;

    }
}
