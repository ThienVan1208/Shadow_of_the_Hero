using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Talk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textContainer, instruct;
    public TextMeshProUGUI name, talkDia;
    [TextArea(3,10)]
    public string talkContent;
    public string nameChar;
    public float time;
    private Coroutine curCo;
    public GameObject key;
    public bool canTalk, haveInstruct;
    void Start()
    {
        textContainer.SetActive(false);
        if(haveInstruct)
        {
            instruct = GetComponent<ReceiveInstruc>().paper;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canTalk)
        {
            if (key.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                if (curCo == null)
                {
                    curCo = StartCoroutine(displayText());
                }
            }
        }
    }
    public IEnumerator displayText()
    {
        textContainer.SetActive (true);
        bool skipTalk = false;
        name.text = nameChar;
        talkDia.text = "";
        for (int i = 0; i < talkContent.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                skipTalk = true;
                break;
            }
            talkDia.text += talkContent[i];
            yield return new WaitForSeconds(time);
        }
        if(haveInstruct)
        {
            yield return new WaitForSeconds(3f);
            instruct.SetActive(true);
        }
        if(skipTalk)
        {
            talkDia.text = talkContent;
            skipTalk = false;
        }
        curCo = null;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            key.SetActive (true);
            canTalk = true;
            
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //StopCoroutine(displayText());
            key.SetActive(false);
            canTalk = false;
            textContainer.SetActive(false);
            curCo = null;
        }
    }
}
