using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordark : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject darkSpell,brokenGround;
    public AudioSource slash;
    //public GameObject fake;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void summonDarkSpell()
    {
        Instantiate(darkSpell, transform.position, Quaternion.Euler(0, 0, transform.localScale.z + 134.46f));
        
    }
    public void active()
    {
        darkSpell.SetActive(true);
    }
    public void breakGound()
    {
        brokenGround.SetActive(true);
    }
    public void Slash()
    {
        slash.Play();
        slash.loop = false;
    }
    
}
