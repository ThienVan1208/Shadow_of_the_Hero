using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForATK : MonoBehaviour
{
    // Start is called before the first frame update
    public int numOfATK;
    public GameObject[] AtkObj;
    void Start()
    {
        for (int i = 0; i < numOfATK; i++)
        {
            AtkObj[i] = GameObject.Find("EnemyATK" + i.ToString());
        }
    }

    // Update is called once per frame
    public void active()
    {
        for (int i = 0; i < numOfATK; i++)
        {
            
        }
    }
}
