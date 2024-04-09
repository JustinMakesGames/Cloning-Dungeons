using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausing();
        }
    }

    private void Pausing()
    {
        Time.timeScale = 0;

    }
}
