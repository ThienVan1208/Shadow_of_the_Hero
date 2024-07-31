using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObj : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource broken;
    public void Broken()
    {
        broken.Play();
        broken.loop = false;
    }
}
