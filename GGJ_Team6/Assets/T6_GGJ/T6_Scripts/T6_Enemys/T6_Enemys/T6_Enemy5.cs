using UnityEngine;

public class T6_Enemy5 : T6_EnemyBehavior
{
    public AudioClip enemySound5;

    void Start()
    {
        StartHealth(80);
        GetManager();
        T6_AudioManager.am.Play(enemySound5);
    }
    void Update()
    {
        EnemyCurrentState(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTakeDamage(10, 20, 50, collision);
    }
}
