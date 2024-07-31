using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public bool Boss = true;
    public int gm_hp = 5, gm_atk = 1, gm_mana = 5, gm_skill = 5;

    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void gameOver()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }

    public void dungeon()
    {
        SceneManager.LoadScene("Dungeon");
    }
    public void StartGame()
    {
        StartCoroutine(SceneTransit.transitScene.Transit());
    }
    public void inCave()
    {
        SceneTransit.transitScene.changeSceneWithIndex(3);
    }
    public void outCave() 
    {
        SceneTransit.transitScene.changeSceneWithIndex(2);
    }
    
}
