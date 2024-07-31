using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATKRange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject L, R;
    public void setTrueLeft()
    {
        L.SetActive(true);
    }

    public void setFalseLeft()
    {
        L.SetActive(false);
    }
    public void setTrueRight()
    {
        R.SetActive(true);
    }

    public void setFalseRight()
    {
        R.SetActive(false);
    }
}
