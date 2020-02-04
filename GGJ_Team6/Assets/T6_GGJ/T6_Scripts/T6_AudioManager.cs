using UnityEngine;

public class T6_AudioManager : MonoBehaviour
{
    public static T6_AudioManager am;
    public AudioSource musicSource;
    public AudioSource effectsSource;

    private float lowPitchRange = .95f;
    private float highPitchRange = 1.05f;

    private void Awake()
    {
        if (am == null)
            am = this;
        else if (am != this)
            Destroy(gameObject);
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
}
