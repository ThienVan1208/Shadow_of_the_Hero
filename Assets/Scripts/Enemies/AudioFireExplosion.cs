using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFireExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource fire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        fire.Play();
        fire.loop = false;
    }
}
