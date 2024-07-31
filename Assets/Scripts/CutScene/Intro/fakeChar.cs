using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fakeChar : MonoBehaviour, AttackInterface
{
    private Vector2 getScale;

    public static float damage = 10f;

    public GameObject player;
    public float speed = 3f;
    public Animator animator;
    public Rigidbody2D rb;
    public bool isFollowing = false;
    public Coroutine currentRoutine, CoSkill;

    // to detect direction of attacking
    protected bool left = true, right = false;
    protected bool die = false;

    public float attackX;
    public float attackY;
    public float followX, followY;

    private orderOfSkills skill;

    public int numATK;
    private GameObject[] atkObj;

    enum orderOfSkills { atk1 = 0, atk2 = 1, atk3 = 2 }
    enum orderOfState { Pre = 0, CrushOnGround = 1 }
    // HEALTH
    public float health;
    public Slider slid;
    private bool canDash = false;

    //Phase 2
    public GameObject darkSword;
    public bool triggerDS, phase2;
    public Vector2 DashRange;
    

    public bool initLeft, initRight;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        getScale = transform.localScale;

        rb = GetComponent<Rigidbody2D>();

        attackX = 2f;
        attackY = 2f;
        followX = 5f;
        followY = 5f;

        atkObj = new GameObject[numATK];
        for (int i = 0; i < numATK; i++)
        {
            atkObj[i] = transform.Find("ATK" + i.ToString()).gameObject;
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
            if (currentRoutine == null)
            {
                currentRoutine = StartCoroutine(ManageAttack());
            }
            
        }
    }

    public void Direction()
    {
        if (transform.position.y < player.transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        if (transform.position.x <= player.transform.position.x)
        {
            left = true;
            right = false;
        }
        else
        {
            left = false;
            right = true;
        }

        if (left && !right)
        {
            transform.localScale = new Vector2(getScale.x, getScale.y);
        }
        if (right && !left)
        {
            transform.localScale = new Vector2(-getScale.x, getScale.y);
        }
    }


    // follow
    public IEnumerator follow()
    {

        Vector2 follow = (player.transform.position - transform.position).normalized;
        transform.position = new Vector2(transform.position.x + follow.x * speed * Time.deltaTime, transform.position.y + follow.y * speed * Time.deltaTime);
        animator.SetFloat("Speed", 1);
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
        yield return null;
    }
    private IEnumerator ManageAttack()
    {
        if (phase2)
        {
            if (CoSkill == null)
            {

                CoSkill = StartCoroutine(ActiveDarkSword(5f));
            }
        }
        float time = 0;
        float disX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float disY = Mathf.Abs(transform.position.y - player.transform.position.y);
        if (!triggerDS)
        {
            if (disX <= attackX && disY <= attackY)
            {
                yield return Attack(time);

                yield return State();// to dash
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (triggerDS)
        {
            if ((disX <= attackX + 10f && disY <= attackY + 10f)) {
                yield return SkillDarkSword();
                yield return new WaitForSeconds(0.5f);
            }
        }
        
       
        isFollowing = true;
        if (isFollowing)
        {

            yield return follow();
        }
        currentRoutine = null;

    }

    public IEnumerator Attack(float time)
    {

        isFollowing = false;
        
        
            skill = (orderOfSkills)Random.Range(0, numATK);


            string nameSkill = "";
            if (skill == orderOfSkills.atk1)
            {
                nameSkill = "atk1";
                time = 0.4f;
            }
            else if (skill == orderOfSkills.atk2)
            {
                nameSkill = "atk2";
                time = 1.05f;
            }
            else if (skill == orderOfSkills.atk3)
            {
                nameSkill = "atk3";
                time = 1.2f;
            }
            animator.SetTrigger(nameSkill);
        
        yield return new WaitForSeconds(time);
        canDash = true;

    }
    IEnumerator SkillDarkSword()
    {
        isFollowing = false;
        animator.SetFloat("Speed", 0);
        darkSword.SetActive(true);
        yield return new WaitForSeconds(1.683333f);
        darkSword.SetActive(false);
        triggerDS = false;
        Debug.Log("trigger false");
        CoSkill = null;
    }
    IEnumerator ActiveDarkSword(float time)
    {
        yield return new WaitForSeconds(time);
        triggerDS = true;
        Debug.Log("trigger true");
        
    }
    
    public IEnumerator State()
    {
        if (canDash)
        {
            Vector2 curDis = new Vector2(Mathf.Abs(player.transform.position.x - transform.position.x), Mathf.Abs(player.transform.position.y - transform.position.y));
            if (curDis.x <= DashRange.x && curDis.y <= DashRange.y)
            {
                Dash();
                yield return new WaitForSeconds(0.5f);
            }
            
        }
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(1f);
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
        GetComponent<FakeSound>().Hit();
        health -= take_dam;
        sliderOfHP(health);
        if (health <= 0)
        {
            die = true;

            animator.SetTrigger("die");
            //Audio.sound.StopBattle();
            //Audio.sound.NormalSound();
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
    public void Dash()
    {
        
        animator.SetTrigger("dash");
        inactive();
        rb.velocity = new Vector2(-transform.localScale.x * speed * 3, rb.velocity.y);
        StartCoroutine(StopDash(0.25f));

    }
    public IEnumerator StopDash(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = new Vector2(0, rb.velocity.y);
        canDash = false;
    }

}