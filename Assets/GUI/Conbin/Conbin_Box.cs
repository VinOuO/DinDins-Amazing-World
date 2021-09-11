using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conbin_Box : MonoBehaviour
{

    GameObject Item_Manager;
    //------------------------------------------------------GUI adject
    Vector3 GUI_Scale;
    Vector3 GUI_Pos;
    //------------------------------------------------------GUI adject
    void Start()
    {
        Item_Manager = GameObject.Find("Item_Manager");
        //------------------------------------------------------GUI adject
        GUI_Pos.Set(-Screen.width / 2, 0, 0);
        GUI_Scale.Set((float)Screen.height / 1000 * 0.8f, (float)Screen.height / 1000 * 0.8f, 1);
        //------------------------------------------------------GUI adject
        //------------------------------------------------------GUI adject
        GetComponent<RectTransform>().localScale = GUI_Scale;
        GetComponent<RectTransform>().localPosition = GUI_Pos;
        //------------------------------------------------------GUI adject
    }

    void Update()
    {

    }
}
