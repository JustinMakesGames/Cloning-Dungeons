using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject key;
    public GameObject keyImage;

    private void Awake()
    {
        if (gameObject.name == "DoorKey")
        {
            key = Resources.Load<GameObject>("DoorKeyGround");
            keyImage = GameObject.FindWithTag("DoorKeyImage");
        }
        else
        {
            key = Resources.Load<GameObject>("KeyOnGround");
            keyImage = GameObject.FindWithTag("ChestKeyImage");
        }
    }

    private void Start()
    {
        keyImage.SetActive(false);
    }
}
