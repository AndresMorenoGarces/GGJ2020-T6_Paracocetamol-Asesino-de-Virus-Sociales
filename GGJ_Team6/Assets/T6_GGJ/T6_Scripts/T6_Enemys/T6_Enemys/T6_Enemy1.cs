using UnityEngine;

public class T6_Enemy1 : T6_EnemyBehavior
{
    public AudioClip enemySound1;

    void Start()
    {
        StartHealth(0);
        GetManager();
        T6_AudioManager.am.Play(enemySound1);
    }
    void Update()
    {
        EnemyCurrentState(5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTakeDamage(10, 20, 50, collision);
    }
}
