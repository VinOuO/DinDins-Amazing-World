using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Manager : MonoBehaviour {

    public GameObject Calender, Player;
    public GameObject[] Creature_Prefab;
    public GameObject[] Creature;
    public int[] Creature_Type_Num;
    public int Creature_Num = 0, Round_Creature = -1;
    public bool Simple_Mod = false;
    void Start () {

    }
	
	void Update () {
        if (Player.GetComponent<Player>().Player_Round > Calender.GetComponent<Calendar>().Round)
        {
            Spown_Marmot_King_Check();
            if (Creature_Num > 0)
            {
                if (Round_Creature == -1)
                {
                    New_Round_Set();
                }
                else
                {
                    if (!Creature[Round_Creature].GetComponent<Object_Normal>().Obj_Round)
                    {
                        if (Round_Creature + 1 >= Creature_Num)
                        {
                            Calender.GetComponent<Calendar>().Round++;
                            Round_Creature = -1;
                            Spown_Marmot_King_Check();
                        }
                        else
                        {
                            if (Simple_Mod)
                            {
                                Round_Creature++;
                                while (Creature[Round_Creature].GetComponent<Object_Normal>().Is_Out_Of_Screen)
                                {
                                    Round_Creature++;
                                    if (Round_Creature + 1 >= Creature_Num)
                                    {
                                        Calender.GetComponent<Calendar>().Round++;
                                        Round_Creature = -1;
                                        Spown_Marmot_King_Check();
                                        break;
                                    }
                                }
                                if (Round_Creature != -1)
                                {
                                    Creature[Round_Creature].GetComponent<Object_Normal>().Obj_Round = true;
                                }
                            }
                            else
                            {
                                Round_Creature++;
                                Creature[Round_Creature].GetComponent<Object_Normal>().Obj_Round = true;
                            }
                        }
                    }

                }
            }
            else
            {
                Calender.GetComponent<Calendar>().Round++;
            }
        }

    }

    void Spown_Marmot_King_Check()
    {
        if (Player.GetComponent<Player>().Marmot_Kill >= 2)
        {
            Debug.Log("KKK");
            Player.GetComponent<Player>().Marmot_Kill = 0;
            Player.GetComponent<Player>().Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.GetComponent<Player>().Destination + Vector3.right * 10, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(Creature_Prefab[6]);
        }
    }

    void New_Round_Set()
    {
        Round_Creature = 0;
        if (Creature_Num > 0) {
            if (!Creature[Round_Creature].GetComponent<Object_Normal>().Is_Out_Of_Screen && Simple_Mod)
            {
                Creature[0].GetComponent<Object_Normal>().Obj_Round = true;
            }
            Round_Creature = 0;
        }
    }

    public void Add_Creature(GameObject _Creature)
    {
        Creature[Creature_Num] = _Creature;
        Creature_Num++;
        switch (_Creature.name)
        {
            case "Obj_Pig_Man":
                Creature_Type_Num[0]++;
                break;
            case "Obj_Marmot":
                Creature_Type_Num[1]++;
                break;
            case "Obj_Crokong":
                Creature_Type_Num[2]++;
                break;
            case "Obj_Ray":
                Creature_Type_Num[3]++;
                break;
            case "Obj_Sheep":
                Creature_Type_Num[4]++;
                break;
            case "Obj_Black_Sheep":
                Creature_Type_Num[5]++;
                break;
            case "Obj_Marmot_King":
                Creature_Type_Num[6]++;
                break;
        }
    }

    public void Remove_Creature(int _Creature_Num,string _Creature_Name)
    {
        for(int i = _Creature_Num; i < Creature_Num; i++)
        {
            if (i == Creature_Num - 1)
            {
                Creature[i] = null;
            }
            else
            {
                Creature[i] = Creature[i + 1];
                Creature[i].GetComponent<Object_Normal>().Creature_Num--;
            }
        }
        Creature_Num--;
        switch (_Creature_Name)
        {
            case "Obj_Pig_Man":
                Creature_Type_Num[0]--;
                break;
            case "Obj_Marmot":
                Creature_Type_Num[1]--;
                break;
            case "Obj_Crokong":
                Creature_Type_Num[2]--;
                break;
            case "Obj_Ray":
                Creature_Type_Num[3]--;
                break;
            case "Obj_Sheep":
                Creature_Type_Num[4]--;
                break;
            case "Obj_Black_Sheep":
                Creature_Type_Num[5]--;
                break;
            case "Obj_Marmot_King":
                Creature_Type_Num[6]--;
                break;
        }
    }
}
