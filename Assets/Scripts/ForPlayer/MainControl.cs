using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MainControl : MonoBehaviour
{
    // Start is called before the first frame update
    //public static MainControl instance;

    private Rigidbody2D rigid;
    private Animator animator;

    public float speedRun = 10f;

    public bool  is_death;
    
    public static float hp = 10f;
    public static float damage = 0.5f;

    public static bool getATK1, getATK2, getATK3;

    public static bool isAttacking = false;

    public Slider slidHP;

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
 
    void Start()
    {
        hp = GameManager.Instance.gm_hp;
        damage = GameManager.Instance.gm_atk / 5;
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        getScale.x = transform.localScale.x;
        getScale.y = transform.localScale.y;
       
        is_death = false;
        slidHP.maxValue = hp;
        slidHP.value = hp;
        getATK1 = false;
        getATK2 = false;
        getATK3 = false;
        sys.Stop();
    }

    
    private void Update()
    {
        Debug.Log("value hp:" + slidHP.value);
        if (!is_death)
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
            sliderOfHP(hp);
    }
        
}
   public void enhanceStreght()
    {
        if(damage != GameManager.Instance.gm_atk)
            damage = (float)increaseInfo.initATK / 5;

        if(slidHP.maxValue != GameManager.Instance.gm_hp)
            slidHP.maxValue = increaseInfo.initHP;
        
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
        //transform.Translate(movement * speedRun * Time.deltaTime);
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
                    //Audio.sound.swordSlash();
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
        //rigid.AddForce(new Vector2(transform.localScale.x * dashSpeed, rigid.velocity.y), ForceMode2D.Impulse);
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
        hp -= take_damage;
        GetComponent<SoundForMain>().Hit();
        sliderOfHP(hp);
        if (hp <= 0)
        {
            /////////////////////////////////////////////////////////////
            if (!introUse)
            {
                if (!dieOnce)
                {
                    animator.SetTrigger("Die");
                    dieOnce = true;
                }
                is_death = true;
            }
            else
            {
                TimeLineAfterDie();
            }
            
        }
    }
    public void sliderOfHP(float val)
    {
        slidHP.value = val;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyATK"))
        {
            takeDMG(Enemy.damage);
            takeDMG(BossMino.damage);
            takeDMG(BossDae.damage);
            takeDMG(fakeChar.damage);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) 
        {
            rigid.velocity = Vector2.zero;
        }
    }
    void HealthUI()
    {
        if (slidHP != null)
        {
            slidHP.maxValue = hp;
            slidHP.value = hp;
        }
    }
    public void over()
    {
        if(!introUse)
        GameManager.Instance.gameOver();
    }

    void OnEnable()
    {
        HealthUI(); 
    }

    public void TimeLineAfterDie()
    {
        StartCoroutine(SceneTransit.transitScene.Transit());
        animator.SetTrigger("Die");
    }
}
