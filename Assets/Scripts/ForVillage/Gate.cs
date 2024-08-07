using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public AudioSource openAudi;
    void Start()
    {
         
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            {
                Debug.Log("open");
                anim.SetTrigger("open");
                openAudi.Play();
                openAudi.loop = false;
                StartCoroutine(SceneTransit.transitScene.Transit());
            }
        }
    }

}
