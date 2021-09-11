using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Bullet : MonoBehaviour
{
    public GameObject Floor_creater, Shooter;
    public bool Is_Out_Of_Screen = false;

    public int Dir = 0;
    float Start_Time = 0;
    Vector3 Start_Pos;
    GameObject temp;
    int Class_Now = 3;
    void Start()
    {
        Start_Time = Time.time;
        Floor_creater = GameObject.Find("Floor_creater");
        Start_Pos = transform.position;

        if (Is_Out_Of_Screen)
        {
            switch (Dir)
            {
                case 1:
                    for (int i = 0; i < 5; i++)
                    {
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.left * i, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.left * i, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if(Shooter!=null)
                            if (Shooter.name == "Obj_Marmot_King")
                            {
                                Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over--;
                                if (Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over <= 0)
                                {
                                    Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                                }
                            }
                            else
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.right * i, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.right * i, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if (Shooter != null)
                                if (Shooter.name == "Obj_Marmot_King")
                            {
                                Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over--;
                                if (Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over <= 0)
                                {
                                    Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                                }
                            }
                            else
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 5; i++)
                    {
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.up * i, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.up * i, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if (Shooter != null)
                                if (Shooter.name == "Obj_Marmot_King")
                            {
                                Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over--;
                                if (Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over <= 0)
                                {
                                    Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                                }
                            }
                            else
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < 5; i++)
                    {
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.down * i, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.down * i, Class_Now).GetComponent<Floor_Normal>().Object_Up;
                            Debug.Log("OFS__Hit: " + temp);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
                            if (Shooter != null)
                                if (Shooter.name == "Obj_Marmot_King")
                            {
                                Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over--;
                                if (Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over <= 0)
                                {
                                    Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                                }
                            }
                            else
                            {
                                Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                            }
                            break;
                        }
                    }
                    break;
            }
        }
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
        if (Vector3.Distance(transform.position, Start_Pos) > 5)
        {
            if (Shooter != null)
                if (Shooter.name == "Obj_Marmot_King")
                {
                    Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over--;
                    if (Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over <= 0)
                    {
                        Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                    }
                }
                else
                {
                    Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                }
            Destroy(gameObject);
        }

        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
        {
            Debug.Log("Hit: " + Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Object_Up);
            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Object_Up;
            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp.transform.position, Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, Shooter);
            if (Shooter != null)
                if (Shooter.name == "Obj_Marmot_King")
                {
                    Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over--;
                    if (Shooter.GetComponent<Obj_Marmot_King>().Shoot_Rock_Over <= 0)
                    {
                        Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                    }
                }
                else
                {
                    Shooter.GetComponent<Object_Normal>().Obj_Round = false;
                }
            Destroy(gameObject);
        }

        switch (Dir)
        {
            case 1:
                GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.left * 2 * Time.deltaTime);
                break;
            case 2:
                GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.right * 2 * Time.deltaTime);
                break;
            case 3:
                GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.up * 2 * Time.deltaTime);
                break;
            case 4:
                GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.down * 2 * Time.deltaTime);
                break;
        }
    }
}


