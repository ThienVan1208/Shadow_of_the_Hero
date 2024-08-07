using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutScene : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        StartCoroutine(countToEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator countToEnd()
    {
        yield return new WaitForSeconds(11.5f);
        Audio.sound.end = true;
    }
}
