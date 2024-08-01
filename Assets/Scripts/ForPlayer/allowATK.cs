using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allowATK : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator AllowATK()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<MainControl>().ATKForUI = false;
    }
    public void allow()
    {
        StartCoroutine(AllowATK());
    }
}
