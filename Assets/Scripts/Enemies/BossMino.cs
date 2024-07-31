using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossMino : MonoBehaviour, AttackInterface
{
    private Vector2 getScale;

    public static float damage = 0.7f;

    public GameObject player;
    public float speed = 3f;
    public Animator animator;
    public Rigidbody2D rb;
    public bool isFollowing = false;
    public Coroutine currentRoutine;

    // to detect direction of attacking
    protected bool left = true, right = false;
    protected bool die = false;

    public float attackX;
    public float attackY;
    public float followX, followY;

    private orderOfSkills skill;

    public int numATK;
    private GameObject[] atkObj;
    public GameObject smoke, ground;
    
    enum orderOfSkills { StraightSlash = 0, Slash = 1, SpinAttack = 2}
    enum orderOfState { Pre = 0, CrushOnGround = 1}
    // HEALTH
    public float health;
    public Slider slid;
    // Start is called before the first frame update

    public AudioMino mino;

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
        for(int i = 0; i < numATK; i++)
        {
            atkObj[i] = transform.Find("EnemyATK" + i.ToString()).gameObject;
        }

        slid.maxValue = health;
        slid.value = health;
        isFollowing = true;
        //currentRoutine = StartCoroutine(start());
        
    }

    IEnumerator start()
    {
        isFollowing = false;
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(5.3f);
        isFollowing = true;
        StopCoroutine(start());
        currentRoutine = null;
        GameManager.Instance.Boss = true;
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
            GetComponent<SpriteRenderer>().sortingOrder = 10;
        } 
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if(transform.position.x >= player.transform.position.x)
        {
            left = true;
            right = false;
        }
        else
        {
            left = false;
            right = true;
        }
        
        if(left && !right)
        {
            transform.localScale = new Vector2(getScale.x, getScale.y);
        }
        if(right && !left)
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
        float time = 0;
        float disX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float disY = Mathf.Abs(transform.position.y - player.transform.position.y);
        if (disX <= attackX && disY <= attackY)
        {
            yield return Attack( time);
            //yield return new WaitForSeconds(time);
            yield return State();
            yield return new WaitForSeconds(0.5f);
            isFollowing = true;
        }
        if (isFollowing)
        {
         
            yield return follow();
        }
        currentRoutine = null;

    }
    
    public IEnumerator Attack( float time)
    {
        
        isFollowing = false;
        skill = (orderOfSkills)Random.Range(0, numATK);
        string nameSkill = "";
        if (skill == orderOfSkills.Slash)
        {
            nameSkill = "Slash";
            time = 1f;
        }
        else if (skill == orderOfSkills.StraightSlash)
        {
            nameSkill = "StraightSlash";
            time = 0.3f;
        }
        else if (skill == orderOfSkills.SpinAttack)
        {
            nameSkill = "SpinAttack";
            time = 1.2f;
        }

        animator.SetTrigger(nameSkill);

        yield return new WaitForSeconds(time);
        
    }
    public IEnumerator State()
    {
        float time = 0;
        isFollowing = false;
        orderOfState state = (orderOfState)Random.Range(0, 2);
        if (state == orderOfState.Pre)
        {
            time = 1f;
            animator.SetTrigger("Pre");
            
            transform.position = new Vector2(transform.position.x, transform.position.y);

            yield return new WaitForSeconds(time);
        }
        else if (state == orderOfState.CrushOnGround)
        {
            
            time = 1.2f;
            animator.SetTrigger("CrushOnGround");
         
            transform.position = new Vector2(transform.position.x, transform.position.y);
            yield return new WaitForSeconds(time);

        }
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



    public void takeDAM( float take_dam)
    {
        if (die) return;
        mino.Hit();
        health -= take_dam;
        sliderOfHP(health);
        if (health <= 0)
        {
            die = true;
            
            animator.SetTrigger("t_LDie");
            Audio.sound.StopBattle();
            Audio.sound.NormalSound();
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
            if((orderOfSkills)i == skill)
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
        for(int i = 0;i < numATK; i++)
        {
            atkObj[i].SetActive(false);
        }
    }
    
    public void SmokeEffect()
    {
        smoke.SetActive(true);
    }
    public void Ground()
    {
        ground.SetActive(true);
    }

}