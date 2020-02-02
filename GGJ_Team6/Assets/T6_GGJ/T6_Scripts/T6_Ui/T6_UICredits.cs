using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_UICredits : MonoBehaviour
{
    public void MainMenuButton()
    {
        Time.timeScale = 1;
        LoadScenes(0);
    }
    private void LoadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
