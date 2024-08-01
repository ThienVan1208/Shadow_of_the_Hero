using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class imper : MonoBehaviour, AttackInterface
{
    private Vector2 getScale;

    public GameObject player;
    public float speed = 3f;
    public Animator animator;
    public Rigidbody2D rb;
    public bool isFollowing = false;
    public Coroutine currentRoutine;

    // to detect direction of attacking
    protected bool left = false, right = true;
    protected bool die = false;
    public bool init_left, init_right;
    public Vector2 atkRange, followRange;
    // HEALTH
    public float health;
    public Slider slid;
    private bool canDash = false, inGame = true;
    // Start is called before the first frame update

    public Vector2 DashRange;

    public GameObject fireATK;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");



        animator = GetComponent<Animator>();

        
        getScale = transform.localScale;

        rb = GetComponent<Rigidbody2D>();

        slid.maxValue = health;
        slid.value = health;
        isFollowing = false;
        Direction();

    }

    public void InGame()
    {
        animator.SetFloat("speed", 0);
        
        if(init_left && !init_right)
        {
            transform.localScale = new Vector2(-getScale.x, getScale.y);
        }
        else
        {
            transform.localScale = new Vector2(getScale.x, getScale.y);
        }
    }
    public void Update()
    {



        if (!die)
        {
            Vector2 follow = (player.transform.position - transform.position);
            if (Mathf.Abs(follow.x) <= followRange.x && Mathf.Abs(follow.y) <= followRange.y)
            {
                isFollowing = true;
                inGame = false;
                
            }
            else
            {
                if(inGame)
                    InGame();
            }

            if(isFollowing)
            {
                Direction();
                if (currentRoutine == null)
                {
                    currentRoutine = StartCoroutine(ManageAttack());
                }
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
        rb.velocity = new Vector2( follow.x * speed , follow.y * speed);
        animator.SetFloat("speed", 1);
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
        if (disX <= atkRange.x && disY <= atkRange.y)
        {
            yield return Attack(time);

            //yield return State();
            yield return new WaitForSeconds(2f);
            isFollowing = true;
        }
        if (isFollowing)
        {

            yield return follow();
        }
        currentRoutine = null;

    }

    public IEnumerator Attack(float time)
    {
        isFollowing = false;
        Vector2 dis = player.transform.position - transform.position;
        if (Mathf.Abs(dis.x) <= atkRange.x && Mathf.Abs(dis.y) <= atkRange.y)
        {
            Vector2 follow = player.transform.position - transform.position;
            float radAngle = Mathf.Atan2(follow.y, follow.x);
            float degAngle = radAngle / Mathf.Deg2Rad;

            animator.SetTrigger("attack");
            Instantiate(fireATK, transform.position, Quaternion.Euler(0, 0, degAngle));
        }
        yield return null;

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
        animator.SetFloat("speed", 0);
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
        GetComponent<AudioSkel>().Hit();
        health -= take_dam;
        sliderOfHP(health);
        if (health <= 0)
        {
            die = true;
            GetComponent<AudioSkel>().Die();
            animator.SetTrigger("die");
        }
    }


    public void sliderOfHP(float hp)
    {
        slid.value = hp;
    }


    ///////////////////////////
   
    public void Dash()
    {

        animator.SetTrigger("dash");
        rb.velocity = new Vector2(-transform.localScale.x * speed * 3, rb.velocity.y);
        StartCoroutine(StopDash(0.25f));

    }
    public IEnumerator StopDash(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = new Vector2(0, rb.velocity.y);
        canDash = false;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}