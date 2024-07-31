using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;

    public float speed = 10f;

    public bool D, R, U, L, death;

    public float HP;
    public Slider sliHP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        D = true;
        L = false;
        R = false;
        U = false;
        death = false;
        sliHP.maxValue = HP;
        sliHP.value = HP;
    }

    // Update is called once per frame
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("b_D", true);
            anim.SetBool("b_L", false);
            anim.SetBool("b_R", false);
            anim.SetBool("b_U", false);

            D = true;
            L = false;
            R = false;
            U = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("b_D", false);
            anim.SetBool("b_L", false);
            anim.SetBool("b_R", false);
            anim.SetBool("b_U", true);

            D = false;
            L = false;
            R = false;
            U = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("b_D", false);
            anim.SetBool("b_L", true);
            anim.SetBool("b_R", false);
            anim.SetBool("b_U", false);

            D = false;
            L = true;
            R = false;
            U = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("b_D", false);
            anim.SetBool("b_L", false);
            anim.SetBool("b_R", true);
            anim.SetBool("b_U", false);

            D = false;
            L = false;
            R = true;
            U = false;
        }
        if (!death)
        {
            Movement();
            Attack();
        }
    }
    void Movement()
    {
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMove, verticalMove);
        transform.Translate( movement * speed * Time.deltaTime);

        anim.SetFloat("Hori", horizontalMove);
        anim.SetFloat("Verti", verticalMove);
        anim.SetFloat("Speed", movement.sqrMagnitude);

    }
    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(D)
            {
                anim.SetTrigger("t_D");
            }
            if (L)
            {
                anim.SetTrigger("t_L");
            }
            if (R)
            {
                anim.SetTrigger("t_R");
            }
            if (U)
            {
                anim.SetTrigger("t_U");
            }
        }
    }
    public void takeDAM()
    {
        HP -= 0.5f;
        sliderOfHealth(HP);
        if(HP <= 0)
        {
            death = true;
            if( !R && (L || D || U))
            {
                anim.SetTrigger("t_LDie");
            }
            else if(!L && (R || D || U))
            {
                anim.SetTrigger("t_RDie");
            }
        }
    }
    public void sliderOfHealth(float val)
    {
        sliHP.value = val;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyATK"))
        {
            takeDAM();
        }
    }
    void UpdateHealthUI()
    {
        if (sliHP != null)
        {
            sliHP.maxValue = HP;
            sliHP.value = HP;
        }
    }

    void OnEnable()
    {
        UpdateHealthUI(); // Ensure the health UI is updated when the script is enabled
    }
}
