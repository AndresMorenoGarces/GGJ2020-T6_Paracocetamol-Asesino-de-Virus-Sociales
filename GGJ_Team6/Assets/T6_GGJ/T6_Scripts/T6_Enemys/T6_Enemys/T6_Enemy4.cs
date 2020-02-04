using UnityEngine;

public class T6_Enemy4 : T6_EnemyBehavior
{
    public AudioClip enemySound4;

    void Start()
    {
        StartHealth(60);
        GetManager();
        T6_AudioManager.am.Play(enemySound4);
    }
    void Update()
    {
        EnemyCurrentState(1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTakeDamage(10, 20, 50, collision);
    }
}
