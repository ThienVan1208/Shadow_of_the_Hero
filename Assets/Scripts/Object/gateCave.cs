using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateCave : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             GameManager.Instance.inCave();
        }
        
    }
}
