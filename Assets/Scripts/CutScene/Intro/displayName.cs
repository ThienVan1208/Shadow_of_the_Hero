using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayName : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nameBanner;
    public void Start()
    {
        nameBanner.SetActive(true);
    }
    public void DisplayName()
    {
        nameBanner.SetActive(true);
        StartCoroutine(inactive());
        Debug.Log("dis");
    }
    IEnumerator inactive()
    {
        yield return new WaitForSeconds(0.7f);
        nameBanner.SetActive(false);
    }
}
