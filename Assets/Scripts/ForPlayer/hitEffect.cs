using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public float hitTime = 0.25f;
    public GameObject slashHit;
    public SpriteRenderer spRen;
    void Start()
    {
        spRen = GetComponent<SpriteRenderer>();
        
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
        Color color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        spRen.color = color;
        yield return new WaitForSeconds(hitTime);
        spRen.color = Color.white;
    }
    public void SlashHit()
    {
        Instantiate(slashHit, transform.position - new Vector3(0f, 0.5f, 0f), Quaternion.identity);
    }
}
