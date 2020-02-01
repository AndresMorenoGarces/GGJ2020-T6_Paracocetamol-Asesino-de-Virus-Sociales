using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_EnemyBehavior : MonoBehaviour
{
    private int baseHealth = 100;
    private int currentHealth;

    private void Start()
    {
        
    }

    protected void EnemyMove(float speed)
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected void Die()
    {
        Destroy(gameObject);
    }

    protected void StartHealth(int aditionalHealth)
    {
        currentHealth = baseHealth;
        currentHealth = currentHealth + aditionalHealth;
    }
}
