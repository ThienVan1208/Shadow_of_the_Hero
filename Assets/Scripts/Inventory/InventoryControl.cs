using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField]
    private UIIventoryPage inventPage;
    public int numItem = 10;
    public void Start()
    {
        inventPage.InitializeItem(numItem);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventPage.isActiveAndEnabled == false)
            {
                inventPage.Show();
            }
            else
            {
                inventPage.Hide();
            }
        }
    }
}
