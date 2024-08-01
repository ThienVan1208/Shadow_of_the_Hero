using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class lvManager : MonoBehaviour
{
    public static lvManager levelInstance;
    public Slider lvSlid;
    public float curExpLimit = 50f;
    public float curExpVal = 0f;
    public TextMeshProUGUI levelTxt;
    public int levelIndex = 0;
    public GameObject player;
    public GameObject lvSound;
    public void Awake()
    {
        if (levelInstance == null)
        {
            levelInstance = this;
            DontDestroyOnLoad(levelInstance);
        }
        else
        {
            Destroy(levelInstance);
        }
    }
    public void Start()
    {
        if(player == null)
        {
            GetPlayer();
        }
        InitLvRange();
    }
    public void Update()
    {
        if (player == null)
        {
            GetPlayer();
            
        }
        DisplayLvText();
        InitLvRange();
    }
    public void GetPlayer()
    {
        player = GameObject.FindWithTag("Player");
        GameObject canvas = player.transform.Find("Canvas").gameObject;
        if (canvas != null)
        {
            GameObject BarInfo = canvas.transform.Find("BarInfor").gameObject;
            lvSlid = BarInfo.transform.Find("Level").gameObject.GetComponent<Slider>();
            levelTxt = lvSlid.gameObject.transform.Find("LvText").GetComponent<TextMeshProUGUI>();
        }
    }
    public void InitLvRange()
    {
        if (lvSlid != null)
        {
            lvSlid.maxValue = curExpLimit;
            lvSlid.value = curExpVal;
        }
    }
    public void ChangeLvLimit()
    {
        curExpLimit *= 1.5f;
    }
    public void updateLevel(float expReceived)
    {
        curExpVal += expReceived;
        InitLvRange();
        DisplayLvText();

        //Level Up
        if(lvSlid.value >= curExpLimit)
        {
            LevelUp();
            float res = lvSlid.value  - curExpLimit;
            lvSlid.value = res;
            ChangeLvLimit();
            player.transform.Find("LvEffect").gameObject.SetActive(true);
            levelIndex++;
        }
    }
    public void DisplayLvText()
    {
        levelTxt.text = "lv." + levelIndex.ToString();
    }
    public void LevelUp()
    {
        Instantiate(lvSound, transform.position, Quaternion.identity);
    }
}
