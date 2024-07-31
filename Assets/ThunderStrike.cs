using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStrike : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] strike;
    public displayName dis;
    public void Start()
    {
        
        StartCoroutine( Strike());
    }
    public IEnumerator Strike()
    {
        dis.DisplayName();
        for (int i = 0; i < strike.Length; i++)
        {
            strike[i].SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    
}
