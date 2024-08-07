using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameItem;
    public bool canCollect = false;
    public GameObject key;
    public GameObject collectAudio;
    public void Start()
    {
        key.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            key.SetActive(true);
            canCollect = true;
        }
    }
    public void Update()
    {
        CollectItem();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            key.SetActive(false);
            canCollect = false;
        }
    }
    public void CollectItem()
    {
        if(canCollect && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(collectAudio);
            CollectItem(nameItem);
            afterCollect(nameItem);
        }
    }
    public void afterCollect(string nameItem)
    {
        Debug.Log(nameItem + "is collected");
        Destroy(gameObject);
    }

    public void CollectItem(string name)
    {
        if (name == "HP")
        {
            ItemManager.itemManager.CollectHP();
        }
        else if(name == "Mana")
        {
            ItemManager.itemManager.CollectMana();
        }
    }
}
