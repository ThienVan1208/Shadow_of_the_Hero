using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveExp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject expPrefab;
    public void CreateExp(float exp)
    {
        GameObject EXP = Instantiate(expPrefab, transform.position, Quaternion.identity);
        EXP.GetComponent<Exp>().getExp = exp;
    }
}
