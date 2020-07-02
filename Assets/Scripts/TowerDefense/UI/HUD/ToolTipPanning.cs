using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipPanning : MonoBehaviour
{
    // Start is called before the first frame update
    //Gameobject as panel for tip
    public GameObject tipPanel;
    void Start()
    {
        //We will show the tip after 1 sec so using Invoke function (we can also use IEnumerator)
        Invoke("ShowTip", 1);
    }
    void ShowTip()
    {
        tipPanel.SetActive(true);
        //After enabling tip panel we hide it after 5 Sec
        Invoke("HideTip", 5);
    }
    void HideTip()
    {
        tipPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
