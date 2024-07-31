using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desObj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Animator anim;
    public GameObject shadow;
    private bool canDes = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackRange") || collision.gameObject.CompareTag("RangeToATK") || collision.gameObject.CompareTag("EnemyATK"))
        {
            if (!canDes)
            {
                canDes = true;
                anim.SetTrigger("destroy");
            }
        }
    }
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void Update()
    {
        Direction();
    }
    public void Inactive()
    {
        gameObject.SetActive(false);
    }
    public void Shadow()
    {
        shadow.SetActive(false);
    }
    public void Direction()
    {
        if (transform.position.y < player.transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
