using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstruct : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim.SetTrigger("in");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickButton()
    {
        StartCoroutine(click());
    }
    public IEnumerator click()
    {
        anim.SetTrigger("out");
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }

}
