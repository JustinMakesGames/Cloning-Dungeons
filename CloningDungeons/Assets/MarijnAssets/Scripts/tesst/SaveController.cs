using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            string activescene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("Savedlevel", activescene);

            Debug.Log(activescene);
        }
    }
}
