using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShotGranada : MonoBehaviour
{
    public float explotionTime;
    public AudioClip explosionAudio;

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
        T6_AudioManager.am.Play(explosionAudio);
       // AudioSource.PlayClipAtPoint(explosionAudio, Camera.main.transform.position, 1);
        col2D.enabled = true;
        anim.SetTrigger("effect");
        Destroy(rb2D);
        T6_AudioManager.am.Play(explosionAudio);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
