using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totemHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] totemEnemy;
    //public GameObject Dae;
    private void OnEnable()
    {
        //Dae = GameObject.Find("Daemon");
        for (int i = 0; i < totemEnemy.Length; i++)
        {
            totemEnemy[i].SetActive(true);
        }
    }
    private void Update()
    {
        if(BossDae.countTotem == 8)
        {
            gameObject.SetActive(false);
        }
    }
    public void Explosion()
    {
        for(int i = 0;i < totemEnemy.Length;i++)
        {
            totem get_explore = totemEnemy[i].GetComponent<totem>();
            get_explore.getEplosion = true;
        }
       
    }
}
