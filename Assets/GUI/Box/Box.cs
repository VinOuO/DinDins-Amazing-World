using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    //------------------------------------------------------GUI adject
    Vector3 GUI_Scale;
    Vector3 GUI_Pos;
    //------------------------------------------------------GUI adject
    public string[] Item;


    void Start()
    {
        //------------------------------------------------------GUI adject
        GUI_Scale.Set((float)Screen.width / 1000 * 0.6f, (float)Screen.width / 1000 * 0.6f, 1);
        GetComponent<RectTransform>().localScale = GUI_Scale;
        //------------------------------------------------------GUI adject
    }

    void Update()
    {
        //------------------------------------------------------GUI adject
        GUI_Pos = Camera.main.WorldToScreenPoint(transform.parent.transform.parent.position);
        GUI_Pos.x -= Screen.width / 2;
        GUI_Pos.y -= Screen.height / 2;
        GetComponent<RectTransform>().localPosition = GUI_Pos;
        //------------------------------------------------------GUI adject

    }

    public bool Put_In(string _Item_name, int _Item_useage)
    {
        int _first_null = -1;
        for (int i = 0; i < 11; i++)
        {
            if (transform.GetChild(i).GetComponent<Pot_Box_Normal>().Item_Name != "None")
            {
                if (_Item_name == transform.GetChild(i).GetComponent<Pot_Box_Normal>().Item_Name)
                {
                    transform.GetChild(i).GetComponent<Pot_Box_Normal>().Item_Num++;
                    transform.GetChild(i).GetComponent<Pot_Box_Normal>().Item_Name = _Item_name;
                    transform.GetChild(i).GetComponent<Pot_Box_Normal>().Item_Useage = _Item_useage;
                    return true;
                }
            }
            else
            {
                if (_first_null == -1)
                {
                    _first_null = i;
                }
            }
        }
        if (_first_null != -1)
        {
            Item[_first_null] = _Item_name;
            transform.GetChild(_first_null).GetComponent<Pot_Box_Normal>().Item_Num = 1;
            transform.GetChild(_first_null).GetComponent<Pot_Box_Normal>().Item_Name = _Item_name;
            transform.GetChild(_first_null).GetComponent<Pot_Box_Normal>().Item_Useage = _Item_useage;
            return true;
        }
        return false;
    }

    public bool Check_Item(string _Item_Name, int _Item_Num)
    {
        for (int i = 0; i < 11; i++)
        {
            if (_Item_Name == Item[i] && transform.GetChild(i).GetComponent<Pot_Box_Normal>().Item_Num >= _Item_Num)
            {
                return true;
            }
        }
        return false;
    }

}
