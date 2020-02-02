using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_LevelManager : MonoBehaviour
{
    private int enemiesSpawned;
    private int enemyType;
    private int currentSurge = 0;
    private int wavesUpgrade = 0;
    private int enemyMaxUpgrade = 0;

    public GameObject[] enemy;
    public Transform enemyVoidObject;
    private GameObject enemyClone;

    private Vector2 respawnPosition;

    public Transform[] spawners;

    void Start()
    {
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator  SpawnEnemies()
    {
        enemiesSpawned = Random.Range(1 + wavesUpgrade, 3 + wavesUpgrade);

        for (int i = 0; i < enemiesSpawned; i++)
        {
            int tmpRnd = Random.Range(0, spawners.Length);
            enemyClone = Instantiate(enemy[RespawnType()], spawners[tmpRnd].position, Quaternion.identity);
            enemyClone.name = "Enemy Clone";
            enemyClone.transform.SetParent(enemyVoidObject.transform);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(2f);
        NewSurge();
        StartCoroutine("SpawnEnemies");
    }

    int RespawnType()
    {
        enemyType = Random.Range(0, 1 + enemyMaxUpgrade);
        return enemyType;
    }
    private void NewSurge()
    {
            currentSurge++;
            if (currentSurge % 5 == 0)
            {
                if (enemyMaxUpgrade < 3)
                    enemyMaxUpgrade++;
                if (wavesUpgrade < 10)
                    wavesUpgrade++;
            }
    }
}