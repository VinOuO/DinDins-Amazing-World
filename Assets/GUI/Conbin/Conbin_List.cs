using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conbin_List : MonoBehaviour {
    public GameObject Item_Manager;
    public GameObject[] Conbin_Item;
    public int Conbin_Item_Num;
    public int P = 0;
	void Start () {
        Item_Manager = GameObject.Find("Item_Manager");
        Sprite_Change();
    }
	
	void Update () {

	}

    public void Sprite_Change()
    {
        if (P > Conbin_Item_Num - 5)
        {
            P = Conbin_Item_Num - 5;
        }
        else if (P < 0)
        {
            P = 0;
        }
        for (int i = 1; i <= 5; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = Item_Manager.GetComponent<Item_Manager>().Find_Item_Sprite(Conbin_Item[i - 1 + P].name);
        }
    }
    public void Conbin(int _Box_Order)
    {
        Item_Manager.GetComponent<Item_Manager>().Item_Conbin(Conbin_Item[_Box_Order - 1 + P].name);
    }
}
