using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Back_Pack : MonoBehaviour {

    public int Back_Pack_Size = 11;
    public string[] Item;
    public string Weapen;
    //public int[] Item_Num;
    GameObject Player, Object_Manager, temp;
    //------------------------------------------------------GUI adject
    Vector3 GUI_Scale;
    Vector3 GUI_Pos;
    //------------------------------------------------------GUI adject
    void Start () {
        Player = GameObject.Find("Player");
        Object_Manager = GameObject.Find("Object_Manager");
        for(int i = 0; i < 11; i++)
        {
            Item[i] = "None";
            //Item_Num[i] = 0;
        }
        //------------------------------------------------------GUI adject
        GUI_Pos.Set(0, -Screen.height/2, 0);
        GUI_Scale.Set((float)Screen.width / 1000 * 0.4f, (float)Screen.width / 1000 * 0.4f, 1);
        //------------------------------------------------------GUI adject
        //------------------------------------------------------GUI adject
        GetComponent<RectTransform>().localScale = GUI_Scale;
        GetComponent<RectTransform>().localPosition = GUI_Pos;
        //------------------------------------------------------GUI adject
    }

    void Update () {
		
	}

    public bool Put_In(string _Item_name,int _Item_useage)
    {
        int _first_null = -1;
        for (int i = 0; i < 11; i++)
        {
            if (transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Name != "None")
            {
                if (_Item_name == transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Name)
                {
                    //transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Num++;
                    //transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Name = _Item_name;
                    //transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Useage = _Item_useage;
                    transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Give_Take(1, _Item_useage);
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
            transform.GetChild(_first_null).GetChild(1).GetComponent<Item_Normal>().Item_Num = 1;
            transform.GetChild(_first_null).GetChild(1).GetComponent<Item_Normal>().Item_Name = _Item_name;
            transform.GetChild(_first_null).GetChild(1).GetComponent<Item_Normal>().Item_Useage = _Item_useage;
            return true;
        }
        return false;
    }

    public void Change_Weapen(GameObject _Item)
    {
        string _temp_name;
        int _temp_num,_temp_useage;
        if (transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Num == 0)
        {
            //---swap
            Weapen = _Item.GetComponent<Item_Normal>().Item_Name;
            transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Name = _Item.GetComponent<Item_Normal>().Item_Name;
            transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Num = 1;
            transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Useage = _Item.GetComponent<Item_Normal>().Item_Useage;

            //_Item.GetComponent<Item_Normal>().Item_Name = "None";
            //_Item.GetComponent<Item_Normal>().Item_Num = 0;
            //_Item.GetComponent<Item_Normal>().Item_Useage = 0;
            _Item.GetComponent<Item_Normal>().Item_Give_Take(-1, 0);
            //---swap
            temp = Instantiate(Object_Manager.GetComponent<Object_Manager>().Find_Tool(Weapen), transform.position, transform.rotation, Player.transform);
            temp.name = Object_Manager.GetComponent<Object_Manager>().Find_Tool(Weapen).name;
        }
        else
        {
            //---swap
            _temp_name = Weapen;
            _temp_num = 1;
            _temp_useage = transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Useage;

            Weapen = _Item.GetComponent<Item_Normal>().Item_Name;
            transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Name = _Item.GetComponent<Item_Normal>().Item_Name;
            transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Num = _Item.GetComponent<Item_Normal>().Item_Num;
            transform.GetChild(11).GetChild(1).GetComponent<Weapen_Normal>().Weapen_Useage = _Item.GetComponent<Item_Normal>().Item_Useage;

            _Item.GetComponent<Item_Normal>().Item_Give_Take(-1, -1);

            /*
            _Item.GetComponent<Item_Normal>().Item_Name = _temp_name;
            _Item.GetComponent<Item_Normal>().Item_Num = _temp_num;
            _Item.GetComponent<Item_Normal>().Item_Useage = _temp_useage;
            */
            Put_In(_temp_name, _temp_useage);
            //---swap
            Destroy(Player.transform.GetChild(1).gameObject);
            temp = Instantiate(Object_Manager.GetComponent<Object_Manager>().Find_Tool(Weapen), transform.position, transform.rotation, Player.transform);
            temp.name = Object_Manager.GetComponent<Object_Manager>().Find_Tool(Weapen).name;
        }
    }

    public bool Check_Item(string _Item_Name,int _Item_Num)
    {
        for(int i = 0; i < 11; i++)
        {
            if (_Item_Name == transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Name && transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Num >= _Item_Num)
            {
                return true;
            }
        }
        return false;
    }

    public void Consume_Item(string _Item_Name, int _Item_Num)
    {
        for (int i = 0; i < 11; i++)
        {
            if (_Item_Name == transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Name && transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Num >= _Item_Num)
            {
                transform.GetChild(i).GetChild(1).GetComponent<Item_Normal>().Item_Give_Take(-_Item_Num, 0);
            }
        }
    }
}
