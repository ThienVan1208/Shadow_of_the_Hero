using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveInstruc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject key;
    public GameObject paper;
    public bool isKey, isPaper, haveTalk;
    public void Start()
    {
        key.SetActive(false);
        paper.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!haveTalk)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isKey = true;
                key.SetActive(true);
            }
        }
    }
   
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isKey = false;
            key.SetActive(false);
        }
    }
    public void Update()
    {
        if (!haveTalk)
        {
            ActiveKey();
            ActivePaper();
        }
    }
    public void ActiveKey()
    {
        if (isKey )
        {
            isPaper = true;
            
        }
        else if(!isKey)
        {
            isPaper = false;
        }
    }
    public void ActivePaper()
    {
        if(isPaper && Input.GetKeyDown(KeyCode.E))
        {
            paper.SetActive(true);
        }
        else if ( Input.GetKeyDown(KeyCode.Escape))
        {
            paper.GetComponent<Animator>().SetTrigger("close");
            isPaper = false;
        }
    }


}
