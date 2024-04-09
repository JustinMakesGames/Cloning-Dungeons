using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sceneloader : MonoBehaviour
{


    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene 2");
    }
    public void MainGame()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene("MainGame");
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
