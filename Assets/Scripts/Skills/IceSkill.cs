using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkill : MonoBehaviour
{
    public GameObject atk;
    public void ActiveATK()
    {

        atk.SetActive(true); 
    }
    public void InactiveATK()
    {
        atk.SetActive(false);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
   
}
