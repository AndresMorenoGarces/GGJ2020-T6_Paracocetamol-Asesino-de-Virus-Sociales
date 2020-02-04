using UnityEngine;

public class T6_PlayerController : MonoBehaviour
{
    private int life = 100;
    private int damage;
    private int speed = 6;
    private Vector2 moveY;
    private GameObject shootPlace;
    private GameObject granadePlace;
    private bool upWall;
    private bool downWall;
    private Rigidbody2D rb2D;
    private Animator anim;

    private T6_ShotManager shotChange;
    PlayerStats playerStats = PlayerStats.Iddle;

    public void ShootPlaceState(bool isActive)
    {
        if (isActive)
            shootPlace.SetActive(true);
        else
            shootPlace.SetActive(false);
    }
    public void GranadePlaceState(bool isActive)
    {
        if (isActive)
            granadePlace.SetActive(true);
        else
            granadePlace.SetActive(false);
    }
    public void ChangeAmmo(int kills)
    {
        if (kills % 10 == 0)
            shotChange.ChangeShot();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "UpWall")
            upWall = true;
        else if (collision.tag == "DownWall")
            downWall = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "UpWall")
            upWall = false;
        else if (collision.tag == "DownWall")
            downWall = false;
    }

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

        if (moveY != Vector2.zero)
            playerStats = PlayerStats.isMoving;
        else
            playerStats = PlayerStats.Iddle;
    }
    void FixedUpdate()
    {
        if (upWall)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                speed = 0;
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
                speed = 4;
        }
        if (downWall)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                speed = 0;
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
                speed = 4;
        }
        rb2D.MovePosition(rb2D.position + moveY * Time.fixedDeltaTime);
    }
}
