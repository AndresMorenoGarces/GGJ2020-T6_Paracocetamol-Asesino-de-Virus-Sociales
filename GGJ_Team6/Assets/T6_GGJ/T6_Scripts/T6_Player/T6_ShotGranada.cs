using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotGranada : MonoBehaviour
{
    public float explotionTime;

    float thrust = 400f;
    Rigidbody2D rb2D;
    CircleCollider2D col2D;

    void Awake()
    {
        col2D = transform.GetChild(0).GetComponent<CircleCollider2D>();
        col2D.enabled = false;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine("Destroy");
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
         rb2D.AddForce(Vector2.one * thrust);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(explotionTime);
        col2D.enabled = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
