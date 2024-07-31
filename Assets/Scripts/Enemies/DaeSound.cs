using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaeSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource walk;
    public AudioSource ATKcon;
    public AudioSource ATKop;
    public AudioSource die;
    public AudioSource hit;

    public void Walk()
    {
        walk.Play();
        walk.loop = false;
    }
     public void ATKCON()
    {
        ATKcon.Play();
        ATKcon.loop = false;
    }
    public void Die()
    {
        die.Play();
        die.loop = false;
    }
    public void ATKOP()
    {
        ATKop.Play();
        ATKop.loop = false;
    }
    public void Hit() { hit.Play(); 
    hit.loop = false;
            }
}
