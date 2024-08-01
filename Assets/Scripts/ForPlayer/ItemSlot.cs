using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] image;
    public Image display;
    private int index = 0;
    public string curItem;
    public string[] name;
    public Image fade;
    void Start()
    {
        display.gameObject.SetActive(false);
        fade.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeItem();
        
    }
    public void ChangeItem()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Fade());
            display.gameObject.SetActive(true);
            index = (index + 1) % image.Length;
            display.sprite = image[index];
            
                curItem = name[index];
            
        }
    }
    public IEnumerator Fade()
    {
        fade.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fade.gameObject.SetActive(false);
    }
}
