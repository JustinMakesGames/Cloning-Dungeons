using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator door;
    private Animator lever;
    public bool movingLever;
    public Transform cam;
    private CameraComponent camScript;
    private Transform camEndPosition;
    private Timer timer;
    private void Start()
    {
        door = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        lever = transform.GetChild(1).GetChild(1).GetComponent<Animator>();
        cam = GameObject.Find("MainCamera").transform;
        camEndPosition = transform.GetChild(0).GetChild(1);
        timer = FindObjectOfType<Timer>();
        camScript = cam.GetComponent<CameraComponent>();

    }

    private void Update()
    {
        
        if (movingLever)
        {
            movingLever = false;
            StartCoroutine(LeverStarting());
            
        }
    }

    IEnumerator LeverStarting()
    {
        lever.SetTrigger("Lever");
        yield return new WaitForSeconds(0.5f);
        timer.cutscene = true;
        camScript.cutscene = true;
        cam.position = camEndPosition.position;
        cam.rotation = camEndPosition.rotation;
        print("This is getting runned");
        door.SetTrigger("DoorOpening");
        yield return new WaitForSeconds(3);
        
        timer.cutscene = false;
        camScript.cutscene = false;
        lever.SetTrigger("LeverClosing");
        yield return new WaitForSeconds(20f);
        print("Wow wth");
        door.SetTrigger("DoorClosing");      
      
       




    }
}
