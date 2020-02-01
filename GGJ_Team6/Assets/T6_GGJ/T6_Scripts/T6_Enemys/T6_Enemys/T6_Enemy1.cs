using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_Enemy1 : T6_EnemyBehavior
{
    private EnemyState currState = EnemyState.Run;

    void Start()
    {
        StartHealth(10);
    }

    void Update()
    {
        switch (currState)
        {
            case EnemyState.Run:
                EnemyMove(5f);
                break;
            case EnemyState.Die:
                Die();
                break;
            case EnemyState.Attacks:
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goal")
        {
            currState = EnemyState.Die;
        }
    }
}
