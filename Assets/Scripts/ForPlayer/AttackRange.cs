using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject L, D, R, U;

    //public Skeleton enemy;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector3 moveDirection = Vector3.zero;
                if (L.activeSelf)
                {
                    moveDirection = Vector3.left;
                    Debug.Log("attacked");
                }
                else if (D.activeSelf)
                {
                    moveDirection = Vector3.down;
                    Debug.Log("attacked");
                }
                else if (R.activeSelf)
                {
                    moveDirection = Vector3.right;
                    Debug.Log("attacked");
                }
                else if (U.activeSelf)
                {
                    moveDirection = Vector3.up;
                    Debug.Log("attacked");
                }

                if (moveDirection != Vector3.zero)
                {
                    float moveDistance = 1.0f; // Khoảng cách lùi lại
                    enemy.transform.position += moveDirection * moveDistance;
                }
            }
        }
    }
}
