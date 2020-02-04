using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    public GameObject[] Intro;
    public int i;

    void Start()
    {
        i = 0;
        StartCoroutine(ShowNextScene());
    }

    IEnumerator ShowNextScene()
    {
        Intro[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
        yield return new WaitForSeconds(2f);
        if (i < Intro.Length -1)
        {
            i++;
            Intro[i - 1].GetComponent<SpriteRenderer>().sortingOrder = 0;
            StartCoroutine(ShowNextScene());
        }
        else
            StartCoroutine(ChangeScene());
    }
   
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
