using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_AudioManager : MonoBehaviour
{
    public static T6_AudioManager am;

    public AudioClip hit;

    private void Awake()
    {
        if (am == null)
            am = this;
        else if (am != this)
            Destroy(gameObject);
    }

    void Start()
    {
        AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position, 1);
    }

    void Update()
    {
        
    }


}
