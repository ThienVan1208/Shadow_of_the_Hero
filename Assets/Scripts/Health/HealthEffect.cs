using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public bool die;
    public Slider slidHP;
    void Start()
    {
        die = false;
        
    }

    // Update is called once per frame
    
    public void InitSlidHP()
    {
        slidHP.maxValue = hp;
        slidHP.value = hp;
    }

    public void SliderOfHP(float _hp)
    {
        slidHP.value = _hp;
    }
    public void takeDMG(float dam)
    {
        hp -= dam;
        SliderOfHP(hp);
    }
    public void LimitHP()
    {
        if(hp > GameManager.Instance.gm_hp)
        {
            hp = GameManager.Instance.gm_hp;
        } 
        if(hp < 0)
        {
            hp = 0;
        }
    }
    public void EnhanceHP(float enhance_hp)
    {
        hp = enhance_hp;
        slidHP.maxValue = hp;
        slidHP.value += enhance_hp;
    }
}
