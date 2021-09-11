using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Weapen_Normal : MonoBehaviour, IPointerClickHandler
{

    public int Test;
    public string Weapen_Name, Weapen_Name_Last;
    public GameObject Item_Manager, Object_Manager;
    public int Weapen_Num, Weapen_Useage;
    GameObject Back_Pack, Player;

    void Start()
    {
        Back_Pack = GameObject.Find("Back_Pack");
        Player = GameObject.Find("Player");
        Item_Manager = GameObject.Find("Item_Manager");
        Object_Manager = GameObject.Find("Object_Manager");
        if (Test == 0)
        {
            Weapen_Name = "None";
            Weapen_Name_Last = Weapen_Name;
            Weapen_Num = 0;
            Weapen_Useage = 0;
        }
        else
        {
            transform.parent.transform.parent.GetComponent<Back_Pack>().Weapen = Weapen_Name;
        }
        Sprite_Check();
    }

    void Update()
    {
        transform.parent.transform.GetChild(0).GetComponent<Text>().text = Weapen_Useage + "%";
        if (Weapen_Name_Last != Weapen_Name)
        {
            Sprite_Check();
            Weapen_Name_Last = Weapen_Name;
        }
    }

    void Sprite_Check()
    {
        gameObject.GetComponent<Image>().sprite = Item_Manager.GetComponent<Item_Manager>().Find_Item_Sprite(Weapen_Name);
    }

    public void Weapen_Use()
    {
        Weapen_Useage -= 1;
        if (Weapen_Useage <= 0)
        {
            Weapen_Name = "None";
            Weapen_Useage = 0;
            Weapen_Num = 0;
            Destroy(Player.transform.GetChild(1).gameObject);
        }
    }
    public void Item_Give_Take(int _Num,int _Useage)
    {
        Weapen_Num += _Num;
        if (Weapen_Num <= 0)
        {
            Weapen_Name = "None";
        }
        else
        {
            Weapen_Useage = (Weapen_Useage * Weapen_Num + _Useage) / (Weapen_Num + 1);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Weapen_Name != "None")
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                GameObject _temp;
                _temp = Instantiate(Object_Manager.GetComponent<Object_Manager>().Find_Object(Weapen_Name));
                _temp.name = Object_Manager.GetComponent<Object_Manager>().Find_Object(Weapen_Name).name;
                _temp.GetComponent<Object_Normal>().Useage = Weapen_Useage;
                if (Back_Pack.GetComponent<Back_Pack>().Put_In(_temp.name, _temp.GetComponent<Object_Normal>().Useage))
                {
                    Weapen_Name = "None";
                    Weapen_Num = 0;
                    Weapen_Useage = 0;

                    Destroy(Player.transform.GetChild(1).gameObject);
                }
            }
        }
    }
}
