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
    



    //Switching from character
    public bool isPlayer;
    public Transform movecam;
    public Transform cam;
    public CameraComponent script;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        script = cam.GetComponent<CameraComponent>();
        
    }

    public virtual void Update()
    {
        InputCheck();
        if (isPlayer)
        {
            Moving();
        }
    }

    

    void InputCheck()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
    }

    void Moving()
    {
        dir = movecam.forward * vert + movecam.right * hor;
        rb.AddForce(dir.normalized * speed * Time.deltaTime);
        

    }

    
}
