using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Normal : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int Test;
    public string Item_Name, Item_Name_Last;
    public GameObject Item_Manager;
    public int Item_Num, Item_Useage;
    GameObject Back_Pack, Mouse_Box;
    bool Mouse_On = false;

    void Start () {
        Item_Manager = GameObject.Find("Item_Manager");
        Back_Pack = GameObject.Find("Back_Pack");
        Mouse_Box = GameObject.Find("GUI").transform.GetChild(3).gameObject;
        if (Test == 0 ||!GameObject.Find("God").GetComponent<God>().God_Mod)
        {
            Item_Name = "None";
            Item_Name_Last = Item_Name;
            Item_Num = 0;
            Item_Useage = 0;
        }
        else
        {
            Back_Pack.GetComponent<Back_Pack>().Item[Test - 1] = Item_Name;
        }
        Sprite_Check();
    }

	void Update () {
        transform.parent.transform.GetChild(0).GetComponent<Text>().text = Item_Num + "";
        if (Item_Name_Last != Item_Name)
        {
            Sprite_Check();
            Item_Name_Last = Item_Name;
        }
        if (Mouse_On)
        {
            //Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Box_On = gameObject;
        }
    }

    void Sprite_Check()
    {
        gameObject.GetComponent<Image>().sprite = Item_Manager.GetComponent<Item_Manager>().Find_Item_Sprite(Item_Name);
    }

    public void Item_Use()
    {
        if (Item_Name != "None")
        {
            int _useage;
            _useage = Item_Manager.GetComponent<Item_Manager>().Item_Use(Item_Name);
            if (_useage > 0)
            {
                Item_Useage -= _useage;
                if (Item_Useage <= 0)
                {
                    Item_Num--;
                    if (Item_Num <= 0)
                    {
                        Item_Name = "None";
                    }
                }
            }
            else if(_useage == 0)
            {

            }
            else
            {
                Back_Pack.GetComponent<Back_Pack>().Change_Weapen(gameObject);
            }
        }
    }
    public void Item_Give_Take(int _Num,int _Useage)
    {
        Item_Num += _Num;
        if (Item_Num <= 0)
        {
            Item_Name = "None";
        }
        else
        {
            if (_Useage > 0)
            {
                Item_Useage = (Item_Useage * Item_Num + _Useage) / (Item_Num + 1);
            }
        }
    }
    public void Item_Change()
    {
        string _Item_Name;
        int _Item_Num, _Item_Useage;

        _Item_Name = Item_Name;
        _Item_Num = Item_Num;
        _Item_Useage = Item_Useage;

        Item_Name = Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Name;
        Item_Num = Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Num;
        Item_Useage = Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Useage;

        Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Name = _Item_Name;
        Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Num = _Item_Num;
        Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Useage = _Item_Useage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Item_Use();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Mouse_On = true;
        Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Box_On = gameObject;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Mouse_On = false;
        Mouse_Box.transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Box_On = null;
    }
}
