using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public GameObject[] Intro;
    public int i;

    void Start()
    {
        i = 0;
        StartCoroutine(Changei());
        StartCoroutine(ChangeScene());
    }

    void Update()
    {
        Intro[i].transform.Translate(Vector2.right * Time.deltaTime * 6);      
    }

    IEnumerator Changei()
    {
        Debug.Log(i);
        //StartCoroutine(ChangeM());
        yield return new WaitForSeconds(4);
        i = 1;
    }

    //IEnumerator ChangeM()
    //{
    //    yield return new WaitForSeconds(4);
    //    i = 2;
    //}

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene("T6_UIMain" , LoadSceneMode.Single);
    }
}
