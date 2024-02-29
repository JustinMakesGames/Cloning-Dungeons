using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{

    public float sensx;
    public float sensy;

    public Transform moveOrientation;
    

    public float xRotation;
    public float yRotation;

    public Transform bigclone;
    public Transform smallclone;
    public SmallClone script;
    public bool bigcloneparent;
    public bool smallcloneparent;
    public Transform targetposition;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        bigcloneparent = true;
        targetposition = bigclone.GetChild(0).transform;
        
        script = smallclone.GetComponent<SmallClone>();
        
    }

    public float camspeed;
    public bool timeToMove;
    public bool cutscene;
   
    void LateUpdate()
    {

        if (!cutscene)
        {
            if (!timeToMove)
            {
                transform.position = targetposition.position;
            }


            CameraMovement();

            if (Input.GetKeyDown(KeyCode.F))
            {
                bigclone.GetComponent<BigClone>().isGrabbing = false;
                Rigidbody rb = smallclone.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
                timeToMove = true;
            }

            TimeToMove();
        }

        
        

    }

    void CameraMovement()
    {
        float xMovement = Input.GetAxis("Mouse X") * Time.smoothDeltaTime * sensx;
        float yMovement = Input.GetAxis("Mouse Y") * Time.smoothDeltaTime * sensy;
        yRotation += xMovement;
        xRotation -= yMovement;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        if (script.isCameraClamped)
        {
            yRotation = Mathf.Clamp(yRotation, script.camclamp - 10f, script.camclamp + 10f);
        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        moveOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
    }

    void TimeToMove()
    {
        if (bigcloneparent && timeToMove)
        {

            targetposition = smallclone.GetChild(0).transform;
            transform.position = Vector3.MoveTowards(transform.position, targetposition.position, camspeed * Time.deltaTime);
            bigclone.GetComponent<Movement>().isPlayer = false;
            smallclone.GetComponent<Movement>().isPlayer = true;
            if (Vector3.Distance(transform.position, smallclone.GetChild(0).transform.position) < 0.05f)
            {
                timeToMove = false;
                bigcloneparent = false;
                smallcloneparent = true;
            }

        }
        else if (!bigcloneparent && timeToMove)
        {

            targetposition = bigclone.GetChild(0).transform;
            transform.position = Vector3.MoveTowards(transform.position, targetposition.position, camspeed * Time.deltaTime);
            bigclone.GetComponent<Movement>().isPlayer = true;
            smallclone.GetComponent<Movement>().isPlayer = false;
            if (Vector3.Distance(transform.position, bigclone.GetChild(0).transform.position) < 0.05f)
            {
                timeToMove = false;
                bigcloneparent = true;
                smallcloneparent = false;
            }

            
        }
    }
}
