using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotGranada : MonoBehaviour
{
    public float explotionTime;

    float thrust = 350f;
    Rigidbody2D rb2D;
    CircleCollider2D col2D;

    private Animator anim;

    void Awake()
    {
        col2D = transform.GetChild(0).GetComponent<CircleCollider2D>();
        col2D.enabled = false;
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        Direction();
        StartCoroutine("Destroy");
    }

    private void Direction()
    {
        rb2D.AddForce(Vector2.one * thrust);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(explotionTime);
        col2D.enabled = true;
        anim.SetTrigger("effect");
        Destroy(rb2D);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
