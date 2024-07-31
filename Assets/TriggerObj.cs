using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public float time;
    public bool inactiveAfterTrigger;
    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator triggerObj()
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(true);
        if(inactiveAfterTrigger )
        {
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(triggerObj());
        }
    }
}
