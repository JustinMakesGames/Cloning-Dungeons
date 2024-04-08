using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSavePoint : MonoBehaviour
{
    public Transform bigClone;
    public Transform smallClone;

    // Start is called before the first frame update
    void Start()
    {
        LoadSave();
        print("Loaded");
    }

    private void LoadSave()
    {
        float bigX = PlayerPrefs.GetFloat("PlayerBigX");
        float bigY = PlayerPrefs.GetFloat("PlayerBigY");
        float bigZ = PlayerPrefs.GetFloat("PlayerBIgZ");

        float smallX = PlayerPrefs.GetFloat("PlayerSmallX");
        float smallY = PlayerPrefs.GetFloat("PlayerSmallY");
        float smallZ = PlayerPrefs.GetFloat("PlayerSmallZ");

        bigClone.position = new Vector3(bigX, bigY, bigZ);
        smallClone.position = new Vector3(smallX, smallY, smallZ);  
    }
}
