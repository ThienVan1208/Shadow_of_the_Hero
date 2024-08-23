using System.Collections;

using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public bool initMove;
    protected Vector2 getScale;
    public bool right;

    public Rigidbody2D rb;
    public Animator anim;

    
    public Vector2 followRange;
    public float speed;

    protected Coroutine currCo;

    protected GameObject player;

    public GameObject atk;
    public Vector2 atkRange;
    protected bool isATK;

    public HealthEffect healthEffect;

    public void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        getScale = transform.localScale;
        healthEffect.InitSlidHP();
    }
    protected void Update()
    {
        if (!healthEffect.die)
        {
            ControlSpeed();
            InitDirect();
            if (initMove)
            {
                InitMove();
            }

            Vector2 dis = player.transform.position - transform.position;
            if ((Mathf.Abs(dis.x) <= followRange.x) && (Mathf.Abs(dis.y) <= followRange.y))
            {
                if (initMove)
                {
                    StopAllCoroutines();
                    currCo = null;
                }
                initMove = false;
                if (currCo == null)
                {
                    StateManager();
                }
                DirectTowardPlayer();
            }
            else if((Mathf.Abs(dis.x) <= 12f) && (Mathf.Abs(dis.y) <= 12f))
            {
                initMove = true;
            }
        }
    }
    /// <summary>
    /// INITIALIZE STATE
    /// </summary>
    public void InitDirect()
    {
        if(!right)
        {
            gameObject.transform.localScale = new Vector2(-getScale.x, getScale.y);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(getScale.x, getScale.y);
        }
    }
    
    public void InitMove()
    {
        if(currCo == null)
        {
            if(!right)
            {
                currCo = StartCoroutine(InitLeftMove(3f));
            }
            else
            {
                currCo = StartCoroutine(InitRightMove(3f));
            }
        }
    }

    IEnumerator InitLeftMove(float time)
    {
        rb.velocity = Vector2.left * speed;
        
        yield return new WaitForSeconds(time);

        rb.velocity = Vector2.zero;
        
        yield return new WaitForSeconds(2f);

        right = true;
        currCo = null;
    }
    IEnumerator InitRightMove(float time)
    {
        rb.velocity = Vector2.right * speed;
        
        yield return new WaitForSeconds(time);

        rb.velocity = Vector2.zero;
        
        yield return new WaitForSeconds(2f);

        right = false;
        currCo = null;
    }

    
    // FOLLOW
    public virtual IEnumerator Follow()
    {
        Vector2 moving = (player.transform.position - transform.position).normalized;
        rb.velocity = moving * speed;

        yield return null;
        currCo = null;
    }

    public void DirectTowardPlayer()
    {
        if (!isATK)
        {
            Vector2 direct = player.transform.position - transform.position;
            if (direct.x > 0)
            {
                right = true;
            }
            else
            {
                right = false;
            }
        }
    }

    public void ActiveAtk()
    {
        atk.SetActive(true);
    }
    public void InactiveAtk()
    {
        atk.SetActive(false);
    }


    public void StateManager()
    {
        
        {
            Vector2 distance = player.transform.position - transform.position;
            if (Mathf.Abs(distance.x) <= atkRange.x && Mathf.Abs(distance.y) <= atkRange.y)
            {
                currCo = StartCoroutine(Attack());
            }
            else
            {
                currCo = StartCoroutine( Follow());
            }
        }
    }
    public virtual IEnumerator Attack()
    {
        isATK = true;
        anim.SetTrigger("attack");
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(0.2f);
        isATK = false;
        yield return new WaitForSeconds(1.8f);
        currCo = null;
    }
    public void ControlSpeed()
    {
        anim.SetFloat("speed", rb.velocity.magnitude);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("AttackRange"))
        {
            takeDMG(MainControl.damage);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("skill"))
        {
            takeDMG(fire.damage);
        }
    }
    public void EnemyDie()
    {
        isATK = false;
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
    public void takeDMG(float take_damge)
    {
        if (healthEffect.die) return;
        GetComponent<AudioSkel>().Hit();
        healthEffect.takeDMG(take_damge);
        if (healthEffect.hp <= 0)
        {
            healthEffect.die = true;
            GetComponent<AudioSkel>().Die();
            anim.SetTrigger("die");
          
        }
    }
}