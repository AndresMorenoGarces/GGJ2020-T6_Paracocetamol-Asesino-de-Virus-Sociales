using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_UIMenu : MonoBehaviour
{
    public void StartButton()
    {
        LoadScenes(2);
    }

    public void CreditsButton()
    {
        LoadScenes(3);
    }

    private void LoadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
