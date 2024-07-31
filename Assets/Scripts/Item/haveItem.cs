using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haveItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] item;

    void Start()
    {
        // Ensure that the item array is populated with valid GameObjects in the Inspector
    }

    public void getItem()
    {
        if (item.Length == 0)
        {
            Debug.LogError("Item array is empty!");
            return;
        }

        int num = Random.Range(0, item.Length);
        if (item[num] != null)
        {
            Instantiate(item[num], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Attempting to instantiate a null GameObject!");
        }
    }
}
