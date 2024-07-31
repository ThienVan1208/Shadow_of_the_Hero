using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject atk, sound, light;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inactive()
    {
        gameObject.SetActive(false);
    }
    public void activeATK()
    {
        atk.SetActive(true);
    }
    public void inactiveATK()
    {
        atk.SetActive(false);
    }
    public IEnumerator OnSound()
    {
        Instantiate(sound, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        
    }
    public void PlaySound()
    {
        StartCoroutine(OnSound());  
    }
    public void Light()
    {
        light.SetActive(true);
    }
    public void inactiveLight()
    {

        light.SetActive(false); 
    }
}
