using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject light;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activeLight()
    {

        light.SetActive(true);
    }
    public void inactiveLight()
    {
        light.SetActive(false);
    }
}
