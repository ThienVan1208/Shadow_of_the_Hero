using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat;
    private Color hitColor = Color.white;
    public float hitTime = 0.25f;
    public GameObject slashHit;
    void Start()
    {
        mat.SetFloat("_FlashAmount", 0);
    }

    // Update is called once per frame
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("AttackRange")) 
        {
            SlashHit();
            HitEffect();
        }
        else if (collision.gameObject.CompareTag("skill"))
        {
            HitEffect();
        }

    }
    public void HitEffect()
    {
        StartCoroutine(StopEffect(hitTime));
    }
    public IEnumerator StopEffect(float hitTime)
    {
        mat.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(hitTime);
        mat.SetFloat("_FlashAmount", 0);
    }
    public void SlashHit()
    {
        Instantiate(slashHit, transform.position - new Vector3(0f, 0.5f, 0f), Quaternion.identity);
    }
}
