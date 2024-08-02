using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeEndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        die();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void die()
    {
        animator.SetTrigger("die");
    }
}
