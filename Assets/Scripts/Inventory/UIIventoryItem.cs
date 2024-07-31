using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIIventoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Image avtItem;
    public TextMeshProUGUI num;

    public Sprite HP;
    public Sprite Mana;
    public void Start()
    {
        GetComponent<RectTransform>().localScale = Vector3.one;
    }
    public void AssignIMG(string name)
    {
        if(name == "HP")
        {
            avtItem.sprite = HP;
            num.text = ItemManager.itemManager.numHP.ToString();
        }
        else if(name == "Mana")
        {
            avtItem.sprite = Mana;
            num.text = ItemManager.itemManager.numMana.ToString();
        }
    }
    public void Update()
    {
        if (avtItem.sprite == HP)
        {
            
            num.text = ItemManager.itemManager.numHP.ToString();
        }
        else if (avtItem.sprite == Mana)
        {
            
            num.text = ItemManager.itemManager.numMana.ToString();
        }
    }
}
