using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIIventoryPage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private UIIventoryItem itemPrefab;
    [SerializeField]
    private RectTransform contentPanel;

    List<UIIventoryItem> ListOfItem = new List<UIIventoryItem>();

    public TextMeshProUGUI atkInfo, hpInfo, manaInfo, skillInfo;
    ///public int initATK, initHP, initMana, initSkill;
    public int initLevel;

    public bool check;

    public void initStart()
    {
        initLevel = lvManager.levelInstance.levelIndex;
        checkLvUp();
        updateStrength();
    }

    public void InitializeItem(int numItem)
    {
        for (int i = 0; i < numItem; i++)
        {
            UIIventoryItem uiItem = Instantiate(itemPrefab);
            uiItem.transform.SetParent(contentPanel);
            ListOfItem.Add(uiItem);
        }
        //ListOfItem[0].AssignIMG("HP");
        //ListOfItem[1].AssignIMG("Mana");
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void updateCheckLv()
    {
        checkLvUp();
        if (check)
        {
            updateStrength();
            
        }
    }
    public void updateStrength()
    {
        atkInfo.text = "attack: " + GameManager.Instance.gm_atk.ToString();
        hpInfo.text = "hp: " + GameManager.Instance.gm_hp.ToString();
        manaInfo.text = "mana: " + GameManager.Instance.gm_mana.ToString();
        skillInfo.text = "skill damage: " + GameManager.Instance.gm_skill.ToString();
        check = false;
    }
    public void checkLvUp()
    {
        if(initLevel < lvManager.levelInstance.levelIndex)
        {
            initLevel = lvManager.levelInstance.levelIndex;

            GameManager.Instance.gm_atk++;
            GameManager.Instance.gm_hp++;
            GameManager.Instance.gm_skill++;
            GameManager.Instance.gm_mana++;

            check = true;
        }
    }
}
