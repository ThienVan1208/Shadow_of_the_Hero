using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDie : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem sys;
    public void Start()
    {
        sys.Stop();
        StartCoroutine(On());
    }
    IEnumerator On()
    {
        sys.Stop();
        yield return new WaitForSeconds(12f);
        sys.Play();
        yield return new WaitForSeconds(2f);
        sys.Stop();
    }
}
