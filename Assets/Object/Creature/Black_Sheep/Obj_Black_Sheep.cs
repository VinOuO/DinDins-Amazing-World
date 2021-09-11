using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obj_Black_Sheep : MonoBehaviour
{

    Vector3 Destination, Attack_Target_Pos, Last_Pos, LLast_Pos, temp;
    bool Is_Closing = false;
    public GameObject Lightning_Ball,Ball;
    public GameObject Meat, Pock_Knuckle, temp_I;
    public GameObject Floor_creater;
    float Speed;
    bool Is_Going_Somewhere;
    int Dir;
    public RuntimeAnimatorController[] Anim;
    public GameObject Floor_Stand;
    public string Move_State;
    bool Can_Pass_1, Can_Pass_2, Can_Pass_3, Can_Pass_4;
    public GameObject Attack_Target;
    public int Anger = 0;
    Vector3 Screen_Pos;
    public bool Is_Out_Of_Screen;
    public int Attack_Time = 0;
    int Anger_Round = 0;
    void Start()
    {
        Floor_creater = GameObject.Find("Floor_creater");
        Screen_Pos = Camera.main.WorldToScreenPoint(transform.position);
        Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
        LLast_Pos = Last_Pos = Destination = transform.position;
        Is_Going_Somewhere = false;
        Is_Out_Of_Screen = false;
        Dir = 1;
        Speed = 2f;
        Move_State = "None";
    }

    void Update()
    {
        Screen_Pos = Camera.main.WorldToScreenPoint(transform.position);
        if (Screen_Pos.x < 0 || Screen_Pos.y < 0 || Screen_Pos.x > Screen.width || Screen_Pos.y > Screen.height)
        {
            Is_Out_Of_Screen = true;
        }
        else
        {
            Is_Out_Of_Screen = false;
        }

        Change_Sprite();

        if (Floor_Stand == null)
        {
            Floor_Stand = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now);
            Floor_Stand.GetComponent<Floor_Normal>().Is_Empty = false;
            Floor_Stand.GetComponent<Floor_Normal>().Object_Up = gameObject;
        }

        if (GetComponent<Object_Normal>().Calender.GetComponent<Calendar>().Round - Anger_Round >= 1 && Anger > 0)
        {
            Anger--;
            Anger_Round = GetComponent<Object_Normal>().Calender.GetComponent<Calendar>().Round;
        }
        //------------------------------------------------------------------------
        if (GetComponent<Object_Normal>().Obj_Round)
        {
            if (GetComponent<Object_Normal>().cc_Round == 0)
            {
                if (Anger > 0)
                {
                    Move_State = "Attacking";
                }
                else
                {
                    Move_State = "None";
                }

                switch (Move_State)
                {
                    case "None":
                        //------------------------------------------------------------亂晃
                        if (!Is_Going_Somewhere)
                        {
                            temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
                            Destination = temp;
                            switch (UnityEngine.Random.Range(0, 5))
                            {
                                case 0:

                                    break;
                                case 1:
                                    Destination += Vector3.left;
                                    Is_Going_Somewhere = Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
                                    break;
                                case 2:
                                    Destination += Vector3.right;
                                    Is_Going_Somewhere = Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
                                    break;
                                case 3:
                                    Destination += Vector3.up;
                                    Is_Going_Somewhere = Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
                                    break;
                                case 4:
                                    Destination += Vector3.down;
                                    Is_Going_Somewhere = Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
                                    break;
                            }
                        }
                        else
                        {
                            Move(Destination);
                        }
                        //------------------------------------------------------------亂晃
                        break;
                    case "Attacking":
                        if (Attack_Target == null)
                        {
                            Anger = 0;
                            break;
                        }
                        if (Attack_Time < 2)//---attack
                        {

                            if (Vector3.Distance(Floor_Stand.transform.position, Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Attack_Target.transform.position, GetComponent<Object_Normal>().Class_Now).transform.position) <= 1 && Floor_Stand.transform.position == transform.position)
                            {
                                if (Attack_Target.transform.position.x < transform.position.x)
                                {
                                    Dir = 1;
                                }
                                else if (Attack_Target.transform.position.x > transform.position.x)
                                {
                                    Dir = 2;
                                }
                                else if (Attack_Target.transform.position.y > transform.position.y)
                                {
                                    Dir = 3;
                                }
                                else
                                {
                                    Dir = 4;
                                }
                                Change_Sprite();
                                if (!GetComponent<Animator>().GetBool("Is_Attacking") && !GetComponent<Animator>().GetBool("Attacked"))
                                {
                                    if (!Is_Out_Of_Screen)
                                    {
                                        GetComponent<Animator>().SetTrigger("attack");
                                    }
                                    else
                                    {
                                        Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Attack_Target.transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, gameObject);
                                        Attack_Time++;
                                        Anger = 10;
                                        GetComponent<Object_Normal>().Obj_Round = false;
                                        Debug.Log("OFS_____attack");
                                    }
                                }
                                else if (!GetComponent<Animator>().GetBool("Is_Attacking") && GetComponent<Animator>().GetBool("Attacked"))
                                {
                                    Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Attack_Target.transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 20, gameObject);
                                    Attack_Time++;
                                    GetComponent<Animator>().SetBool("Attacked", false);
                                    Anger = 10;
                                    GetComponent<Object_Normal>().Obj_Round = false;
                                }

                            }
                            else
                            {
                                Move_Point(Attack_Target.transform.position);
                            }
                        }
                        else if(Attack_Time == 2) //---Attack
                        {
                            if (!GetComponent<Animator>().GetBool("Is_Attacking") && !GetComponent<Animator>().GetBool("Attacked"))
                            {
                                if (!Is_Out_Of_Screen)
                                {
                                    GetComponent<Animator>().SetTrigger("Attack");
                                }
                                else
                                {
                                    Attack_Time++;
                                    //------------------------------------------------------Special Attack
                                    switch (Dir)
                                    {
                                        case 1:
                                            Ball = Instantiate(Lightning_Ball, transform.position + Vector3.left, transform.rotation);
                                            break;
                                        case 2:
                                            Ball = Instantiate(Lightning_Ball, transform.position + Vector3.right, transform.rotation);
                                            break;
                                        case 3:
                                            Ball = Instantiate(Lightning_Ball, transform.position + Vector3.up, transform.rotation);
                                            break;
                                        case 4:
                                            Ball = Instantiate(Lightning_Ball, transform.position + Vector3.down, transform.rotation);
                                            break;
                                    }
                                    Ball.GetComponent<Lightning_Ball>().Dir = Dir;
                                    Ball.GetComponent<Lightning_Ball>().Shooter = gameObject;
                                    Ball.GetComponent<Lightning_Ball>().Is_Out_Of_Screen = Is_Out_Of_Screen;
                                    //------------------------------------------------------Special Attack
                                    Anger = 10;
                                }
                            }
                            else if (!GetComponent<Animator>().GetBool("Is_Attacking") && GetComponent<Animator>().GetBool("Attacked"))
                            {
                                Attack_Time++;
                                GetComponent<Animator>().SetBool("Attacked", false);
                                //------------------------------------------------------Special Attack
                                switch (Dir)
                                {
                                    case 1:
                                        Ball = Instantiate(Lightning_Ball, transform.position + Vector3.left, transform.rotation);
                                        break;
                                    case 2:
                                        Ball = Instantiate(Lightning_Ball, transform.position + Vector3.right, transform.rotation);
                                        break;
                                    case 3:
                                        Ball = Instantiate(Lightning_Ball, transform.position + Vector3.up, transform.rotation);
                                        break;
                                    case 4:
                                        Ball = Instantiate(Lightning_Ball, transform.position + Vector3.down, transform.rotation);
                                        break;
                                }
                                Ball.GetComponent<Lightning_Ball>().Dir = Dir;
                                Ball.GetComponent<Lightning_Ball>().Shooter = gameObject;
                                Ball.GetComponent<Lightning_Ball>().Is_Out_Of_Screen = Is_Out_Of_Screen;
                                //------------------------------------------------------Special Attack
                                Anger = 10;
                            }

                        }
                        break;
                }
            }
            else
            {
                GetComponent<Object_Normal>().Obj_Round = false;
                GetComponent<Object_Normal>().cc_Round--;
            }
        }
        //------------------------------------------------------------------------
        if (GetComponent<Object_Normal>().Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Move_Point(Vector3 _Target)
    {
        if (!Is_Going_Somewhere)
        {
            temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
            Destination = temp;
            Is_Going_Somewhere = true;
            if (Last_Pos != Destination)
            {
                LLast_Pos = Last_Pos;
                Last_Pos = Destination;
                Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
            }

            if (transform.position.x < _Target.x && Can_Pass_1 && Destination + Vector3.right != LLast_Pos)
            {
                Destination += Vector3.right;
            }
            else if (transform.position.x > _Target.x && Can_Pass_2 && Destination + Vector3.left != LLast_Pos)
            {
                Destination += Vector3.left;
            }
            else if (transform.position.y < _Target.y && Can_Pass_3 && Destination + Vector3.up != LLast_Pos)
            {
                Destination += Vector3.up;
            }
            else if (transform.position.y > _Target.y && Can_Pass_4 && Destination + Vector3.down != LLast_Pos)
            {
                Destination += Vector3.down;
            }
            else if (transform.position.x < _Target.x && Can_Pass_1)
            {
                Destination += Vector3.right;
            }
            /*
            else if (transform.position.x > _Target.x && Can_Pass_2)
            {
                Destination += Vector3.left;
            }
            else if (transform.position.y < _Target.y && Can_Pass_3)
            {
                Destination += Vector3.up;
            }
            else if (transform.position.y > _Target.y && Can_Pass_4)
            {
                Destination += Vector3.down;
            }
            */
            else
            {
                if (!Can_Pass_1)
                {
                    if (Can_Pass_3)
                    {
                        Destination += Vector3.up;
                    }
                    else if (Can_Pass_4)
                    {
                        Destination += Vector3.down;
                    }
                }
                else if (!Can_Pass_2)
                {
                    if (Can_Pass_3)
                    {
                        Destination += Vector3.up;
                    }
                    else if (Can_Pass_4)
                    {
                        Destination += Vector3.down;
                    }
                }
                else if (!Can_Pass_3)
                {
                    if (Can_Pass_1)
                    {
                        Destination += Vector3.right;
                    }
                    else if (Can_Pass_2)
                    {
                        Destination += Vector3.left;
                    }
                }
                else if (!Can_Pass_4)
                {
                    if (Can_Pass_1)
                    {
                        Destination += Vector3.right;
                    }
                    else if (Can_Pass_2)
                    {
                        Destination += Vector3.left;
                    }
                }
            }
        }
        Move(Destination);
    }
    /*
    public void Move_Point(Vector3 _Target)
    {
        if (!Is_Going_Somewhere)
        {
            temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
            Destination = temp;
            Is_Going_Somewhere = true;
            if (Last_Pos != temp)
            {
                Last_Pos = temp;
                Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
            }
            if (transform.position.x < _Target.x && Can_Pass_1)
            {
                Destination += Vector3.right;
            }
            else if (transform.position.x > _Target.x && Can_Pass_2)
            {
                Destination += Vector3.left;
            }
            else
            {
                if (transform.position.y < _Target.y && Can_Pass_3)
                {
                    Destination += Vector3.up;
                }
                else if (transform.position.y > _Target.y && Can_Pass_4)
                {
                    Destination += Vector3.down;
                }
            }
        }
        Move(Destination);
    }
    */
    public void Move(Vector3 _Destination)
    {
        if (Vector3.Distance(transform.position, _Destination) > 0.1f)
        {
            if (transform.position.x != _Destination.x)
            {
                if (transform.position.x < _Destination.x)
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_Destination, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        if (!Is_Out_Of_Screen)
                        {
                            GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.right * Speed * Time.deltaTime);
                        }
                        else
                        {
                            transform.position = _Destination;
                        }
                    }
                    else
                    {
                        Can_Pass_1 = false;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        GetComponent<Object_Normal>().Obj_Round = false;
                        temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
                        Destination = temp;
                    }
                    Dir = 2;
                }
                else
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_Destination, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        if (!Is_Out_Of_Screen)
                        {
                            GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.left * Speed * Time.deltaTime);
                        }
                        else
                        {
                            transform.position = _Destination;
                        }
                    }
                    else
                    {
                        Can_Pass_2 = false;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        GetComponent<Object_Normal>().Obj_Round = false;
                        temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
                        Destination = temp;
                    }
                    Dir = 1;
                }
            }
            else
            {
                if (transform.position.y < _Destination.y)
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_Destination, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        if (!Is_Out_Of_Screen)
                        {
                            GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.up * Speed * Time.deltaTime);
                        }
                        else
                        {
                            transform.position = _Destination;
                        }
                    }
                    else
                    {
                        Can_Pass_3 = false;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        GetComponent<Object_Normal>().Obj_Round = false;
                        temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
                        Destination = temp;
                    }
                    Dir = 3;
                }
                else
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_Destination, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        if (!Is_Out_Of_Screen)
                        {
                            GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.down * Speed * Time.deltaTime);
                        }
                        else
                        {
                            transform.position = _Destination;
                        }
                    }
                    else
                    {
                        Can_Pass_4 = false;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        GetComponent<Object_Normal>().Obj_Round = false;
                        temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
                        Destination = temp;
                    }
                    Dir = 4;
                }
            }
        }
        else
        {
            transform.position = _Destination;
            Is_Going_Somewhere = false;
            Floor_Change();
            GetComponent<Object_Normal>().Obj_Round = false;
            temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
            Destination = temp;
        }
    }

    void Floor_Change()
    {
        Floor_Stand.GetComponent<Floor_Normal>().Is_Empty = true;
        Floor_Stand.GetComponent<Floor_Normal>().Object_Up = null;
        Floor_Stand = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now);
        Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty = false;
        Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Object_Up = gameObject;
    }

    void Change_Sprite()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)transform.position.y;
        switch (Dir)
        {
            case 1:
                GetComponent<Animator>().runtimeAnimatorController = Anim[0];
                break;
            case 2:
                GetComponent<Animator>().runtimeAnimatorController = Anim[1];
                break;
            case 3:
                GetComponent<Animator>().runtimeAnimatorController = Anim[2];
                break;
            case 4:
                GetComponent<Animator>().runtimeAnimatorController = Anim[3];
                break;
        }
        //Debug.Log(GetComponent<Animator>().GetBool("Attack"));
        if (transform.position == Destination && !GetComponent<Animator>().GetBool("Is_Attacking"))
        {
            GetComponent<Animator>().speed = 0f;
            GetComponent<Animator>().Play(0);
        }
        else
        {
            GetComponent<Animator>().speed = 2f;
        }
    }

    void OnApplicationQuit()
    {

        Is_Closing = true;

    }

    private void OnDestroy()
    {

        if (!Is_Closing)
        {
            GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Object_Up = null;
            GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty = true;

            for (int i = 0; i <= UnityEngine.Random.Range(1, 3); i++)
            {
                temp_I = Instantiate(Meat, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp_I.transform.localScale /= 0.09f;
                temp_I.name = Meat.name;
            }
            for (int i = 0; i <= UnityEngine.Random.Range(1, 2); i++)
            {
                temp_I = Instantiate(Pock_Knuckle, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp_I.transform.localScale /= 0.09f;
                temp_I.name = Pock_Knuckle.name;
            }
            GetComponent<Object_Normal>().Creature_Manager.GetComponent<Creature_Manager>().Remove_Creature(GetComponent<Object_Normal>().Creature_Num, gameObject.name);
        }
    }
}
