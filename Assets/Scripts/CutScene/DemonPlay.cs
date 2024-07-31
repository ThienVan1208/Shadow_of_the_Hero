using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private Coroutine currCo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currCo == null )
        {
            currCo = StartCoroutine(Starting(7f));
        }
    }
    IEnumerator Starting(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Attack");
    }

}
