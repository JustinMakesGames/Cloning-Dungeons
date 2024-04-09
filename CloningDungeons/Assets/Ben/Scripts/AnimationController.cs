using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
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
            animator.SetBool("IsWalking", true);
        }
        else
        {   
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsWalking", false);
            movemnt.isMoving = false;
        }
    }
}
