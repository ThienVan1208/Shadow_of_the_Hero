using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totem : MonoBehaviour
{
    private Vector2 getScale;

    public static float damage = 0.001f;

    public GameObject player;
    public float speed = 3f;
    public Animator animator;
    
    public bool isFollowing = false;
    public Coroutine currentRoutine;

    // to detect direction of attacking
    protected bool left = true, right = false;
    protected bool die = false;

    private bool isATK = false;
    // HEALTH
    public float health;

    public Slider slid;

    public GameObject fireBall;
    public Vector2 atkRange;


    public void Start()
    {
        GameManager.Instance.Boss = true;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        getScale = transform.localScale;

       

        animator.SetTrigger("Start");

        slid.maxValue = health;
        slid.value = health;
        


    }
    

    // Update is called once per frame
    void Update()
    {
        if (!die)
        {
            Direction();
            if (currentRoutine == null)
            {
                if (!die)
                {
                    currentRoutine = StartCoroutine(ManageAttack());
                }
            }
            if(!GameManager.Instance.Boss)
            {
                Die();
            }
        }
    }

    public void Direction()
    {
        if (transform.position.y < player.transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        if (transform.position.x >= player.transform.position.x)
        {
            left = true;
            right = false;
        }
        else
        {
            left = false;
            right = true;
        }

        if (!isATK)
        {
            
            if (left && !right)
            {
                transform.localScale = new Vector2(-getScale.x, getScale.y);
            }
            if (right && !left)
            {
                transform.localScale = new Vector2(getScale.x, getScale.y);
            }
        }
    }
    private IEnumerator ManageAttack()
    {
        if (!die)
        {
            yield return new WaitForSeconds(2f);
            attack();
        }
        
    }
    public void attack()
    {
        if (!die)
        {
            Vector2 dis = player.transform.position - transform.position;
            if (Mathf.Abs(dis.x) <= atkRange.x && Mathf.Abs(dis.y) <= atkRange.y)
            {
                Vector2 follow = player.transform.position - transform.position;
                float radAngle = Mathf.Atan2(follow.y, follow.x);
                float degAngle = radAngle / Mathf.Deg2Rad;

                animator.SetTrigger("Atk");
                Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, degAngle));
            }
            currentRoutine = null;
        }
    }
    public void takeDAM(float take_damage)
    {
        if (die) return;
        health -= take_damage;
        sliderOfHP(health);
        if (health < 0) health = 0;
        if (health <= 0)
        {
            die = true;
            animator.SetTrigger("die");
        }


    }
    public void sliderOfHP(float hp)
    {
        slid.value = hp;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (die) return;
        if (collision.gameObject.CompareTag("skill"))
        {
            takeDAM(fire.damage);

        }

        if (collision.gameObject.CompareTag("AttackRange"))
        {
            takeDAM(MainControl.damage);
        }
    }
    public void Die()
    {
        BossDae.countTotem++;
        gameObject.SetActive(false);
    }

}
