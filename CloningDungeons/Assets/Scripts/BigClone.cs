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

    //Inventory
    public bool inventoryspace;
    public LayerMask key;
    public LayerMask chest;
    

    
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

        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, chest) && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ChestOpen());
        }




    }


    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isGrabbing)
        {
            GrabPlayer(objtoGet);
        }
    }



    void GrabPlayer(Transform obj)
    {


        float movespeed = 10f;
        Rigidbody rigidobj = obj.GetComponent<Rigidbody>();
        rigidobj.useGravity = false;
        rigidobj.isKinematic = true;
        
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
       
        isGrabbing = false;

    }

    public GameObject keyprefab;

    IEnumerator ChestOpen()
    {
        Transform chest = hit.collider.gameObject.transform;
        Transform chestlid = chest.parent.GetChild(0);
        Transform spawnobject = chest.parent.GetChild(2);
        
        GameObject key = Instantiate(keyprefab, spawnobject.position,
            Quaternion.identity);
        Animator keyanimator = key.transform.GetChild(0).GetComponent<Animator>();
        Animator chestanimator = chestlid.GetComponent<Animator>();
        keyanimator.Play("KeyGoingin");
        yield return new WaitForSeconds(2);
        Destroy(key);
        chestanimator.Play("ChestDeksel");

        
        

    }

    
}
