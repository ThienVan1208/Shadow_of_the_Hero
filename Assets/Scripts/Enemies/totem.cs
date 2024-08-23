using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totem : Enemy
{
    // Start is called before the first frame update
    public GameObject fireATK;
    private bool activeDodge;
    public GameObject explosion, fireThunderShoot;
    public bool getEplosion; //{  get; private set; }
   
    void Start()
    {
        anim.SetTrigger("Start");
        base.Start();
        isATK = false;
        getEplosion = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(!healthEffect.die)
        {
            base.InitDirect();
            base.DirectTowardPlayer();
            Vector2 dis = player.transform.position - transform.position;
            if(Mathf.Abs(dis.x) <= atkRange.x && Mathf.Abs(dis.y) <= atkRange.y)
            {
                if(currCo == null && !isATK)
                {
                    currCo = StartCoroutine(Attack());
                }
            }
            if(getEplosion)
            {
                getEplosion = false;
                StopAllCoroutines();
                anim.SetTrigger("die");
                StartCoroutine(GetExplosion());
            }
        } 
    }

    public override IEnumerator Attack()
    {
        isATK = true;
        Vector2 dis = player.transform.position - transform.position;
        if (Mathf.Abs(dis.x) <= atkRange.x && Mathf.Abs(dis.y) <= atkRange.y)
        {
            float radAngle = Mathf.Atan2(dis.y, dis.x);
            float degAngle = radAngle / Mathf.Deg2Rad;

            anim.SetTrigger("attack");
            Instantiate(fireATK, transform.position, Quaternion.Euler(0, 0, degAngle));
        }
        rb.velocity = Vector2.zero;
        
        yield return new WaitForSeconds(1f);
        isATK = false;
        currCo = null;
        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }


    public IEnumerator GetExplosion()
    {
        Instantiate(explosion,transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        
        //yield return new WaitForSeconds(0.533f);
        Vector2 dis = player.transform.position - transform.position;
        if (Mathf.Abs(dis.x) <= atkRange.x && Mathf.Abs(dis.y) <= atkRange.y)
        {
            Vector2 follow = player.transform.position - transform.position;
            float radAngle = Mathf.Atan2(follow.y, follow.x);
            float degAngle = radAngle / Mathf.Deg2Rad;
            Instantiate(fireThunderShoot, transform.position, Quaternion.Euler(0, 0, degAngle));
        }
    }
    public IEnumerator TotemDie()
    {
        
        yield return new WaitForSeconds(1.33f);
        gameObject.SetActive(false);
    }
    public void DieOfTotem()
    {

        isATK = false;
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
        BossDae.countTotem++;
    }
    public void OnEnable()
    {
        Debug.Log("enable");
        healthEffect.hp = healthEffect.slidHP.maxValue;
        healthEffect.slidHP.value = healthEffect.slidHP.maxValue;
        healthEffect.die = false;
        currCo = null;
    }
}

    


