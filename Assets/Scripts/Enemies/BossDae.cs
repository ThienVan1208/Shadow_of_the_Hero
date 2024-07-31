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
    public bool isFollowing = false;
    public Coroutine currentRoutine, countRoutine;

    // to detect direction of attacking
    protected bool left = true, right = false;
    protected bool die = false;

    public float attackX;
    public float attackY;
    public float followX, followY;

    private bool isATK = false;
    private orderOfSkills skill;

    public int numATK;
    private GameObject[] atkObj;

    
    enum orderOfSkills { ATKContinuously = 0, ATKOpen }
    
    // HEALTH
    public float health;

    public static int countTotem = 8;/// <summary>
                                     /// ////////////////////////////////////////////////////////////////
                                     /// </summary>
    public GameObject fireBall;
    public GameObject totem;

    //public float time = 0;

    public Slider slid;
    // Start is called before the first frame update

    //public AudioMino mino;
    public bool summon = false;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        getScale = transform.localScale;
        countTotem = 8;

        rb = GetComponent<Rigidbody2D>();

        attackX = 2f;
        attackY = 2f;
        followX = 5f;
        followY = 5f;

        atkObj = new GameObject[numATK];
        for (int i = 0; i < numATK; i++)
        {
            atkObj[i] = transform.Find("EnemyATK" + i.ToString()).gameObject;
        }

        slid.maxValue = health;
        slid.value = health;
        isFollowing = true;
        

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
                    if (countTotem == 8)
                    {
                        currentRoutine = StartCoroutine(Summon());
                        countTotem = 0;
                    }
                }
                else currentRoutine = StartCoroutine(ManageAttack());

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
        Vector2 follow = player.transform.position - transform.position; 
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
        //yield return new WaitForSeconds(2f);


        animator.SetFloat("Speed", 1);
        animator.SetBool("ATKContinuously", false);
        currentRoutine = null;
        isATK = false;
    }

    public void shotFireBall()
    {
        Instantiate(fireBall, transform.position, Quaternion.Euler(0,0,0));
        Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 45));
        Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 135));
        Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 225));
        Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 270));
        Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 315));
    }

    public IEnumerator Attack()
    {

        float time = 0;
        Debug.Log("atk");
        isATK = true;
        animator.SetFloat("Speed", 0);

        Vector2 attack = player.transform.position - transform.position;
       
        shotFireBall();

        rb.velocity += (attack * 1.5f);

        yield return new WaitForSeconds(0.5f);
        shotFireBall();

        yield return new WaitForSeconds(0.5f);
        shotFireBall();

        yield return new WaitForSeconds(0.5f);
        shotFireBall();

        yield return new WaitForSeconds(0.5f);
        shotFireBall();


        
        //yield return new WaitForSeconds(time);
        yield return null;

    }
    public IEnumerator Summon()
    {
        animator.SetTrigger("ATKOp");
        Instantiate(totem, new Vector3(78, 15, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(45, 24, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(65, 31, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(87, 32, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(92, 20, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(104, 28, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(103, 12, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(125, 31, 0), Quaternion.identity);
        Instantiate(totem, new Vector3(128, 17, 0), Quaternion.identity);
        yield return new WaitForSeconds(4.1f);
        currentRoutine = null;
    }
    
    // OnTriggerEnter2D                              
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFollowing = true;
        }
        
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
