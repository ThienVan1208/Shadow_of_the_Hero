using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skill;
    public static float damage = 0.05f;
    public GameObject light;
    public static float mana = 1f;
    public void active()
    {
        skill.SetActive(true);
    }
    public void inactive()
    {
        skill.SetActive(false);
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
    public void LightActive()
    {
        light.SetActive(true);
    }
    public void LightInactive()
    {
        light.SetActive(false);
    }
}
