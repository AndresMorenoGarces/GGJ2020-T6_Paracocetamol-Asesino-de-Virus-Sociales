using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotManager : MonoBehaviour
{
    public GameObject[] ammo;

    ShotType shotType = ShotType.Basic;
    private int typeOfShot;
    private float attackRate = 4f;
    private float nextAttackTime = 0f;
    private bool canShotGranade = true;

    private Animator anim;
    private T6_PlayerController player;

    private int shotCap = 0;

    int countain = 0;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<T6_PlayerController>();
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
                anim.SetBool("isShooting", true);
                switch (shotType)
                {
                    case ShotType.Basic:
                        ShotBasic();
                        player.activeShootPlace();
                        break;
                    case ShotType.Triple:
                        ShotTriple();
                        player.activeShootPlace();
                        break;
                    default:
                        break;
                }
                AttackTime();
            }
            else
            {
                anim.SetBool("isShooting", false);
                player.disableShootPlace();
            }
            if (canShotGranade)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    anim.SetBool("granade", true);
                    shotType = ShotType.Granade;
                    player.activeGranadePlace();
                    ShotGranade();
                    AttackTime();
                    shotType = ShotType.Basic;
                }
                else
                {
                    anim.SetBool("granade", false);
                    player.disableGranadePlace();
                }
            }
        }
    }

    void AttackTime()
    {
        nextAttackTime = Time.time + 1f / attackRate;
    }

    void ShotBasic()
    {
        Instantiate(ammo[(int)ShotType.Basic], transform.position - new Vector3(0,0.7f,0), Quaternion.identity);
    }

    void ShotTriple()
    {
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x, transform.position.y) - new Vector2(0, 0.7f), Quaternion.Euler(new Vector3(0, 0, 21f)));
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x, transform.position.y) - new Vector2(0, 0.7f), Quaternion.identity);
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x, transform.position.y) - new Vector2(0, 0.7f), Quaternion.Euler(new Vector3(0, 0, -21f)));
        shotCap++;
    }

    void ShotGranade()
    {
        Instantiate(ammo[(int)ShotType.Granade], transform.position - new Vector3(-1.9f, 0.6f,0), Quaternion.identity);
        countain++;
        if (countain == 5)
        {
            canShotGranade = false;
            anim.SetBool("granade", false);
            player.disableGranadePlace();
            StartCoroutine(ReloadGranades());
        }
    }

    public void ChangeShot()
    {
        shotType = ShotType.Triple;
    }

    IEnumerator ReloadGranades()
    {
        yield return new WaitForSeconds(10f);
        canShotGranade = true;
        countain = 0;
        Debug.Log("Si sirvo");
    }
}

