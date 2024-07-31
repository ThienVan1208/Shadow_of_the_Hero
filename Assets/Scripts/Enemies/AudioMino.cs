using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMino : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource slash;
    public AudioSource straight_slash;
    public AudioSource spin;
    public AudioSource breath;
    public AudioSource crushGround;
    public AudioSource die;
    public AudioSource hit;

    public void Slash()
    {
        slash.Play();
        slash.loop = false;
    }
    public void Spin()
    {
        spin.Play();
        spin.loop = false;
    }
    public void StraightSlash()
    {
        straight_slash.Play();
        straight_slash.loop = false;
    }
    public void Breath()
    {
        breath.Play();
        breath.loop = false;
    }
    public void CrushGround()
    {
        crushGround.Play();
        crushGround.loop = false;
    }
    public void Die()
    {
        die.Play();
        die.loop = false;
    }
    public void Hit()
    {
        hit.Play();
        hit.loop = false;
    }
}
