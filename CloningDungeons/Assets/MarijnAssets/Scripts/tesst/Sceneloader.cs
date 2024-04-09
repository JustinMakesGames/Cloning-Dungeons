using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sceneloader : MonoBehaviour
{


    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void MainGame()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene("MainGame");
    }
    public void LoadGame()
    {
        Time.timeScale = 1;
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
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
