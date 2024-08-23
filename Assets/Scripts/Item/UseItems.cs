using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItems : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float volumnOfHP;
    public float volumnOfMana;
    public GameObject HPHealEffect, ManaHealEffect;
    private ItemSlot slot;
    private GameObject itemManager;
    public HealthEffect healthEffect;
    public void Start()
    {
        itemManager = GameObject.Find("ItemManager");
        slot = itemManager.GetComponent<ItemSlot>();
    }
    public void UseHP()
    {
        if (ItemManager.itemManager.numHP > 0)
        {
            ItemManager.itemManager.UseHP();
            StartCoroutine(HPHeal());
        }
    }
    public void UseMana()
    {
        if(ItemManager.itemManager.numMana > 0)
        {
            ItemManager.itemManager.UseMana();
            StartCoroutine (Mana());
        }
    }
    IEnumerator HPHeal()
    {
        HPHealEffect.SetActive(true);
        healthEffect.hp += volumnOfHP;
        yield return new WaitForSeconds(2f);
        HPHealEffect.SetActive(false);
    }
    IEnumerator Mana()
    {
        ManaHealEffect.SetActive(true);
        GetComponent<UseSkill>().manaSlid.value += volumnOfMana;
        GetComponent<UseSkill>().canUse = true;
        yield return new WaitForSeconds(2f);
        ManaHealEffect.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (slot.curItem == "HP")
            {
                UseHP();
            }
            else
            {
                UseMana();
            }
        }
    }

}
