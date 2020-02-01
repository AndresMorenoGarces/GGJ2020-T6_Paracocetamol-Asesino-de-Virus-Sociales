using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_PlayerController : MonoBehaviour
{
    public int speed;

    private T6_ShotManager shotChange;

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
        shotChange = GetComponent<T6_ShotManager>();
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
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveY * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            shotChange.ChangeShot();
        }

    }
}
