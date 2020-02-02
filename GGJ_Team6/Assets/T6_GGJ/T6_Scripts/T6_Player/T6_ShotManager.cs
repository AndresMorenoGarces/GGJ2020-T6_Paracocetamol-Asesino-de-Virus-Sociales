using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotManager : MonoBehaviour
{
    public GameObject[] ammo;

    ShotType shotType = ShotType.Basic;
    private int typeOfShot;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    private int shotCap = 0;

    void Start()
    {
        typeOfShot = 0;
    }

    void Update()
    {
        if (shotCap == 10)
        {
            shotCap = 0;
            shotType = ShotType.Basic;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                switch (shotType)
                {
                    case ShotType.Basic:
                        ShotBasic();
                        break;
                    case ShotType.Triple:
                        ShotTriple();
                        break;
                    default:
                        break;
                }
                AttackTime();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                shotType = ShotType.Granade;
                ShotGranade();
                AttackTime();
            }
        }
    }

    void AttackTime()
    {
        nextAttackTime = Time.time + 1f / attackRate;
    }

    void ShotBasic()
    {
        Instantiate(ammo[(int)ShotType.Basic], transform.position, Quaternion.identity);
    }

    void ShotTriple()
    {
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.Euler(new Vector3(0, 0, 60f)));
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.identity);
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.Euler(new Vector3(0, 0, -60f)));
        shotCap++;
    }

    void ShotGranade()
    {
        Instantiate(ammo[(int)ShotType.Granade], transform.position, Quaternion.identity);
    }

    public void ChangeShot()
    {
        shotType = ShotType.Triple;
    }
}

