using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 3f;
    public static float damage = 0.01f;
    public AudioSource shot;
    public AudioSource hit;
    public holdFireBall holder;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            GetComponent<Animator>().SetTrigger("hit");
        }
    }

    public void destroy()
    {
        gameObject.SetActive(false);
        if(holder != null)
            holder.count++;
    }
    public void Shot()
    {
        shot.Play();
        shot.loop = false;
    }
    public void Hit()
    {
        hit.Play();
        hit.loop = false;
    }
    public void destroyForFireEnemy()
    {

        Destroy(gameObject); 
    }
}
