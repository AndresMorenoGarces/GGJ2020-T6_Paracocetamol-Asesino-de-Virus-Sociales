using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_GameManager : MonoBehaviour
{
    public Transform playerController;
    public AudioClip soundGround;

    private int lifePoints;
    private int enemiesDead;
    private int scorePoints;
    private int hpPoints;
    private int lastScore;
    private int bestScore;
    private T6_UIManager uI;
    private T6_PlayerController pC;
    
    public void PlayerTakeDamage(int damage)
    {
        lifePoints -= damage;
        uI.HPPoints(lifePoints);
    }
    public void UpgradeScore()
    {
        scorePoints = scorePoints + 10;
        uI.UpdateScore(scorePoints);
    }
    public void UpdateCountKills()
    {
        enemiesDead++;
        pC.ChangeAmmo(enemiesDead);
    }

    public void SaveTemporalScore()
    {
        lastScore = scorePoints;
        PlayerPrefs.SetInt("Last Score", lastScore);
    }
    public void SaveBestScore()
    {
        if (scorePoints > PlayerPrefs.GetInt("Best Score"))
        {
            bestScore = scorePoints;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    private void Awake()
    {
        uI = GetComponent<T6_UIManager>();
        pC = playerController.GetComponent<T6_PlayerController>();
        lifePoints = 100;
        enemiesDead = 0;
    }
    void Start()
    {
        T6_AudioManager.am.PlayMusic(soundGround);
    }
    void Update()
    {
        if (lifePoints <= 0)
            SceneManager.LoadScene(4);
    }
}
