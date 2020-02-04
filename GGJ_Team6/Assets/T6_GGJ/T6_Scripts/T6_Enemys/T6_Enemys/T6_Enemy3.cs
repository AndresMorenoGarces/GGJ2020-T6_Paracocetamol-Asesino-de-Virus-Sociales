using UnityEngine;

public class T6_Enemy3 : T6_EnemyBehavior
{
    public AudioClip enemySound3;

    void Start()
    {
        StartHealth(40);
        GetManager();
        T6_AudioManager.am.Play(enemySound3);
    }
    void Update()
    {
        EnemyCurrentState(2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTakeDamage(10, 20, 50, collision);
    }
}
