using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private Coroutine curCo;
    public ParticleSystem sys;
    public bool intro1, intro2, intro3, intro4;
    void Start()
    {

        sys.Stop();
        
    }

    // Update is called once per frame

    void Update()
    {
        if (curCo == null)
        {
            if (intro1) 
            { 
                curCo = StartCoroutine(Intro1(3f));
            }
            else if (intro2) 
            {
                curCo = StartCoroutine(Intro2(3f));
            }
            else if(intro3)
            {
                curCo = StartCoroutine(Intro3());
            }    
            else if(intro4)
            {
                curCo = StartCoroutine(Intro4());
            }    
        }
    }
    IEnumerator Intro1(float time)
    {
        anim.SetBool("idle", false);
        
        anim.SetBool("run", true);
        yield return new WaitForSeconds(time);
        anim.SetBool("run", false);
        
        anim.SetBool("idle", true);
        yield return new WaitForSeconds (time + 1f);
        anim.SetTrigger("jump");
        yield return new WaitForSeconds(9f);
        anim.SetTrigger("after");
    }
    public void On()
    {
        sys.Play();
    }
    public void Off()
    {
        sys.Stop();
    }
    IEnumerator Intro2(float time)
    {
        anim.SetBool("run", true);
        yield return new WaitForSeconds(1.483f);

        anim.SetBool ("run", false);
        anim.SetBool("idle", true) ;
        yield return new WaitForSeconds(0.683f);

        anim.SetBool("idle", false);
        anim.SetBool("run", true);
        yield return new WaitForSeconds(4f);

        anim.SetBool("run", false);
        anim.SetBool("idle", true);
        yield return new WaitForSeconds(0.96f);

        anim.SetBool("idle", false);
        anim.SetBool("run", true);
        yield return new WaitForSeconds(1f);

        anim.SetBool("run", false);
        anim.SetBool("idle", true);
    }
    IEnumerator Intro3()
    {
        anim.SetBool("run", false);
        anim.SetBool("die", true);
        yield return null;
    }
    IEnumerator Intro4()
    {
        //anim.SetBool("idle", false);
        //anim.SetBool("run", true);
        yield return new WaitForSeconds(2f);

        anim.SetBool("run", false);
        anim.SetBool("idle", true);
    }
}
