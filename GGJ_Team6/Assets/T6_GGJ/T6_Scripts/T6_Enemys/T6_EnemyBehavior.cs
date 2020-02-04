using UnityEngine;

public class T6_EnemyBehavior : MonoBehaviour
{
    private int baseHealth = 40;
    private int currentHealth;

    private T6_GameManager Manager;
    private EnemyState currState = EnemyState.Run;

    protected void GetManager()
    {
        Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<T6_GameManager>();
    }

    protected void StartHealth(int aditionalHealth)
    {
        currentHealth = baseHealth;
        currentHealth += aditionalHealth;
    }

    protected void EnemyMove(float speed)
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected void TakeDamage(int projectileDamage)
    {
        if (currentHealth > 0)
            currentHealth -= projectileDamage;
        else
        {
            Manager.UpgradeScore();
            Manager.SaveTemporalScore();
            Manager.SaveBestScore();
            Manager.UpdateCountKills();
            Die();
        }
    }

    public void EnemyCurrentState(float enemyMove)
    {
        switch (currState)
        {
            case EnemyState.Run:
                EnemyMove(enemyMove);
                break;
            case EnemyState.Die:
                Die();
                break;
            default:
                break;
        }
    }

    public void EnemyTakeDamage(int goal, int projectileDamage, int granadeDamage, Collider2D enemyCollision)
    {
        if (enemyCollision.tag == "Goal")
            MakeDamage(goal);
        if (enemyCollision.tag == "Projectile")
            TakeDamage(projectileDamage);
        if (enemyCollision.tag == "Expansion")
            TakeDamage(granadeDamage);
    }

    public void MakeDamage(int damage)
    {
        Manager.PlayerTakeDamage(damage);
        Die();
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
