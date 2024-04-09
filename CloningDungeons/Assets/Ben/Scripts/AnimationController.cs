using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    private Movement movemnt;
    // Start is called before the first frame update
    void Start()
    {
        movemnt = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movemnt.isMoving)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {   
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("IsWalking", false);
            movemnt.isMoving = false;
        }
    }
}
