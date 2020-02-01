using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotType : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Destroy(gameObject);
        }
    }
}
