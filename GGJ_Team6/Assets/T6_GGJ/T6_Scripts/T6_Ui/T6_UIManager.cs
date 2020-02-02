using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class T6_UIManager : MonoBehaviour
{
    private bool active = false;

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        LoadScenes(0);
    }
    public void StartButton()
    {
        LoadScenes(1);
    }

    public void CreditsButton()
    {
        LoadScenes(2);
    }
    public void SettingsButton()
    {
        active =! active;
        Time.timeScale = (active) ? 0 : 1;
    }

    private void LoadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void RestartGameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
