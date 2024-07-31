using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogForForestDark : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI name, talkDia;
    [TextArea(3, 10)]
    public string[] talkContent;
    public string nameChar;
    public Animator animator;
    void Start()
    {
        StartCoroutine(TalkInDark());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator TalkInDark()
    {
        name.text = nameChar;
        talkDia.text = "";
        for (int i = 0; i < talkContent[0].Length; i++)
        {
            talkDia.text += talkContent[0][i];
            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(2f);
        talkDia.text = "";
        for (int i = 0; i < talkContent[1].Length; i++)
        {
            talkDia.text += talkContent[1][i];
            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(2f);
        animator.SetTrigger("close");
    }
}
