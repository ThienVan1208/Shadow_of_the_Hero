using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector2 distance;
    public GameObject key;
    public bool canOpen = true;
    public Animator anim;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        canOpen = true;
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            Open();
        }
    }
    public void Open()
    {
        Vector2 curDis = player.transform.position - transform.position;
        if(Mathf.Abs(curDis.x) <= distance.x && Mathf.Abs(curDis.y) <= distance.y)
        {
            key.SetActive(true);
        }
        else
        {
            key.SetActive(false);
        }

        if (key.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                key.SetActive(false);
                canOpen = false;
                anim.SetTrigger("open");
            }
        }
    }
    public void inactive()
    {
        gameObject.SetActive(false);
    }
    
}
