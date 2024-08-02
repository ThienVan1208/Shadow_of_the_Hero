using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ItemManager itemManager;
    public TextMeshProUGUI num;
    public ItemSlot slot;
    public void CheckNum()
    {
        if(slot.curItem == "HP")
        {
            num.text = "x" + numHP.ToString();
        }
        else if(slot.curItem == "Mana") 
        { 
            num.text = "x" + numMana.ToString();
        }
    }
    public void Update()
    {
        CheckNum();
    }
    public void Awake()
    {
        if(itemManager == null)
        {
            itemManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        Destroy(gameObject);
    }
    public int numHP = 1, numMana = 1;
    public void CollectHP()
    {
        numHP++;
    }
    public void CollectMana() 
    { 
        numMana++; 
    }
    public void UseHP()
    {
        numHP--;
    }
    public void UseMana()
    {
        numMana--;
    }
}
