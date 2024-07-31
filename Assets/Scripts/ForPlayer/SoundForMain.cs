using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundForMain : MonoBehaviour
{
    

    // Start is called before the first frame update
    public AudioSource sword1;
    public AudioSource sword2;
    
    public AudioSource hit;
    public AudioSource dash;
    public AudioSource run;
    public bool mute;
    
    
    public void swordATK1()
    {
        if (!mute)
        {
            sword1.Play();
            sword1.loop = false;
        }
    }
    public void swordATK2()
    {
        if (!mute)
        {
            sword2.Play();
            sword2.loop = false;
        }
    }

    public void Hit()
    {
        if (!mute)
        {
            hit.Play();
            hit.loop = false;
        }
    }

    public void Run()
    {
        if (!mute)
        {
            run.Play();
            run.loop = false;
        }
    }
    public void FlipDash()
    {
        if (!mute)
        {
            dash.Play();
            dash.loop = false;
        }
    }
    
}
