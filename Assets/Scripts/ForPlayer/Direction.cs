using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer player, itself;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Direct();
    }
    public void Direct()
    {
        if (player.gameObject.transform.position.y > transform.position.y)
        {
            itself.sortingOrder = 10;
        }
        else
        {
            itself.sortingOrder = 1;
        }
    }

    

}
