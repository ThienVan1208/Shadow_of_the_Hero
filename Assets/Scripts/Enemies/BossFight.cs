using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Audio.sound.StopNormal();
            Audio.sound.BattleSound();
            boss.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
