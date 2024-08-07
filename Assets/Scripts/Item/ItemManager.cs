using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ItemManager itemManager;
    public TextMeshProUGUI num;
    public ItemSlot slot;
    public CanvasGroup canvasGr;


    public void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
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

    public void FadeForCutScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex == 6 || sceneIndex == 13 || sceneIndex == 15)
        {
            canvasGr.alpha = 0;
        }
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canvasGr.alpha = 1f;
    }
}
