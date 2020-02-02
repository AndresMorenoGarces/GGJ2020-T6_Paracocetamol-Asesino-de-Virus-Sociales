using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_AudioManager : MonoBehaviour
{
    public static T6_AudioManager am;

    public AudioSource musicSource;
    public AudioSource effectsSource;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    private void Awake()
    {
        if (am == null)
            am = this;
        else if (am != this)
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Play(AudioClip clip)
    {
        effectsSource.clip = clip;
        effectsSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

   // public void RandomSoundEffect(params AudioClip[] clips)
   // {
       // int randomIndex = Random.Range(0, clips.Length);
      //  float randomPitch = Random.Range(lowPitchRange, highPitchRange);

       // effectsSource.pitch = randomPitch;
      //  effectsSource.clip = clips[randomIndex];
     //   effectsSource.Play();
   // }
}
