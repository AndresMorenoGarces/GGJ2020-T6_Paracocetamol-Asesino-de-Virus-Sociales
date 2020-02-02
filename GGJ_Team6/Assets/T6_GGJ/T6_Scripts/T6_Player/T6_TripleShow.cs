using UnityEngine;

public class T6_TripleShow : MonoBehaviour
{
    [Range(2f, 8f)]public float speedTriple;

    void Update()
    {
        if (transform.rotation.z == 0)
            transform.position += Vector3.right * Time.deltaTime * speedTriple;
        else if (transform.rotation.z < 0)
            transform.position += new Vector3(1f, -.1f) * Time.deltaTime * speedTriple;
        else
            transform.position += new Vector3(1f, .1f) * Time.deltaTime * speedTriple;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Destroy(gameObject);
        }

        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
