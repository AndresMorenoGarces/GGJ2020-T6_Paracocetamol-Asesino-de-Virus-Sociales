using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_EnemyBehavior : MonoBehaviour
{
    private int baseHealth = 100;
    private int currentHealth;

    private T6_GameManager Manager;

    public bool gettingDamage = false;

    protected void GetManager()
    {
        Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<T6_GameManager>();
    }

    protected void StartHealth(int aditionalHealth)
    {
        currentHealth = baseHealth;
        currentHealth = currentHealth + aditionalHealth;
    }

    protected void EnemyMove(float speed)
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected void TakeDamage(int projectileDamage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= projectileDamage;
        }
        else
        {
            Die();
        }
    }

    public void MakeDamage(int damage)
    {
        Manager.RecibeDamage(damage);
        Die();
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
