using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_UICredits : MonoBehaviour
{
    public void MainMenuButton()
    {
        LoadScenes(1);
    }
    public void RestartGameButton()
    {
        LoadScenes(2);
    }
    private void LoadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
