using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class T6_UIManager : MonoBehaviour
{
    private bool active = false;
    public TextMeshPro waveTextPro;
    public TextMeshPro healthTextPro;
    public TextMeshPro scoreTextPro;
    public TextMeshPro surgeTextPro;
    public TextMeshPro lastScoreTextP;
    public TextMeshPro bestScoreTextP;
    public GameObject settingsInterface;

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            Time.timeScale = (active) ? 0 : 1;
            settingsInterface.SetActive(active);
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    

    public void UpdateScore(int score)
    {
        scoreTextPro.text = "Score\n" + score;
    }
    public void UpdateSurge(int surge)
    {
        surgeTextPro.text = "Wave\n" + surge;
    }
    public void HPPoints(int hpPoint)
    {
        healthTextPro.text = hpPoint + "%";
    }
    private void LoadScore()
    {
        lastScoreTextP.text = "Last Score:\n" + PlayerPrefs.GetInt("Last Score");
        bestScoreTextP.text = "Best Score\n" + PlayerPrefs.GetInt("Best Score");
    }

    private void Start()
    {
        LoadScore();
    }
    private void Update()
    {
        PauseGame();
    }
}
