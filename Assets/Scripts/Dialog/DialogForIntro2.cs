using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogForIntro2 : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI name, talkDia;
    [TextArea(3, 10)]
    public string[] talkContent;
    public string nameChar;
    
    
    
    void Start()
    {
        StartCoroutine(MainTalk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator MainTalk()
    {
        name.text = nameChar;
        talkDia.text = "";
        for(int i = 0; i < talkContent[0].Length; i++)
        {
            talkDia.text += talkContent[0][i];
            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(2.5f);
        talkDia.text = "";
        for (int i = 0;i < talkContent[1].Length; i++)
        {
            talkDia.text += talkContent[1][i];
            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(5f);
        talkDia.text = "";
        for (int i = 0; i < talkContent[2].Length; i++)
        {
            talkDia.text += talkContent[2][i];
            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(2f);
        talkDia.text = "";
        for (int i = 0; i < talkContent[3].Length; i++)
        {
            talkDia.text += talkContent[3][i];
            yield return new WaitForSeconds(0.04f);
        }
    }
}
