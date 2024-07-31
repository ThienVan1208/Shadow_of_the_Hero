using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public interface IEnemies
{
    IEnumerator Lwalk();
    IEnumerator Rwalk();
    IEnumerator Walk();
    void follow();
}
public class Enemy : MonoBehaviour, IEnemies
{
    // RANGE TO FOLLOW AND ATK
    

    public GameObject player;
    public float speed = 3f;
    public Animator animator;
    public Rigidbody2D rb;
    public bool isFollowing = false;
    public Coroutine currentRoutine = null;

    // to detect direction of attacking
    protected bool left = false, right = false;
    protected bool die = false;

    public float attackX ;
    public float attackY ;
    public float followX, followY ;

    public bool initL, initR ;

    public static float damage = 0.001f;
    // HEALTH
    public float health;

    public Slider slid;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        

        rb = GetComponent<Rigidbody2D>();
        currentRoutine = StartCoroutine(Walk());
        attackX = 2.7f;
        attackY = 2.7f;
        followX = 5f;
        followY = 5f;

        slid.maxValue = health;
        slid.value = health;
    }
    public void Update()
    {
        if (!die)
        {
            if (isFollowing)
            {
                follow();
            }
            float disX = Mathf.Abs(transform.position.x - player.transform.position.x);
            float disY = Mathf.Abs(transform.position.y - player.transform.position.y);

            if (disX <= attackX && disY <= attackY)
            {
                if(currentRoutine == null)
                {
                    currentRoutine = StartCoroutine( Attack());
                }
                
               
            }
            if(disX <= followX && disY <= followY) 
            {
                isFollowing = true; 
            }
            if (health <= 0)
            {
                die = true;
                Debug.Log("Skeleton dies");
                if (left && !right) animator.SetTrigger("t_LDie");
                else if (right && !left) animator.SetTrigger("t_RDie");
                //Set Active false in animator
            }
        }
        



    }
    // Coroutine Walk
    public IEnumerator Walk()
    {
        while (!isFollowing)
        {
            if (initL && !initR)
            {
                yield return Lwalk();
                yield return LeftIdle(3f);
                yield return Rwalk();
                yield return RightIdle(3f);
            }
            else if(initR && !initL)
            {
                yield return Rwalk();
                yield return RightIdle(3f);
                yield return Lwalk();
                yield return LeftIdle(3f);
                
            }
        }
    }

    // Lwalk
    public IEnumerator Lwalk()
    {
        left = true;
        right = false;
        animator.SetFloat("hori", -1);
        animator.SetBool("L", false);
        animator.SetBool("R", false);
        for (float timer = 0; timer < 3f; timer += Time.deltaTime)
        {
            
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            yield return null;
        }
    }

    // Rwalk
    public IEnumerator Rwalk()
    {
        right = true;
        left = false;
        animator.SetFloat("hori", 1);
        animator.SetBool("R", false);
        animator.SetBool("L", false);
        for (float timer = 0; timer < 3f; timer += Time.deltaTime)
        {
            
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            yield return null;
        }
    }

    // Idle
    public IEnumerator LeftIdle(float duration)
    {
        isFollowing = false;
        animator.SetBool("L", true);
        animator.SetBool("R", false);
        yield return new WaitForSeconds(duration);
        animator.SetBool("L", false);
        animator.SetBool("R", false);
        currentRoutine = null;
        
    }
    public IEnumerator RightIdle(float duration)
    {
        isFollowing = false;
        animator.SetBool("L", false);
        animator.SetBool("R", true);
        yield return new WaitForSeconds(duration);
        animator.SetBool("L", false);
        animator.SetBool("R", false);
        currentRoutine = null;
        
    }
    
    // follow
    public void follow()
    {
        
        animator.SetBool("R", false);
        animator.SetBool("L", false);
        isFollowing = true;
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        Vector2 follow = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(follow.x * 5, follow.y * 5 );
        animator.SetFloat("hori", follow.x );
        if(follow.x > 0)
        {
            right = true;
            left = false;
        }
        else
        {
            right = false;
            left = true;
        }
        
    }
    public IEnumerator Attack()
    {
        
        if(right && !left)
        {
            animator.SetTrigger("t_RAtk");
            yield return RightIdle(2f);
        }
        else if(left && !right)
        {
            animator.SetTrigger("t_LAtk");
            yield return LeftIdle(2f);
        }
        isFollowing = true;
    }
    public IEnumerator StopATK(float time)
    {
        yield return new WaitForSeconds(time);
        if (right && !left)
        {
            animator.SetTrigger("t_RAtk");
        }
        else if (left && !right)
        {
            animator.SetTrigger("t_LAtk");
        }
    }
    // OnTriggerEnter2D                              
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFollowing = true;
        }
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("skill"))
        {
            takeDAM(fire.damage);

        }

        if (collision.gameObject.CompareTag("AttackRange"))
        {
            takeDAM(MainControl.damage);
        }
    }


    public void takeDAM(float take_damage)
    {
        if (die) return;
        GetComponent<AudioSkel>().Hit();
        health -= take_damage;
        sliderOfHP(health);
        if(health < 0) health = 0;
        if (health <= 0)
        {
            die = true;
            Debug.Log("skeleton dies");
            if (left && !right) animator.SetTrigger("t_LDie");
            else if (right && !left) animator.SetTrigger("t_RDie");
            //Set Active false in animator
        }


    }


    public void sliderOfHP(float hp)
    {
        slid.value = hp;
    }




}