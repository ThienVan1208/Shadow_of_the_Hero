using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MainControl : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator animator;

    public float speedRun = 10f;

    public static float damage = 0.5f;

    public static bool getATK1, getATK2, getATK3;

    public static bool isAttacking = false;

    public bool dieOnce = false;
    public Vector2 getScale;

    public float dashSpeed = 1f;
    private bool isDashing = false;
    public float dashTime = 0.1f;

    public ParticleSystem sys;

    public bool introUse;

    private Vector2 movement;
    public bool ATKForUI = false;

    public UIIventoryPage increaseInfo;

    public HealthEffect healthEffect;
 
    void Start()
    {
        damage = GameManager.Instance.gm_atk / 5;
       
        getScale.x = transform.localScale.x;
        getScale.y = transform.localScale.y;

        healthEffect.hp = GameManager.Instance.gm_hp;
        healthEffect.InitSlidHP();

        getATK1 = false;
        getATK2 = false;
        getATK3 = false;
        sys.Stop();
    }

    
    private void Update()
    {
        
        if (!healthEffect.die)
        {
            if (!ATKForUI)
            {
                attack();
            }

            if (!isAttacking)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.localScale = new Vector2(-getScale.x, getScale.y);
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.localScale = getScale;
                }
                if (!isDashing)
                {
                    move();
                    if (Input.GetKeyDown(KeyCode.V))
                    {
                        Dash();
                    }
                }
            }

            enhanceStreght();
            healthEffect.SliderOfHP(healthEffect.hp);// update hp every frame
            healthEffect.LimitHP();
        }
        
    }
   public void enhanceStreght()
    {
        if(damage != GameManager.Instance.gm_atk)
            damage = (float)GameManager.Instance.gm_atk / 5;

        if (healthEffect.slidHP.maxValue != GameManager.Instance.gm_hp)
        {
            healthEffect.EnhanceHP(GameManager.Instance.gm_hp);
        }
        
    }
    void move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector2(-getScale.x, getScale.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = getScale;
        }

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalMove, verticalMove);

        rigid.velocity = movement * speedRun;
        
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    void attack()
    {
        if (!UseSkill.isSkill)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (!getATK1)
                {
                    getATK1 = true;
                   
                    animator.SetTrigger("ATK1");
                }

            }
        }
    }

    public void Dash()
    {
        sys.Play();
        isDashing = true;
        
        animator.SetTrigger("FlipDash");
        rigid.velocity = new Vector2(transform.localScale.x * dashSpeed + rigid.velocity.x , rigid.velocity.y);
        StartCoroutine(StopDash());
    }
    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashTime);
        rigid.velocity = new Vector2(0, rigid.velocity.y);
        isDashing = false;
        getATK1 = false;
        getATK2 = false;
        getATK3 = false;
        isAttacking = false;
        sys.Stop();
    }
    public void takeDMG(float take_damage)
    {
        healthEffect.takeDMG(take_damage);
        GetComponent<SoundForMain>().Hit();
        
        if (healthEffect.hp <= 0)
        {
            if (!introUse)
            {
                if (!dieOnce)
                {
                    animator.SetTrigger("Die");
                    dieOnce = true;
                }
                healthEffect.die = true;
            }
            else
            {
                TimeLineAfterDie();
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyATK"))
        {
            
            takeDMG(BossMino.damage);
            takeDMG(BossDae.damage);
            takeDMG(fakeChar.damage);
        }
        
    }
    
    
    public void over()
    {
        if (!introUse)
        {
            GameManager.Instance.gameOver();
        }
    }

    void OnEnable()
    {
        healthEffect.InitSlidHP();
    }

    public void TimeLineAfterDie()
    {
        StartCoroutine(SceneTransit.transitScene.Transit());
        animator.SetTrigger("Die");
    }
}
