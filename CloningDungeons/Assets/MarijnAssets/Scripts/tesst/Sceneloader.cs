using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sceneloader : MonoBehaviour
{
    public GameObject playerBig;
    public GameObject playerSmall;

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene 2");
    }
    public void LoadMainGame()
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
