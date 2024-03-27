using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Button[] buttonScripts;
    public bool doorOpened;
    private Animator animator;
    private Transform cam;
    private Transform endcamPosition;
    private bool cutsceneCompleted;
    private CameraComponent cameraScript;
    private Timer timerScript;
    public float camSpeed;

    private void Start()
    {
        buttonScripts = GetComponentsInChildren<Button>();
        animator = transform.GetComponentInChildren<Animator>();
        cam = GameObject.Find("MainCamera").transform;
        endcamPosition = transform.Find("CameraPlacement");
        cameraScript = cam.GetComponent<CameraComponent>();
        timerScript = FindObjectOfType<Timer>();
        
    }

    private void Update()
    {
        

        if (!doorOpened && !cutsceneCompleted)
        {
            foreach (Button b in buttonScripts)
            {
                if (!b.fullyPressed)
                {
                    doorOpened = false;
                    break;
                }

                doorOpened = true;
            }

            
        }
        

        if (doorOpened && !cutsceneCompleted)
        {
            StartCoroutine(PlayDoorAnimation());
            

        }

        
    }

   
    IEnumerator PlayDoorAnimation()
    {
        timerScript.cutscene = true;
        while (cam.position != endcamPosition.position)
        {
            cameraScript.cutscene = true;
            cam.position = Vector3.MoveTowards(cam.position, endcamPosition.position, camSpeed * Time.deltaTime);
            if (Vector3.Distance(cam.position, endcamPosition.position) < 0.05f)
            {
                cam.position = endcamPosition.position;
                cam.rotation = endcamPosition.rotation;
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        animator.Play("DoorOpening");
        yield return new WaitForSeconds(1);
        //Play Sound Here
        yield return new WaitForSeconds(3);
        cameraScript.cutscene = false;
        cutsceneCompleted = true;
        timerScript.cutscene = false;
    }
}
