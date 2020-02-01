using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotManager : MonoBehaviour
{
    public GameObject[] projectile;

    ShotType shotType = ShotType.Basic;
    private int typeOfShot;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    private int shotCap = 0;

    // Start is called before the first frame update
    void Start()
    {
        typeOfShot = 0;
        //ChangedShot(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(shotCap == 10)
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
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void ShotBasic()
    {

        Instantiate(projectile[(int)ShotType.Basic], transform.position, Quaternion.identity);
    }

    void ShotTriple()
    {
        Instantiate(projectile[(int)ShotType.Triple], new Vector2(transform.position.x + 1f , transform.position.y), Quaternion.Euler(new Vector3(0, 0, 60f)));
        Instantiate(projectile[(int)ShotType.Triple], new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.identity);
        Instantiate(projectile[(int)ShotType.Triple], new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.Euler(new Vector3(0, 0, -60f)));
        shotCap++;
        Debug.Log(shotCap);
    }

    public void ChangeShot()
    {
        shotType = ShotType.Triple;
    }

    //void ChangedShot(int type)
    //{
    //    if (typeOfShot != type)
    //    {
    //        switch (type)
    //        {
    //            case 0:
    //                shotType = ShotType.Basic;
    //                typeOfShot = 0;
    //                break;
    //            case 1:
    //                shotType = ShotType.Triple;
    //                typeOfShot = 1;
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}

}
