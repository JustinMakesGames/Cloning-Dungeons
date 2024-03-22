using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Input
    public float hor;
    public float vert;
    public Vector3 dir;


    //Movement
    public float speed;
    Rigidbody rb;
    public bool jump;
    public float jumppower;
    public bool ableToJump;
    public RaycastHit hit;
    public LayerMask ground;
    public LayerMask cratejump;
    protected bool resetjump;
    public float jumpraycast;
    protected bool objtograb;
    



    //Switching from character
    public bool isPlayer;
    public Transform movecam;
    public Transform cam;
    public CameraComponent script;

    //Saving
    public LayerMask save;
    public float maximumdistance;
    public ToSpawnHere toSpawnHere;

    //Lever
    public LayerMask lever;

    

    

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        script = cam.GetComponent<CameraComponent>();
        resetjump = true;
        jumpraycast = transform.localScale.y + 0.1f;

        if (GameObject.FindObjectOfType<ToSpawnHere>() != null)
        {
            toSpawnHere = GameObject.FindObjectOfType<ToSpawnHere>().GetComponent<ToSpawnHere>();
        }
        

        
        
    }

    public virtual void Update()
    {
        ableToJump = Physics.Raycast(transform.position, -Vector3.up, out hit, jumpraycast, ground);

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
            if (ableToJump && jump && resetjump && !objtograb)
            {
                
                
                resetjump = false;
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
        dir = movecam.forward * vert + movecam.right * hor;
        rb.AddForce(dir.normalized * speed * Time.deltaTime);
        

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);



    }

    void Saving()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, maximumdistance, save) && Input.GetKeyDown(KeyCode.E))
        {
            print("Saved");
            toSpawnHere.spawnplace = hit.transform.GetSiblingIndex();
            toSpawnHere.SavePlayer();
        }
    }

    void Lever()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, maximumdistance, lever) && Input.GetKeyDown(KeyCode.E))
        {
            hit.transform.parent.parent.transform.GetComponent<Lever>().movinglever = true;

        }
    }

    

    private void Reset()
    {
        resetjump = true;
    }

}
