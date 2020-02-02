using UnityEngine;

public class T6_PlayerController : MonoBehaviour
{
    private int speed = 6;
    private T6_ShotManager shotChange;
    private Vector2 moveY;
    private int life = 100;
    private int damage;
    private GameObject shootPlace;
    private GameObject granadePlace;

    bool upWall;
    bool downWall;
    PlayerStats playerStats = PlayerStats.Iddle;
    Rigidbody2D rb2D;
    Animator anim;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shotChange = GetComponent<T6_ShotManager>();
        shootPlace = transform.GetChild(1).gameObject;
        granadePlace = transform.GetChild(2).gameObject;
    }

    private void Start()
    {
        shootPlace.SetActive(false);
        granadePlace.SetActive(false);
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
        if (upWall)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                speed = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                speed = 4;
            }
        }

        if (downWall)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                speed = 0;
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                speed = 4;
            }
        }
        rb2D.MovePosition(rb2D.position + moveY * Time.fixedDeltaTime);
    }

    public void activeShootPlace()
    {
        shootPlace.SetActive(true);
    }

    public void disableShootPlace()
    {
        shootPlace.SetActive(false);
    }

    public void activeGranadePlace()
    {
        granadePlace.SetActive(true);
    }

    public void disableGranadePlace()
    {
        granadePlace.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            shotChange.ChangeShot();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "UpWall")
        {
            upWall = true;
        }
        else if (collision.tag == "DownWall")
        {
            downWall = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "UpWall")
        {
            upWall = false;
        }
        else if (collision.tag == "DownWall")
        {
            downWall = false;
        }
    }
}
