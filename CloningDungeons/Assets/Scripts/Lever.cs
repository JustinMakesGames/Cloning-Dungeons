using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator door;
    private Animator lever;
    public bool movinglever;

    private void Start()
    {
        door = transform.GetChild(0).GetChild(1).GetComponent<Animator>();
        lever = transform.GetChild(1).GetChild(1).GetComponent<Animator>();

    }

    private void Update()
    {
        
        if (movinglever)
        {
            StartCoroutine(LeverStarting());
        }
    }

    IEnumerator LeverStarting()
    {
        lever.SetTrigger("Lever");
        yield return new WaitForSeconds(0.5f);




        lever.SetTrigger("LeverClosing");
        door.SetTrigger("DoorOpening");
        
        yield return new WaitForSeconds(20f);
        door.SetTrigger("DoorClosing");
        
        

    }
}
