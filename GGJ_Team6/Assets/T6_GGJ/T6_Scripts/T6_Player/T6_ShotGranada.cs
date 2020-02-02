using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotGranada : MonoBehaviour
{
    public float thrust = 1f;

    Rigidbody2D rb2D;
    CircleCollider2D col2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<CircleCollider2D>();
        col2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
