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

    public Transform bigClone;
    public Transform smallClone;
    public SmallClone script;
    public bool bigCloneparent;
    public bool smallCloneParent;
    public Transform targetPosition;

    public float camSpeed;
    public bool timeToMove;
    public bool cutscene;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        bigCloneparent = true;
        targetPosition = bigClone.GetChild(0).transform;       
        script = smallClone.GetComponent<SmallClone>();       
    }

   
   
    void LateUpdate()
    {
        if (!cutscene)
        {
            CameraMovement();
            TimeToMove();
            if (!timeToMove)
            {
                transform.position = targetPosition.position;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                timeToMove = true;
            }
            

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
            sensx = 200f;
            sensy = 200f;
        }
        else
        {
            sensx = 750f;
            sensy = 750f;
        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        moveOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
    }


    //Switching the camera
    void TimeToMove()
    {
        if (bigCloneparent && timeToMove)
        {

            targetPosition = smallClone.GetChild(0).transform;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, camSpeed * Time.deltaTime);
            bigClone.GetComponent<Movement>().isPlayer = false;
            smallClone.GetComponent<Movement>().isPlayer = true;
            if (Vector3.Distance(transform.position, smallClone.GetChild(0).transform.position) < 0.05f)
            {
                timeToMove = false;
                bigCloneparent = false;
                smallCloneParent = true;
            }

        }
        else if (!bigCloneparent && timeToMove)
        {

            targetPosition = bigClone.GetChild(0).transform;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, camSpeed * Time.deltaTime);
            bigClone.GetComponent<Movement>().isPlayer = true;
            smallClone.GetComponent<Movement>().isPlayer = false;
            if (Vector3.Distance(transform.position, bigClone.GetChild(0).transform.position) < 0.05f)
            {
                timeToMove = false;
                bigCloneparent = true;
                smallCloneParent = false;
            }

            
        }
    }
}
