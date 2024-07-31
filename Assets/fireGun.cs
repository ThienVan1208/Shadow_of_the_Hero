using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject fireShoot;
    private Coroutine curcor = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(curcor == null)
        {
            curcor = StartCoroutine(Fire());
        }
    }
    public IEnumerator Fire()
    {
        animator.SetBool("shoot", false);
        fireShoot.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("shoot", false);
        fireShoot.SetActive(false);
        yield return new WaitForSeconds(3f);
        curcor = null;
    }
}
