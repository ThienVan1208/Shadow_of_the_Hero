using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spinTrap;
    public float r;  // Radius of the circular path
    public float speed;  // Speed of the rotation

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    public void Spin()
    {
        float angle = Time.time * speed;  
        float x = transform.position.x + r * Mathf.Cos(angle);  
        float y = transform.position.y + r * Mathf.Sin(angle);  
        spinTrap.transform.position = new Vector2(x, y);  
    }
}
