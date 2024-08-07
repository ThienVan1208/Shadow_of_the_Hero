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
    public string[] talkContent;
    public string nameChar;
    public float time;
    private Coroutine curCo;
    public GameObject key;
    public bool canTalk, haveInstruct, skipTalk;
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
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            skipTalk = true;
        }
        if (talkDia.text == talkContent[talkContent.Length - 1] && Input.GetKeyDown(KeyCode.Escape))
        {
            textContainer.GetComponent<Animator>().SetTrigger("close");
        }
    }
    public IEnumerator displayText()
    {
        textContainer.SetActive (true);
        skipTalk = false;
        name.text = nameChar;
        talkDia.text = "";
        for (int index = 0; index < talkContent.Length; index++)
        {
            for (int i = 0; i < talkContent[index].Length; i++)
            {
                if (skipTalk)
                {
                    talkDia.text = talkContent[index];
                    skipTalk = false;
                    break;
                }
                talkDia.text += talkContent[index][i];
                yield return new WaitForSeconds(time);
            }
            yield return new WaitForSeconds(2f);
            if (talkContent.Length != 1)
            {
                talkDia.text = "";
            }
        }

        yield return new WaitForSeconds(1f);
        textContainer.GetComponent<Animator>().SetTrigger("close");
        yield return new WaitForSeconds(1f);
        if (haveInstruct)
        {
           
            instruct.SetActive(true);
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
            textContainer.GetComponent<Animator>().SetTrigger("close");
            curCo = null;
        }
    }
    
}
