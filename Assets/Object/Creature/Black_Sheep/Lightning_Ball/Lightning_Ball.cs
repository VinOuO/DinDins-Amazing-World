using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Ball : MonoBehaviour
{
    public GameObject Floor_creater, Shooter;
    public bool Is_Out_Of_Screen = false;

    public int Dir = 0;
    float Start_Time = 0;
    Vector3 Start_Pos;
    GameObject temp;
    int Class_Now = 3;
    Vector3 Pos;
    int Pos_Move_Time = 0;
    Vector3 Way;
    void Start()
    {
        Start_Time = Time.time;
        Floor_creater = GameObject.Find("Floor_creater");
        Start_Pos = transform.position;

        if (Is_Out_Of_Screen)
        {
            Pos = transform.position;
            switch (Dir)
            {
                case 1:
                    for (int i = 0; i < 6; i++)
                    {
                        if (i <= 1)
                        {
                            Pos = transform.position + Vector3.left * i;
                        }
                        else if (i <= 3)
                        {
                            Pos = transform.position + Vector3.up * i;
                        }
                        else
                        {
                            Pos = transform.position + Vector3.left * i;
                        }

                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if (Shooter.name != "Player")
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            else
                            {
                                Shooter.GetComponent<Player>().Swing_Tool = false;
                                Shooter.GetComponent<Player>().Back_Pack.transform.GetChild(11).transform.GetChild(1).GetComponent<Weapen_Normal>().Weapen_Use();
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 6; i++)
                    {
                        if (i <= 1)
                        {
                            Pos = transform.position + Vector3.right * i;
                        }
                        else if (i <= 3)
                        {
                            Pos = transform.position + Vector3.down * i;
                        }
                        else
                        {
                            Pos = transform.position + Vector3.right * i;
                        }
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if (Shooter.name != "Player")
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            else
                            {
                                Shooter.GetComponent<Player>().Swing_Tool = false;
                                Shooter.GetComponent<Player>().Back_Pack.transform.GetChild(11).transform.GetChild(1).GetComponent<Weapen_Normal>().Weapen_Use();
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 6; i++)
                    {
                        if (i <= 1)
                        {
                            Pos = transform.position + Vector3.up * i;
                        }
                        else if (i <= 3)
                        {
                            Pos = transform.position + Vector3.right * i;
                        }
                        else
                        {
                            Pos = transform.position + Vector3.up * i;
                        }
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if (Shooter.name != "Player")
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            else
                            {
                                Shooter.GetComponent<Player>().Swing_Tool = false;
                                Shooter.GetComponent<Player>().Back_Pack.transform.GetChild(11).transform.GetChild(1).GetComponent<Weapen_Normal>().Weapen_Use();
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < 6; i++)
                    {
                        if (i <= 1)
                        {
                            Pos = transform.position + Vector3.down * i;
                        }
                        else if (i <= 3)
                        {
                            Pos = transform.position + Vector3.left * i;
                        }
                        else
                        {
                            Pos = transform.position + Vector3.down * i;
                        }
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Pos, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if (Shooter.name != "Player")
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            else
                            {
                                Shooter.GetComponent<Player>().Swing_Tool = false;
                                Shooter.GetComponent<Player>().Back_Pack.transform.GetChild(11).transform.GetChild(1).GetComponent<Weapen_Normal>().Weapen_Use();
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
            }
            Destroy(gameObject);
        }
        Pos = transform.position;
    }

    void Update()
    {
        /*
        if(transform.position.x < 0 || transform.position.x > Floor_creater.GetComponent<Floor_crtater>().Grid_X_Num|| transform.position.y < 0 || transform.position.y > Floor_creater.GetComponent<Floor_crtater>().Grid_Y_Num)
        {
            Destroy(gameObject);             
            Shooter.GetComponent<Object_Normal>().Obj_Round = false;
        }
        */
        if (Pos_Move_Time >= 6)
        {
            if (Shooter.name != "Player")
            {
                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
            }
            else
            {
                Shooter.GetComponent<Player>().Swing_Tool = false;
                Shooter.GetComponent<Player>().Back_Pack.transform.GetChild(11).transform.GetChild(1).GetComponent<Weapen_Normal>().Weapen_Use();
            }
            if (Shooter.name == "Obj_Black_Sheep")
            {
                Shooter.GetComponent<Obj_Black_Sheep>().Attack_Time = 0;
            }
            Destroy(gameObject);
        }

        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
        {
            Debug.Log("Hit: " + Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Object_Up);
            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Object_Up;
            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
            if (Shooter.name != "Player")
            {
                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
            }
            else
            {
                Shooter.GetComponent<Player>().Swing_Tool = false;
                Shooter.GetComponent<Player>().Back_Pack.transform.GetChild(11).transform.GetChild(1).GetComponent<Weapen_Normal>().Weapen_Use();
            }
            if (Shooter.name == "Obj_Black_Sheep")
            {
                Shooter.GetComponent<Obj_Black_Sheep>().Attack_Time = 0;
            }
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, Pos) >= 1)
        {
            Debug.Log("Pos++");
            Pos_Move_Time++;
            Pos = transform.position;
        }

        switch (Dir)
        {
            case 1:
                if (Pos_Move_Time <= 1)
                {
                    Way = Vector3.left;
                }
                else if (Pos_Move_Time <= 3)
                {
                    Way = Vector3.up;
                }
                else
                {
                    Way = Vector3.left;
                }
                break;
            case 2:
                if (Pos_Move_Time <= 1)
                {
                    Way = Vector3.right;
                }
                else if (Pos_Move_Time <= 3)
                {
                    Way = Vector3.down;
                }
                else
                {
                    Way = Vector3.right;
                }
                break;
            case 3:
                if (Pos_Move_Time <= 1)
                {
                    Way = Vector3.up;
                }
                else if (Pos_Move_Time <= 3)
                {
                    Way = Vector3.right;
                }
                else
                {
                    Way = Vector3.up;
                }
                break;
            case 4:
                if (Pos_Move_Time <= 1)
                {
                    Way = Vector3.down;
                }
                else if (Pos_Move_Time <= 3)
                {
                    Way = Vector3.left;
                }
                else
                {
                    Way = Vector3.down;
                }
                break;
        }
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Way * 2 * Time.deltaTime);
    }
}
