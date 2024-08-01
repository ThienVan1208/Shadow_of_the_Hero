using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public bool notDestroy;
    void Start()
    {
        if(!notDestroy)
            StartCoroutine(Disable());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Disable()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    public void end()
    {
        gameObject.SetActive(false);
    }
}
