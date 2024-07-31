using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_push : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 dir;
    public MainControl main;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (main.transform.localScale.x == main.getScale.x)
                {
                    dir = new Vector2(1f, 0);
                }
                if (main.transform.localScale.x == -main.getScale.x)
                {
                    dir = new Vector2(-1f, 0);
                }
                enemy.rb.velocity = new Vector2( dir.x,  dir.y);
            }
        
        }
        
    }
    

}
