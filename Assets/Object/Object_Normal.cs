using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Normal : MonoBehaviour {

    public GameObject Player;
    public string Type;
    public int Health;
    public int Useage = 100;
    public GameObject Floor_creat, Creature_Manager, Calender;
    public bool Obj_Round;
    public bool Is_Glowing;
    public bool Is_On_Fire;
    public int Fire_Size = 0;
    public int Creature_Num;
    public int cc_Round = 0;
    public int Class_Now = 3;
    public bool Is_Out_Of_Screen;
    Vector3 Screen_Pos;
    void Start () {
        Player = GameObject.Find("Player");
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Floor_creat = GameObject.Find("Floor_creater");
        Creature_Manager = GameObject.Find("Creature_Manager");
        GetComponent<SpriteRenderer>().sortingOrder = -(int)transform.position.y;
        if (gameObject.name == "Obj_Farm")
        {
            GetComponent<SpriteRenderer>().sortingOrder = -9999;
        }
        Obj_Round = false;
        Is_Glowing = false;
        Is_On_Fire = false;
        if(Type == "Creature")
        {
            Creature_Num = Creature_Manager.GetComponent<Creature_Manager>().Creature_Num;
            Creature_Manager.GetComponent<Creature_Manager>().Add_Creature(gameObject);
        }

    }

	void Update () {
        /*
        Screen_Pos = Camera.main.WorldToScreenPoint(transform.position);
        if (Screen_Pos.x < -2 || Screen_Pos.y < -2 || Screen_Pos.x > Screen.width + 2 || Screen_Pos.y > Screen.height + 2)
        {
            Is_Out_Of_Screen = true;
        }
        else
        {
            Is_Out_Of_Screen = false;
        }
        */
    }

    void On_Fire()
    {

    }
    /*
    void Round_Move(string _Name)
    {
        switch (_Name)
        {
            case "Obj_Pig_Man":
                GetComponent<Obj_Pig_Man>().
                break;
        }
    }
    */
}
