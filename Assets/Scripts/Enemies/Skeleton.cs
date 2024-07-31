using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public override void Start()
    {
        // Gọi phương thức Start của lớp cha
        base.Start();
    }
    public void Update()
    {
        base.Update();  
    }
    public  void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D (collider);
    }
    
}
