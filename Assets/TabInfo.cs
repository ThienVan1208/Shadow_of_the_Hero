using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public MainControl mainControl;
    public UIIventoryPage inventoryPage;

    void Start()
    {
        inventoryPage.initStart();
       
    }

    // Update is called once per frame
    void Update()
    {
        inventoryPage.updateCheckLv();
    }
}
