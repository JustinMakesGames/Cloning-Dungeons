using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public RaycastHit hit;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<iInteractable>() != null)
            {
                hit.collider.GetComponent<iInteractable>().interactable();
            }

        }
    }
}

