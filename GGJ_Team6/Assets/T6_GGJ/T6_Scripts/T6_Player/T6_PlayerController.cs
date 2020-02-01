using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_PlayerController : MonoBehaviour
{
    public int speed;
    public Vector2 moveY;

    private int life = 100;
    private int damage;

    PlayerStats playerStats = PlayerStats.Iddle;
    Rigidbody2D rb2D;
    Animator anim;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputY = new Vector2(0, Input.GetAxisRaw("Vertical"));
        moveY = inputY.normalized * speed;
        Debug.Log(moveY + "Hello !");

    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveY * Time.fixedDeltaTime);
    }
}
