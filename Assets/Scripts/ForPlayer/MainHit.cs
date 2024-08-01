using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat;
    private Color hitColor = Color.white;
    public float hitTime = 0.25f;
    public void Start()
    {
        mat.SetFloat("_FlashAmount", 0);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyATK"))
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
}
