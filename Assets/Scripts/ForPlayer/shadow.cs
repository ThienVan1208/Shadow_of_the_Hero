using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector2 newPos;
    void Start()
    {
        newPos.y = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, newPos.y);
    }
}
