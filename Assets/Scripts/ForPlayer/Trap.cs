using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject atk;
    public void activeTrap()
    {
        atk.SetActive(true);
    }
    public void inactiveTrap()
    {

    atk.SetActive(false); 
    }
}
