using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_effect : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public GameObject ATK1_2, ATK3;
    public void appear1_2()
    {
        ATK1_2.SetActive(true);
    }
    public void appear3()
    {
        ATK3.SetActive(true);
    }
    public void dis1_2()
    {
        ATK1_2.SetActive(false);
    }
    public void dis3()
    {
        ATK3.SetActive(false);
    }
    public void Forward()
    {
        rb.velocity = new Vector2(transform.localScale.x, 0);
        StartCoroutine(Stop());
    }
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector2.zero;
    }
}
