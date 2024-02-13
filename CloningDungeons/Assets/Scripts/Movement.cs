using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float hor;
    public float vert;
    public Vector3 dir;
    public float speed;
    public CharacterController controller;
    public bool isPlayer;
    public GameObject[] people;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        people = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            hor = Input.GetAxisRaw("Horizontal");
            vert = Input.GetAxisRaw("Vertical");
            dir = new Vector3(hor, 0, vert);
            controller.Move(dir * speed * Time.deltaTime);
        }
        
        
        

        
        

    }
}
