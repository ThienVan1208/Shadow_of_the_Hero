using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public bool testing = false;
    public float time = 0f;
    public void FixedUpdate()
    {
        if(testing)
        {
            time += Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("key down");
        }
        if(Input.GetKey(KeyCode.E))
        {
            Debug.Log("key");
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("key up");
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Exp")
        {
            Debug.Log("in");
            if(Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("press");
            }
        }
    }public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Exp")
        {
            Debug.Log("out");
            if(Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("press");
            }
        }
    }
    public void Test()
    {
        testing = true;
    }
    public void stopTest()
    {
        testing = false;
        Debug.Log(time);
    }
}
