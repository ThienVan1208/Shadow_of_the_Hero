using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossDae : MonoBehaviour
{
    private Vector2 getScale;

    public static float damage = 0.001f;

    public GameObject player;
    public float speed = 3f;
    public Animator animator;
    public Rigidbody2D rb;
    
    public Coroutine currentRoutine, countRoutine;

    // to detect direction of attacking
    protected bool left = true, right = false;
    protected bool die = false;

    
    

    private bool isATK = false;
    private orderOfSkills skill;

    public int numATK;
    private GameObject[] atkObj;

    
    enum orderOfSkills { ATKContinuously = 0, ATKOpen }
    
    // HEALTH
    public float health;

    public static int countTotem = 0;
    public GameObject[] fireHolder;
    public GameObject totem;

    //public float time = 0;

    public Slider slid;
    
    public bool summon = false;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

        getScale = transform.localScale;
        countTotem = 0;

        

        
        

        atkObj = new GameObject[numATK];
        for (int i = 0; i < numATK; i++)
        {
            atkObj[i] = transform.Find("EnemyATK" + i.ToString()).gameObject;
        }

        slid.maxValue = health;
        slid.value = health;
      
        

    }

    public void Update()
    {
        if (!die)
        {
            Direction();
            if(countRoutine == null)
            {
                countRoutine = StartCoroutine(Count());
            }
            if (currentRoutine == null)
            {
                if(summon)
                {
                    currentRoutine = StartCoroutine(Summon());
                    
                }
                else currentRoutine = StartCoroutine(ManageAttack());

            }
            if (countTotem == 8)
            {
                countTotem = 0;
                
            }
        }
    }
    public IEnumerator Count()
    {
        yield return new WaitForSeconds(10f);
        summon = true;
        yield return new WaitForSeconds(3f);
        summon = false;
        countRoutine = null;
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
            Follow();
            if (left && !right)
            {
                transform.localScale = new Vector2(getScale.x, getScale.y);
            }
            if (right && !left)
            {
                transform.localScale = new Vector2(-getScale.x, getScale.y);
            }
        }
    }


    // follow
    public void Follow()
    {
       
        animator.SetFloat("Speed", 1);
        Vector2 follow = (player.transform.position - transform.position).normalized; 
        rb.velocity = new Vector2(follow.x * speed * Time.deltaTime, follow.y * speed * Time.deltaTime) * 100;
        if (follow.x > 0)
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
    private IEnumerator ManageAttack()
    {
        yield return new WaitForSeconds(4);

        animator.SetBool("ATKContinuously", true);
        yield return Attack();

        animator.SetFloat("Speed", 1);
        animator.SetBool("ATKContinuously", false);
        currentRoutine = null;
        isATK = false;
    }

    public void shotFireBall(int index)
    {
        
        fireHolder[index].GetComponent<holdFireBall>().resetFireBall();
        fireHolder[index].transform.position = transform.position;
        fireHolder[index].SetActive(true);
    }

    public IEnumerator Attack()
    {

        
        Debug.Log("atk");
        isATK = true;
        animator.SetFloat("Speed", 0);

        Vector2 attack = (player.transform.position - transform.position).normalized;
       
        shotFireBall(0);

        rb.velocity += (attack * 1.5f * speed);

        yield return new WaitForSeconds(0.5f);
        shotFireBall(1);

        yield return new WaitForSeconds(0.5f);
        shotFireBall(2);

        yield return new WaitForSeconds(0.5f);
        shotFireBall(3);

        yield return new WaitForSeconds(0.5f);
        shotFireBall(4);

    }
    public IEnumerator Summon()
    {
        animator.SetTrigger("ATKOp");
        Instantiate(totem, new Vector3(89.6f, 21.2f, -0.03076696f), Quaternion.identity);
        yield return new WaitForSeconds(4.1f);
        currentRoutine = null;
    }
    
    // OnTriggerEnter2D                              
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("AttackRange"))
        {
            takeDAM(MainControl.damage);
            
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("skill"))
        {
            takeDAM(fire.damage);
        }
    }



    public void takeDAM(float take_dam)
    {
        if (die) return;
        //mino.Hit();
        health -= take_dam;
        GetComponent<DaeSound>().Hit();
        sliderOfHP(health);

        if (health <= 0)
        {
            die = true;

            animator.SetTrigger("die");
            GameManager.Instance.Boss = false;
        }
    }


    public void sliderOfHP(float hp)
    {
        slid.value = hp;
    }


    ///////////////////////////
    public void active()
    {
        for (int i = 0; i < numATK; i++)
        {
            if ((orderOfSkills)i == skill)
            {
                atkObj[i].SetActive(true);
            }
            else
            {
                atkObj[i].SetActive(false);
            }
        }
    }
    public void inactive()
    {
        for (int i = 0; i < numATK; i++)
        {
            atkObj[i].SetActive(false);
        }
    }


}
