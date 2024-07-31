using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio sound;

    // Start is called before the first frame update
    
    public AudioSource battleSound;
    public AudioSource normalSound;
    

    public void Awake()
    {
        if (sound != null)
        {
            Destroy(gameObject);
        }
        else
        {
            sound = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        NormalSound();
    }
    public void Update()
    {
        //if(GameManager.Instance.Minotaur)
        //{
        //    BattleSound();
        //    StopNormal();
        //}
        //else if(!GameManager.Instance.Minotaur)
        //{
        //    NormalSound();
        //    StopBattle();
        //}
    }
    public void BattleSound()
    {
        battleSound.Play();
        battleSound.loop = true;
    }
    public void StopBattle()
    {
        battleSound.loop = false;
        battleSound.Stop();
    }
    public void NormalSound()
    {
        normalSound.Play();
        normalSound.loop = true;
    } 
    public void StopNormal()
    {
        normalSound.loop = false;
        normalSound.Stop();
    }
    
}
