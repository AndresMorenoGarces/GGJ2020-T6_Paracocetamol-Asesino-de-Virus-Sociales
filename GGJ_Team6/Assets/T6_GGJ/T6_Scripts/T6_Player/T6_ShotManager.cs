using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotManager : MonoBehaviour
{
    public GameObject[] ammo;

    ShotType shotType = ShotType.Basic;
    private int typeOfShot;
    private float attackRate = 2.2f;
    private float nextAttackTime = 0f;

    private Animator anim;

    private int shotCap = 0;

    int countain;

    void Awake()
    {
        anim = GetComponent<Animator>();
        typeOfShot = 0;
    }

    void Update()
    {
        if (shotCap == 10)
        {
            shotCap = 0;
            shotType = ShotType.Basic;
        }

        if (countain == 5)
        {
            countain = 0;

        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isShooting", true);
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
            else
            {
                anim.SetBool("isShooting", false);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetBool("granade", true);
                shotType = ShotType.Granade;
                ShotGranade();
                AttackTime();
            }
            else
            {
                anim.SetBool("granade", false);
            }
        }
    }

    void AttackTime()
    {
        nextAttackTime = Time.time + 1f / attackRate;
    }

    void ShotBasic()
    {
        Instantiate(ammo[(int)ShotType.Basic], transform.position - new Vector3(0,0.75f,0), Quaternion.identity);
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
        countain++;
    }

    public void ChangeShot()
    {
        shotType = ShotType.Triple;
    }
}

