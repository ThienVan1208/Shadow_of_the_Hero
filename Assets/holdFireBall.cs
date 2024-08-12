using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class holdFireBall : MonoBehaviour
{
    public GameObject[] fireBall;
    public int count { get; set; } = 0;
    
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        for (int i = 0; i < fireBall.Length; i++)
        {
            fireBall[i].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if(count == 8)
        {
            resetFireBall();
        }
    }

    public void resetFireBall()
    {
        count = 0;
        for (int i = 0; i < fireBall.Length; i++)
        {
            fireBall[i].SetActive(false);
            fireBall[i].transform.position = transform.position;
        }
        gameObject.SetActive(false);
    }
    
}
