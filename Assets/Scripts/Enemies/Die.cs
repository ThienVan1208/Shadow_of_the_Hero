using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
    public void die()
    {
        gameObject.SetActive(false);
    }
}
