using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCharIntro2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public Coroutine cor = null;
    public bool intro4;

    public void Start()
    {
        
        
    }
    public void OnEnable()
    {
        if (cor == null)
        {
            if (!intro4)
            {
                cor = StartCoroutine(Intro2());
            }
            else if (intro4)
            {
                cor = StartCoroutine(Intro4());
            }
        }
    }

    public void Update()
    {
        
    }
    IEnumerator Intro2()
    {
        anim.SetFloat("speed", 1);
        yield return new WaitForSeconds(3.4f);
        anim.SetFloat("speed", 0);
    }
    public IEnumerator Intro4()
    {
        anim.SetFloat("speed", 1);
        Debug.Log("run");
        yield return new WaitForSeconds(2f);
        anim.SetFloat("speed", 0);
        Debug.Log("idle");
        
    }
}
