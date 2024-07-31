using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Rigidbody2D rigid;
    public float force, time;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator DetectPlayer()
    {
        Vector2 dir = player.transform.position - transform.position;
        rigid.AddForce(-dir * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(time);
        rigid.velocity = Vector2.zero;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("AttackRange"))
        {
            StartCoroutine(DetectPlayer());
        }
    }
}
