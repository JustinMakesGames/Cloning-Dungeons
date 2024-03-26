using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Button[] buttonscripts;
    public bool dooropened;
    private Animator animator;
    private Transform cam;
    private Transform endcamposition;
    private bool cutscenecompleted;
    private CameraComponent camerascript;
    private Timer timerscript;
    public float camspeed;

    private void Start()
    {
        buttonscripts = GetComponentsInChildren<Button>();
        animator = transform.GetComponentInChildren<Animator>();
        cam = GameObject.Find("MainCamera").transform;
        endcamposition = transform.Find("CameraPlacement");
        camerascript = cam.GetComponent<CameraComponent>();
        timerscript = FindObjectOfType<Timer>();
        
    }

    private void Update()
    {
        

        if (!dooropened && !cutscenecompleted)
        {
            foreach (Button b in buttonscripts)
            {
                if (!b.fullyPressed)
                {
                    dooropened = false;
                    break;
                }

                dooropened = true;
            }

            
        }
        

        if (dooropened && !cutscenecompleted)
        {
            StartCoroutine(PlayDoorAnimation());
            

        }

        
    }

   
    IEnumerator PlayDoorAnimation()
    {
        timerscript.cutscene = true;
        while (cam.position != endcamposition.position)
        {
            camerascript.cutscene = true;
            cam.position = Vector3.MoveTowards(cam.position, endcamposition.position, camspeed * Time.deltaTime);
            if (Vector3.Distance(cam.position, endcamposition.position) < 0.05f)
            {
                cam.position = endcamposition.position;
                cam.rotation = endcamposition.rotation;
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        animator.Play("DoorOpening");
        yield return new WaitForSeconds(1);
        //Play Sound Here
        yield return new WaitForSeconds(3);
        camerascript.cutscene = false;
        cutscenecompleted = true;
        timerscript.cutscene = false;
    }
}
