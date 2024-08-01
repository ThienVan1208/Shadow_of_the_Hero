using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public void OnEnable()
    {
        RotatePlayer();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotatePlayer()
    {
        Vector2 follow = player.transform.position - transform.position;
        float radAngle = Mathf.Atan2(follow.y, follow.x);
        float degAngle = radAngle / Mathf.Deg2Rad;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + degAngle);
    }
}
