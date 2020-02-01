using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_LevelManager : MonoBehaviour
{
    private int enemysQuantity;
    private int enemiesDead;
    private int enemiesSpawned;
    private int randomEnemyQuantity;
    private int enemyType;

    private int currentSurge = 0;
    private int wavesUpgrade = 0;
    private int enemyMaxUpgrade = 0;
    private int enemyMinUpgrade = 0;
    private int rangeRespawnPosition;

    public GameObject[] enemy;
    public Transform enemyVoidObject;
    private GameObject enemyClone;

    private Vector2 respawnPosition;
    private bool isRespawnTime = true;
    private bool isFirstRespawn = true;

    private void RespawnEnemies()
    {
        for (int i = 0; i < RespawnQuantity(); i++)
        {
            randomEnemyQuantity = Random.Range(-4, 5);
            enemyClone = Instantiate(enemy[RespawnType()], RespawnPosition(), Quaternion.identity);
            enemyClone.name = "enemyClone";
            enemyClone.transform.SetParent(enemyVoidObject.transform);
        }

        Vector2 RespawnPosition()
        {
            if (randomEnemyQuantity % 2 == 0)
                respawnPosition = new Vector2(10, randomEnemyQuantity);
            else
                respawnPosition = new Vector2(10, randomEnemyQuantity - 1);
            return respawnPosition;
        }
        int RespawnQuantity()
        {
            enemiesSpawned = Random.Range(1 + wavesUpgrade, 3 + wavesUpgrade);
            return enemiesSpawned;
        }
        int RespawnType()
        {
            enemyType = Random.Range(0 + enemyMinUpgrade, 1 + enemyMaxUpgrade);
            return enemyType;
        }
        isRespawnTime = false;
        isFirstRespawn = false;
    }

    private void NewSurge()
    {
        if (enemyVoidObject.childCount == 0)
        {
            currentSurge++;
            if (currentSurge % 5 == 0)
            {
                if (enemyMaxUpgrade < 3)
                    enemyMaxUpgrade++;
                if (wavesUpgrade < 10)
                    wavesUpgrade++;
                if (currentSurge % 10 == 0 && enemyMinUpgrade < enemyMaxUpgrade - 1)
                    enemyMinUpgrade++;
            }

            isRespawnTime = true;
        }
    }

    void Update()
    {
        if (isRespawnTime)
            RespawnEnemies();
        NewSurge();
    }
}