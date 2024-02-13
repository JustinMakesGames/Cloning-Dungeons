using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float sensx;
    public float sensy;

    public Transform playerOrientation;
    

    float xRotation;
    float yRotation;

    public Transform bigclone;
    public Transform smallclone;
    public bool bigcloneparent;
    public bool smallcloneparent;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.parent = bigclone;
        bigcloneparent = true;
    }

    public float camspeed;
    public bool timeToMove;
    void Update()
    {
        CameraMovement();

        if (Input.GetKeyDown(KeyCode.F))
        {
            timeToMove = true;
        }

        TimeToMove();
        

    }

    void CameraMovement()
    {
        float xMovement = Input.GetAxis("Mouse X") * Time.deltaTime * sensx;
        float yMovement = Input.GetAxis("Mouse Y") * Time.deltaTime * sensy;
        yRotation += xMovement;
        xRotation -= yMovement;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
    }

    void TimeToMove()
    {
        if (bigcloneparent && timeToMove)
        {
            
            transform.parent = smallclone;
            transform.position = Vector3.MoveTowards(transform.position, smallclone.GetChild(0).transform.position, camspeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, smallclone.GetChild(0).transform.position) < 0.05f)
            {
                timeToMove = false;
                bigcloneparent = false;
                smallcloneparent = true;
            }

        }
        else if (!bigcloneparent && timeToMove)
        {
            
            transform.parent = bigclone;
            transform.position = Vector3.MoveTowards(transform.position, bigclone.GetChild(0).transform.position, camspeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, bigclone.GetChild(0).transform.position) < 0.05f)
            {
                timeToMove = false;
                bigcloneparent = true;
                smallcloneparent = false;
            }

            
        }
    }
}
