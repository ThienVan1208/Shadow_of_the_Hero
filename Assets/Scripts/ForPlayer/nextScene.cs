using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            StartCoroutine(SceneTransit.transitScene.Transit());
        }
    }
    public void ChangeToNextScene()
    {
        StartCoroutine(SceneTransit.transitScene.Transit());
    }
    public void End()
    {
        GameManager.Instance.Reset();
        lvManager.levelInstance.Reset();
        ItemManager.itemManager.Reset();
        StartCoroutine (SceneTransit.transitScene.TransitIndex(0));
    }
   
}
