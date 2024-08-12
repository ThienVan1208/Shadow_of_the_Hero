using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totemHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] totem;
    public GameObject Dae;
    private void Start()
    {
        Dae = GameObject.Find("Daemon");
        for (int i = 0; i < totem.Length; i++)
        {
            totem[i].SetActive(true);
        }
    }
    private void Update()
    {
        if(BossDae.countTotem == 8)
        {
            resetTotem();
        }
    }
    public void resetTotem()
    {
     
        
        Destroy(gameObject);
    }
}
