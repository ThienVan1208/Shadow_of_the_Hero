using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    // Start is called before the first frame update
    public float getExp;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            lvManager.levelInstance.updateLevel(getExp);
            Destroy(gameObject);
        }
    }
}
