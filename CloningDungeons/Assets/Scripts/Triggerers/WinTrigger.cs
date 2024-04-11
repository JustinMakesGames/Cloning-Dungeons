using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WinScreenFunction();
        }
    }

    private void WinScreenFunction()
    {
        FindFirstObjectByType<PauseScript>().GetComponent<PauseScript>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }
}
