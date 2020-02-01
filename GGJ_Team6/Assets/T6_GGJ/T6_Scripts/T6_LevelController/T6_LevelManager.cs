using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_LevelManager : MonoBehaviour
{
    private int enemysQuantity;
    private int hitLimit;
    private int rangeRespawnPosition;
    private int enemiesDead;
    private int bacteriesSurges = 5;
    private int [] limitActiveEnemies;
    public GameObject enemy;

    private GameObject enemyClone;

    private Vector2 respawnPosition;
    private bool isRespawned;

    private void RespawnEnemies()
    {
        enemyClone = Instantiate(enemy, respawnPosition, Quaternion.identity);
        enemyClone.name = "enemyClone";
        isRespawned = true;


    }




    void Start()
    {
    }

    void Update()
    {
        //RespawnEnemies();
        if (isRespawned)
        {
            isRespawned = false;
            rangeRespawnPosition = Random.Range(4, -4);
            respawnPosition = new Vector2(8.5f, rangeRespawnPosition);
        }
    }
}
