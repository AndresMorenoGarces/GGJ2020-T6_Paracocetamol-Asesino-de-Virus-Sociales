using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_GameManager : MonoBehaviour
{
    private int life;

    private void Awake()
    {
        life = 100;
    }
    void Start()
    {

    }

    void Update()
    {

    }
    
    public void RecibeDamage(int damage)
    {
        life -= damage;
        Debug.Log(life);
    }
}
