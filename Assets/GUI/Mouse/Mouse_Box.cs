using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Box : MonoBehaviour {

    bool Is_Showing = false;

    //------------------------------------------------------GUI adject
    Vector3 GUI_Scale;
    Vector3 GUI_Pos;
    //------------------------------------------------------GUI adject

    void Start () {
        Hide();
        //------------------------------------------------------GUI adject
        GUI_Scale.Set((float)Screen.width / 1000 * 0.5f, (float)Screen.width / 1000 * 0.5f, 1);
        GetComponent<RectTransform>().localScale = GUI_Scale;
        //------------------------------------------------------GUI adject
    }

    void Update () {
        //------------------------------------------------------GUI adject
        GUI_Pos = Input.mousePosition;
        GUI_Pos.x -= Screen.width / 2;
        GUI_Pos.y -= Screen.height / 2;
        GetComponent<RectTransform>().localPosition = GUI_Pos;
        //------------------------------------------------------GUI adject
        if (transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Name == "None")
        {
            if (Is_Showing)
            {
                Hide();
            }
        }
        else
        {
            if (!Is_Showing)
            {
                Show();
            }
        }

    }

    void Show()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        Is_Showing = true;

    }

    void Hide()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        Is_Showing = false;
    }
}
