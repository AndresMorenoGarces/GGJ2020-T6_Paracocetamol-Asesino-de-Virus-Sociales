using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_UIMenu : MonoBehaviour
{
    private void LoadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void StartButton()
    {
        LoadScenes(2);
    }
    public void CreditsButton()
    {
        LoadScenes(3);
    }

    private void Awake()
    {
        Time.timeScale = 1;
    }
}
