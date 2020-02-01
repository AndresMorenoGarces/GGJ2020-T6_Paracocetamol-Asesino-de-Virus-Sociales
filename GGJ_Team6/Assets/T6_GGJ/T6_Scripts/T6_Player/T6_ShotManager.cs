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

    // Start is called before the first frame update
    void Start()
    {
        typeOfShot = 0;
        //ChangedShot(1);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time >= nextAttackTime)
        //{
            if (Input.GetButtonDown("Fire1"))
                ShotBasic();

            if (Input.GetButtonDown("Fire2"))
                ShotTriple();

           // nextAttackTime = Time.time + 1f / attackRate;
        //}
    }

    void ShotBasic()
    {

        Instantiate(projectile[(int)ShotType.Basic], transform.position, Quaternion.identity);
    }

    void ShotTriple()
    {
        Instantiate(projectile[(int)ShotType.Triple], new Vector2(transform.position.x - 6f , transform.position.y), Quaternion.Euler(new Vector3(0, 0, 60f)));
        Instantiate(projectile[(int)ShotType.Triple], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Instantiate(projectile[(int)ShotType.Triple], new Vector2(transform.position.x - 6f, transform.position.y), Quaternion.Euler(new Vector3(0, 0, -60f)));
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
