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
