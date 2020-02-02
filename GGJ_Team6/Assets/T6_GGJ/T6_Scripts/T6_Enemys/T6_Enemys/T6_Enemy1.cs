﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_Enemy1 : T6_EnemyBehavior
{
    private EnemyState currState = EnemyState.Run;

    void Start()
    {
        StartHealth(0);
        GetManager();
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
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goal")
        {
            MakeDamage(10);
        }

        if(collision.tag == "Projectile")
        {
            TakeDamage(20);
        }

        if (collision.tag == "Expansion")
        {
            TakeDamage(30);
        }
    }
}
