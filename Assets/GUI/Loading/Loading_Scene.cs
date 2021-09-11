using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading_Scene : MonoBehaviour {
    int i = 0;
    float Dot_Time = 0;
    //------------------------------------------------------GUI adject
    Vector3 GUI_Scale;
    Vector3 GUI_Pos;
    //------------------------------------------------------GUI adject
    GameObject Floor_creater;
    void Start () {
        Floor_creater = GameObject.Find("Floor_creater");
        //------------------------------------------------------GUI adject
        GUI_Pos.Set(0, 0, 0);
        //GUI_Scale.Set((float)Screen.width / 1000 * 0.4f, (float)Screen.width / 1000 * 0.4f, 1);
        //------------------------------------------------------GUI adject
        //------------------------------------------------------GUI adject
        //GetComponent<RectTransform>().localScale = GUI_Scale;
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        GetComponent<RectTransform>().localPosition = GUI_Pos;
        //------------------------------------------------------GUI adject

    }

    void Update () {
            transform.GetChild(0).GetComponent<Text>().text = "Loading......" + (int)Floor_creater.GetComponent<Floor_crtater>().Loading_Percent + "%";
    }
}
