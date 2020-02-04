using System.Collections;
using UnityEngine;

public class T6_ShotBasic : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    private Animator anim;
    private bool animationDontStart = true;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
            Destroy(gameObject);
        if (collision.tag == "Enemy")
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

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (animationDontStart)
            transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
        else
            return;
    }
}
