using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mouse_Box_Normal : MonoBehaviour {

    public int Test;
    public string Item_Name, Item_Name_Last;
    public GameObject Item_Manager;
    public int Item_Num, Item_Useage;
    GameObject Back_Pack, Player, temp;
    public GameObject Box_On;
    GameObject Floor_creater,Obj_M;

    void Start()
    {
        Floor_creater = GameObject.Find("Floor_creater");
        Obj_M = GameObject.Find("Object_Manager");
        Item_Manager = GameObject.Find("Item_Manager");
        Player = GameObject.Find("Player");
        Back_Pack = transform.parent.gameObject;

        Item_Name = "None";
        Item_Name_Last = Item_Name;
        Item_Num = 0;
        Item_Useage = 0;

        Sprite_Check();
    }

    void Update()
    {
        transform.parent.transform.GetChild(0).GetComponent<Text>().text = Item_Num + "";
        if (Item_Name_Last != Item_Name)
        {
            Sprite_Check();
            Item_Name_Last = Item_Name;
        }
        if (Input.GetMouseButtonDown(0))
        {

            if (Box_On != null)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {

                    switch (Box_On.tag)
                    {
                        case "Item":
                            if (Box_On.GetComponent<Item_Normal>().Item_Name != "None" && Item_Name == "None")
                            {
                                Item_Name = Box_On.GetComponent<Item_Normal>().Item_Name;
                                Item_Num = 1;
                                Item_Useage = Box_On.GetComponent<Item_Normal>().Item_Useage;
                                Box_On.GetComponent<Item_Normal>().Item_Give_Take(-1, 0);
                            }
                            else if (Box_On.GetComponent<Item_Normal>().Item_Name == Item_Name && Item_Name != "None")
                            {
                                Box_On.GetComponent<Item_Normal>().Item_Give_Take(-1, 0);
                                Item_Num++;
                            }
                            break;
                        case "Pot_Box":
                            if (Box_On.GetComponent<Pot_Box_Normal>().Item_Name != "None" && Item_Name == "None")
                            {
                                Item_Name = Box_On.GetComponent<Pot_Box_Normal>().Item_Name;
                                Item_Num = 1;
                                Item_Useage = Box_On.GetComponent<Pot_Box_Normal>().Item_Useage;
                                Box_On.GetComponent<Pot_Box_Normal>().Item_Give_Take(-1, 0);
                            }
                            else if (Box_On.GetComponent<Pot_Box_Normal>().Item_Name == Item_Name && Item_Name != "None")
                            {
                                Box_On.GetComponent<Pot_Box_Normal>().Item_Give_Take(-1, 0);
                                Item_Num++;
                            }
                            break;
                    }

                }
                else
                {
                    switch (Box_On.tag)
                    {
                        case "Item":
                            if (Box_On.GetComponent<Item_Normal>().Item_Name != Item_Name)
                            {
                                Box_On.GetComponent<Item_Normal>().Item_Change();
                            }
                            else
                            {
                                if (Item_Name != "None")
                                {
                                    Box_On.GetComponent<Item_Normal>().Item_Num += Item_Num;
                                    Item_Name = "None";
                                    Item_Num = 0;
                                    Item_Useage = 0;
                                }
                            }
                            break;
                        case "Pot_Box":
                            if (Box_On.GetComponent<Pot_Box_Normal>().Item_Name != Item_Name)
                            {
                                Box_On.GetComponent<Pot_Box_Normal>().Item_Change();
                            }
                            else
                            {
                                if (Item_Name != "None")
                                {
                                    Box_On.GetComponent<Pot_Box_Normal>().Item_Num += Item_Num;
                                    Item_Name = "None";
                                    Item_Num = 0;
                                    Item_Useage = 0;
                                }
                            }
                            break;
                    }
                }
            }
            else
            {
                if (Item_Name != "None")
                {
                    for (int i = 0; i < Item_Num; i++)
                    {
                        temp = Instantiate(Obj_M.GetComponent<Object_Manager>().Find_Object(Item_Name), Player.transform.position, Player.transform.rotation, Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position, Player.GetComponent<Player>().Class_Now).transform);
                        temp.transform.localScale /= 0.09f;
                        temp.name = Obj_M.GetComponent<Object_Manager>().Find_Object(Item_Name).name;
                        temp.GetComponent<Object_Normal>().Useage = Item_Useage;
                    }
                    Item_Name = "None";
                    Item_Num = 0;
                    Item_Useage = 0;
                }
            }


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
            if (_useage >= 0)
            {
                Item_Useage -= _useage;
                if (Item_Useage <= 0)
                {
                    Item_Num--;
                    if (Item_Num <= 0)
                    {
                        Item_Name = "None";
                    }
                    else
                    {
                        Item_Useage = 100;
                    }
                }
            }
            else
            {
                Back_Pack.GetComponent<Back_Pack>().Change_Weapen(gameObject);
            }
        }
    }
    public void Item_Give_Take(int _Num, int _Useage)
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

}
