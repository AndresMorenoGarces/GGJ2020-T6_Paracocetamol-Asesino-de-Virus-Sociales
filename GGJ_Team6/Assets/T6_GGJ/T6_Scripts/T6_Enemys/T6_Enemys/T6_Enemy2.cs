using UnityEngine;

public class T6_Enemy2 : T6_EnemyBehavior
{
    public AudioClip enemySound2;

    void Start()
    {
        StartHealth(20);
        GetManager();
        T6_AudioManager.am.Play(enemySound2);
    }
    void Update()
    {
        EnemyCurrentState(3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTakeDamage(10, 20, 50, collision);
    }
}
