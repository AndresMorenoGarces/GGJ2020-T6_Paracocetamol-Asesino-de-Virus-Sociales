using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            Time.timeScale = (active) ? 0 : 1;
            settingsInterface.SetActive(active);
        }
    }

    public void HPPoints(int hpPoint)
    {
        healthTextPro.text = hpPoint + "%";
    }

    public void RestartGameButton()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UpdateScore(int score)
    {
        scoreTextPro.text = "Score\n" + score;
    }

    public void UpdateSurge(int surge)
    {
        surgeTextPro.text = "Wave\n" + surge;
    }

    private void LoadScore()
    {
        lastScoreTextP.text = "Last Score:\n" + PlayerPrefs.GetInt("Last Score");
        bestScoreTextP.text = "Best Score\n" + PlayerPrefs.GetInt("Best Score");
    }

    private void LoadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    private void Start()
    {
        LoadScore();

    }
    private void Update()
    {
        PauseGame();
        RestartGameButton();
    }
}
