using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_UIMenu : MonoBehaviour
{
    public void StartButton()
    {
        LoadScenes(1);
    }

    public void CreditsButton()
    {
        LoadScenes(2);
    }

    private void LoadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
