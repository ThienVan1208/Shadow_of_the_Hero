using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signalForFadeUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void FunctionToActiveFadeUI()
    {
        ItemManager.itemManager.FadeForCutScene();
    }
}
