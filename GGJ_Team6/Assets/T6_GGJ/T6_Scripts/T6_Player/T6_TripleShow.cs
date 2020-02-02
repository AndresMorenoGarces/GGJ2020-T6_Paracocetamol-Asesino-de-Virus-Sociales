using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_TripleShow : MonoBehaviour
{
    [Range(2f, 8f)]public float speedTriple;

    private Animator anim;
    private bool animationDontStart = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (animationDontStart)
        {
            if (transform.rotation.z == 0)
                transform.position += Vector3.right * Time.deltaTime * speedTriple;
            else if (transform.rotation.z < 0)
                transform.position += new Vector3(1f, -.1f) * Time.deltaTime * speedTriple;
            else
                transform.position += new Vector3(1f, .1f) * Time.deltaTime * speedTriple;
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Destroy(gameObject);
        }

        if(collision.tag == "Enemy")
        {
            animationDontStart = false;
            anim.SetTrigger("Effect");
            StartCoroutine(WaitAnimation());
        }
    }

    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
