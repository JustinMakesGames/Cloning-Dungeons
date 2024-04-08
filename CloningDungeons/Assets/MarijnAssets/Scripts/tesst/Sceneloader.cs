using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sceneloader : MonoBehaviour
{
    public GameObject playerBig;
    public GameObject playerSmall;
    public Transform bigClone;
    public Transform smallClone;

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene 2");
    }
    public void LoadGame()
    {
        float bigX = PlayerPrefs.GetFloat("PlayerBigX");
        float bigY = PlayerPrefs.GetFloat("PlayerBigY");
        float bigZ = PlayerPrefs.GetFloat("PlayerBIgZ");

        float smallX = PlayerPrefs.GetFloat("PlayerSmallX");
        float smallY = PlayerPrefs.GetFloat("PlayerSmallY");
        float smallZ = PlayerPrefs.GetFloat("PlayerSmallZ");

        bigClone.position = new Vector3(bigX, bigY, bigZ);
        smallClone.position = new Vector3(smallX, smallY, smallZ);


        SceneManager.LoadScene("MainGame");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
