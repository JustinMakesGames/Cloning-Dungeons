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
    private RaycastHit hit;
    public LayerMask ground;
    private bool resetjump;
    public float jumpraycast;
    



    //Switching from character
    public bool isPlayer;
    public Transform movecam;
    public Transform cam;
    public CameraComponent script;

    

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        script = cam.GetComponent<CameraComponent>();
        resetjump = true;
        jumpraycast = transform.localScale.y + 0.1f;
        
    }

    public virtual void Update()
    {
        ableToJump = Physics.Raycast(transform.position, -Vector3.up, out hit, jumpraycast, ground);
        Debug.DrawRay(transform.position, -Vector3.up * transform.localScale.y, Color.yellow);
        InputCheck();
        
        
    }

    public virtual void FixedUpdate()
    {
        if (isPlayer)
        {
            Moving();
            if (ableToJump && jump && resetjump)
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

    private void Reset()
    {
        resetjump = true;
    }

}
