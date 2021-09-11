using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obj_Pot : MonoBehaviour {

    public bool Is_Showing = false;
    bool Is_Cooking = false;
    string Food_Name = "Obj_Banch";
    GameObject Calender, Obj_M;
    public int Cook_Round = 0;
    GameObject Pot_Box, Food, Player;
    public Sprite[] Pot_Sprite;

    void Start () {
        Player = GameObject.Find("Player");
        Obj_M = GameObject.Find("Object_Manager");
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Pot_Box = transform.GetChild(1).transform.GetChild(0).gameObject;
    }
	
	void Update () {
        if (Is_Cooking)
        {
            if (Calender.GetComponent<Calendar>().Round - Cook_Round >= 3)
            {
                Food = Instantiate(Obj_M.GetComponent<Object_Manager>().Find_Object(Food_Name), transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                Food.transform.localScale /= 0.09f;
                Food.name = Obj_M.GetComponent<Object_Manager>().Find_Object(Food_Name).name;
                Is_Cooking = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if (Is_Cooking)
        {
            if (GetComponent<SpriteRenderer>().sprite != Pot_Sprite[1])
            {
                GetComponent<SpriteRenderer>().sprite = Pot_Sprite[1];
            }
        }
        else
        {
            if (GetComponent<SpriteRenderer>().sprite != Pot_Sprite[0])
            {
                GetComponent<SpriteRenderer>().sprite = Pot_Sprite[0];
            }
        }
        if (Is_Showing)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) > 1.05f)
            {
                Close();
            }
        }
    }

    void Show()
    {
        transform.GetChild(1).GetComponent<CanvasGroup>().alpha = 1;
        transform.GetChild(1).GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.GetChild(1).GetComponent<CanvasGroup>().interactable = true;
        Is_Showing = true;

    }

    void Hide()
    {
        transform.GetChild(1).GetComponent<CanvasGroup>().alpha = 0;
        transform.GetChild(1).GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.GetChild(1).GetComponent<CanvasGroup>().interactable = false;
        Is_Showing = false;
    }

    public void Open()
    {
        if (!Is_Cooking)
        {
            Show();
        }
    }

    public void Close()
    {
        //--------------------------------------------------------水果拼盤
        if (Pot_Box.GetComponent<Pot_Box>().Check_Item("Obj_Apple", 1) && Pot_Box.GetComponent<Pot_Box>().Check_Item("Obj_Banana", 1) && Pot_Box.GetComponent<Pot_Box>().Check_Item("Obj_Watermelon", 1))
        {
            if (Pot_Box.GetComponent<Pot_Box>().Check_Item("Obj_Blue_Berry", 1))
            {
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Apple", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Banana", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Watermelon", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Blue_Berry", 1);
                Food_Name = "Obj_Fruit_Platter";
                Is_Cooking = true;
                Cook_Round = Calender.GetComponent<Calendar>().Round;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (Pot_Box.GetComponent<Pot_Box>().Check_Item("Obj_Yellow_Berry", 1))
            {
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Apple", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Banana", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Watermelon", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Yellow_Berry", 1);
                Food_Name = "Obj_Fruit_Platter";
                Is_Cooking = true;
                Cook_Round = Calender.GetComponent<Calendar>().Round;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (Pot_Box.GetComponent<Pot_Box>().Check_Item("Obj_Red_Berry", 1))
            {
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Apple", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Banana", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Watermelon", 1);
                Pot_Box.GetComponent<Pot_Box>().Consume_Item("Obj_Red_Berry", 1);
                Food_Name = "Obj_Fruit_Platter";
                Is_Cooking = true;
                Cook_Round = Calender.GetComponent<Calendar>().Round;
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        //--------------------------------------------------------水果拼盤
        //--------------------------------------------------------沙拉

        //--------------------------------------------------------沙拉
        //--------------------------------------------------------豬腳麵線

        //--------------------------------------------------------豬腳麵線
        Hide();
    }
}
