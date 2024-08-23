using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] skill;
    public static bool isSkill;
    public static float manaMax = 10f;
    public bool canUse;

    public float mana_spend;
    public Slider manaSlid;

    private SkillSlot skillIssue;
    private GameObject itemManager;
    public Animator animator;

    //public UIIventoryPage invent;
    void Start()
    {
        isSkill = false;
        manaSlid.maxValue = manaMax;
        manaSlid.value = manaMax;
        canUse = true;
        itemManager = GameObject.Find("ItemManager");
        skillIssue = itemManager.GetComponent<SkillSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canUse)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSkill = true;
                useSkill();
            }
        }
        updateManaMax();
        

    }
    public void updateManaMax()
    {
        bool checkManaMax = false;
        if(manaSlid.value == manaMax)
        {
            checkManaMax = true;
        }
        else
        {
            checkManaMax = false;
        }
        manaMax = GameManager.Instance.gm_mana;
        manaSlid.maxValue = manaMax;
        if(checkManaMax)
        {
            manaSlid.value = manaMax;
            checkManaMax = false;
        }
    }
    public void useSkill()
    {
        animator.SetTrigger("skill");
        manaSpend(mana_spend);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //if (Input.GetMouseButtonDown(0))
        {
            if(skillIssue.curSkill == "fire explosion")
                Instantiate(skill[0], mousePos, Quaternion.identity);
            else
            {
                Instantiate(skill[1], mousePos, Quaternion.identity);
            }
            isSkill = false ;
        }
    }
    public void manaSpend(float spend)
    {
        manaSlid.value -= spend;
        if(manaSlid.value <= 0)
        {
            canUse = false;
        }
    }
    
}
