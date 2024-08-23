using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Enemy
{
    // Start is called before the first frame update
    public GameObject fireATK;
    private bool activeDodge;
    void Start()
    {
        base.Start();
        isATK = false;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (activeDodge)
        {
            InAttacking();
        }
    }
    
    public override IEnumerator Attack()
    {
        
        Vector2 dis = player.transform.position - transform.position;
        if (Mathf.Abs(dis.x) <= atkRange.x && Mathf.Abs(dis.y) <= atkRange.y)
        {
            float radAngle = Mathf.Atan2(dis.y, dis.x);
            float degAngle = radAngle / Mathf.Deg2Rad;

            anim.SetTrigger("attack");
            Instantiate(fireATK, transform.position, Quaternion.Euler(0, 0, degAngle));
        }
        rb.velocity = Vector2.zero;
        activeDodge = true;
        yield return new WaitForSeconds(2f);
        currCo = null;
        activeDodge = false;
        
    }
    public void InAttacking()
    {
        Vector2 dis = player.transform.position - transform.position;
        if (Mathf.Abs(dis.x) <= 6f && Mathf.Abs(dis.y) <= 6f)
        {
            rb.velocity = -dis.normalized * speed;
        }
        else if (Mathf.Abs(dis.x) <= 7f && Mathf.Abs(dis.y) <= 7f)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = dis.normalized * speed;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D (collision);
    }
}
