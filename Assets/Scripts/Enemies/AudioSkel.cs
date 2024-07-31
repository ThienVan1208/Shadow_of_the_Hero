using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSkel : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource atk;
    public AudioSource die;
    public AudioSource hit;
    public AudioSource walk;

    public void ATK()
    {
        atk.Play();
        atk.loop = false;
    }
    public void Hit()
    {
        hit.Play();
        hit.loop = false;
    }
    public void Die()
    {
        die.Play();
        die.loop = false;
    }
    public void Walking()
    {
        walk.Play();
        walk.loop = false;
    }
}
