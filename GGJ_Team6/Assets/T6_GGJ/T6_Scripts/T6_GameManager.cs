using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_GameManager : MonoBehaviour
{
    private int life;
    public int scorePoints;
    public int wavesNum;
    public int healthPoints;
    public int lastScore;
    public int bestScore;

    private T6_UIManager UI;

    private void Awake()
    {
        UI = GetComponent<T6_UIManager>();
        life = 100;
    }

    void Start()
    {

    }

    void Update()
    {

    }
    
    public void RecibeDamage(int damage)
    {
        life -= damage;
    }

    public void UpgradeScore()
    {
        UI.UpdateScore(scorePoints);
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

    
}
