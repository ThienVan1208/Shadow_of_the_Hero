using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCharIntro2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public Coroutine cor;
    public bool intro4;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
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
    IEnumerator Intro2()
    {
        anim.SetFloat("speed", 1);
        yield return new WaitForSeconds(3.4f);
        anim.SetFloat("speed", 0);
    }
    IEnumerator Intro4()
    {
        anim.SetFloat("speed", 1);
        yield return new WaitForSeconds(2f);
        anim.SetFloat("speed", 0);
    }
}
