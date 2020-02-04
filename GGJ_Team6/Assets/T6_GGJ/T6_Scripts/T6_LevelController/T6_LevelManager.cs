using System.Collections;
using UnityEngine;

public class T6_LevelManager : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform enemyVoidObject;
    public Transform[] spawners;

    private int currentSurge = 0;
    private int enemiesSpawned;
    private int enemyType;
    private int wavesUpgrade = 0;
    private int enemyMaxUpgrade = 0;
    private GameObject enemyClone;
    private Vector2 respawnPosition;

    private T6_UIManager UI;

    IEnumerator  SpawnEnemies()
    {
        enemiesSpawned = Random.Range(1 + wavesUpgrade, 3 + wavesUpgrade);

        for (int i = 0; i < enemiesSpawned; i++)
        {
            int tmpRnd = Random.Range(0, spawners.Length);
            enemyClone = Instantiate(enemy[RespawnType()], spawners[tmpRnd].position, Quaternion.identity);
            enemyClone.name = "Enemy Clone";
            enemyClone.transform.SetParent(enemyVoidObject.transform);
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(5f);
        NewSurge();
        StartCoroutine("SpawnEnemies");
    }

    private int RespawnType()
    {
        enemyType = Random.Range(0, 1 + enemyMaxUpgrade);
        return enemyType;
    }
    private void NewSurge()
    {
            currentSurge++;
            if (currentSurge % 5 == 0)
            {
                if (enemyMaxUpgrade < 4)
                    enemyMaxUpgrade++;
                if (wavesUpgrade < 10)
                    wavesUpgrade++;
            }
        UI.UpdateSurge(currentSurge);
    }

    private void Awake()
    {
        UI = GetComponent<T6_UIManager>();
    }

    void Start()
    {
        StartCoroutine("SpawnEnemies");
        UI.UpdateSurge(currentSurge);
    }
}