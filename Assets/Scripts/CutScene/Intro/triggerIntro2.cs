using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerIntro2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timeline;
    void Start()
    {
        timeline.SetActive(false);
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            timeline.SetActive(true); 
        }
    }
}
