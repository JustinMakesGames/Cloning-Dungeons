using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Checker")]
    [SerializeField] private bool isMoving;

    //Input
    public float hor;
    public float vert;
    public Vector3 dir;


    //Movement
    public float speed;
    Rigidbody rb;
    public bool jump;
    public float jumpPower;
    public bool ableToJump;
    public RaycastHit hit;
    public LayerMask ground;
    public LayerMask crateJump;
    protected bool resetJump;
    public float jumpRaycast;
    protected bool objToGrab;
    



    //Switching from character
    public bool isPlayer;
    public Transform moveCam;
    public Transform cam;
    public CameraComponent script;

    //Saving
    public LayerMask save;
    public float maximumDistance;
    public ToSpawnHere toSpawnHere;

    //Lever
    public LayerMask lever;

    
    
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        script = cam.GetComponent<CameraComponent>();
        resetJump = true;
        jumpRaycast = transform.localScale.y + 0.1f;

        if (GameObject.FindObjectOfType<ToSpawnHere>() != null)
        {
            toSpawnHere = GameObject.FindObjectOfType<ToSpawnHere>().GetComponent<ToSpawnHere>();
        }
        

        
        
    }

    public virtual void Update()
    {
        ableToJump = Physics.Raycast(transform.position, -Vector3.up, out hit, jumpRaycast, ground);

        Debug.DrawRay(transform.position, -Vector3.up * transform.localScale.y, Color.yellow);
        InputCheck();
        Saving();
        Lever();
        
        
    }

    public virtual void FixedUpdate()
    {
        if (isPlayer)
        {
            Moving();
            if (ableToJump && jump && resetJump && !objToGrab)
            {
                
                
                resetJump = false;
                Jump();
                Invoke(nameof(Reset), 0.25f);
            }
            
        }
        
    }

    

    void InputCheck()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        jump = Input.GetButton("Jump");
    }

    void Moving()
    {
        dir = moveCam.forward * vert + moveCam.right * hor;
        rb.AddForce(dir.normalized * speed * Time.deltaTime);

        if (dir.magnitude > 0.01f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);



    }

    void Saving()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, maximumDistance, save) && Input.GetKeyDown(KeyCode.E))
        {
            print("Saved");
            toSpawnHere.spawnPlace = hit.transform.GetSiblingIndex();
            toSpawnHere.SavePlayer();
        }
    }

    void Lever()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, maximumDistance, lever) && Input.GetKeyDown(KeyCode.E))
        {
            hit.transform.parent.parent.GetComponent<Lever>().movingLever = true;

        }
    }

    

    private void Reset()
    {
        resetJump = true;
    }

}
