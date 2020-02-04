using System.Collections;
using UnityEngine;

public class T6_ShotManager : MonoBehaviour
{
    public GameObject[] ammo;
    public AudioClip[] shotsAudio;

    private int typeOfShot;
    private int shotCap = 0;
    private int countain = 0;
    private float attackRate = 4f;
    private float nextAttackTime = 0f;
    private bool canShotGranade = true;
    private Animator anim;
    private T6_PlayerController player;

    ShotType shotType = ShotType.Basic;

    private void AttackTime()
    {
        nextAttackTime = Time.time + 1f / attackRate;
    }

    private void ShotBasic()
    {
        Instantiate(ammo[(int)ShotType.Basic], transform.position - new Vector3(0,0.7f,0), Quaternion.identity);
    }

    private void ShotTriple()
    {
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x, transform.position.y) - new Vector2(0, 0.7f), Quaternion.Euler(new Vector3(0, 0, 21f)));
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x, transform.position.y) - new Vector2(0, 0.7f), Quaternion.identity);
        Instantiate(ammo[(int)ShotType.Triple], new Vector2(transform.position.x, transform.position.y) - new Vector2(0, 0.7f), Quaternion.Euler(new Vector3(0, 0, -21f)));
        shotCap++;
    }

    private void ShotGranade()
    {
        Instantiate(ammo[(int)ShotType.Granade], transform.position - new Vector3(-1.9f, 0.6f, 0), Quaternion.identity);
        countain++;
        if (countain == 5)
        {
            canShotGranade = false;
            anim.SetBool("granade", false);
            player.GranadePlaceState(false);
            StartCoroutine(ReloadGranades());
        }
    }

    public void ChangeShot()
    {
        shotType = ShotType.Triple;
    }

    IEnumerator ReloadGranades()
    {
        yield return new WaitForSeconds(10f);
        canShotGranade = true;
        countain = 0;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<T6_PlayerController>();
        typeOfShot = 0;
    }
    void Update()
    {
        if (shotCap == 10)
        {
            shotCap = 0;
            shotType = ShotType.Basic;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isShooting", true);
                //T6_AudioManager.am.RandomSoundEffect(shotsAudio);
                T6_AudioManager.am.Play(shotsAudio[0]);
                // AudioSource.PlayClipAtPoint(shotAudio[0], Camera.main.transform.position, 1);
                switch (shotType)
                {
                    case ShotType.Basic:
                        ShotBasic();
                        player.ShootPlaceState(true);
                        break;
                    case ShotType.Triple:
                        ShotTriple();
                        player.ShootPlaceState(true);
                        break;
                    default:
                        break;
                }
                AttackTime();
            }
            else
            {
                anim.SetBool("isShooting", false);
                player.ShootPlaceState(false);
            }
            if (canShotGranade)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    anim.SetBool("granade", true);
                    // T6_AudioManager.am.RandomSoundEffect(shotsAudio);
                    T6_AudioManager.am.Play(shotsAudio[1]);
                    //AudioSource.PlayClipAtPoint(shotAudio[1], Camera.main.transform.position, 2);
                    shotType = ShotType.Granade;
                    player.GranadePlaceState(true);
                    ShotGranade();
                    AttackTime();
                    shotType = ShotType.Basic;
                }
                else
                {
                    anim.SetBool("granade", false);
                    player.GranadePlaceState(false);
                }
            }
        }
    }
}

