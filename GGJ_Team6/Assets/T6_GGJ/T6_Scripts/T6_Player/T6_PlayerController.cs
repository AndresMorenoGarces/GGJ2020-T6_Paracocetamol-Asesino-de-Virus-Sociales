using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public int speed;

    private float attackRate = 2f;
    private float nextAttackTime = 0f;
    private Vector2 moveY;
    private int life = 100;
    private int damage;

    PlayerStats playerStats = PlayerStats.Iddle;
    Rigidbody2D rb2D;
    Animator anim;

    void Awake()
    {

    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        Vector2 inputY = new Vector2(0, Input.GetAxisRaw("Vertical"));
        moveY = inputY.normalized * speed;

        if (moveY != new Vector2(0,0))
        {
            playerStats = PlayerStats.isMoving;
        }
        else
        {
            playerStats = PlayerStats.Iddle;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Shot()
    {
        Instantiate(projectile, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveY * Time.fixedDeltaTime);
    }
}
