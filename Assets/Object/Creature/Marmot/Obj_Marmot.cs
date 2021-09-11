using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obj_Marmot : MonoBehaviour
{
    GameObject Calender;
    bool Is_Closing = false;
    public Vector3 Destination, Attack_Target_Pos, Last_Pos, LLast_Pos, temp, Target;
    public GameObject Floor_creater, Rock, Rock_Bullet;
    public GameObject Meat, Pock_Knuckle, temp_I;
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
    public bool Is_Digging;
    public bool Player_Hurted = false;
    public int Dig_Round;
    public int Rock_Num = 0 ,Stuck_Round = 0;
    int Shoot_Round = 0;
    int Anger_Round = 0;
    void Start()
    {
        Floor_creater = GameObject.Find("Floor_creater");
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Screen_Pos = Camera.main.WorldToScreenPoint(transform.position);
        Can_Pass_1 = Can_Pass_2 = Can_Pass_3 = Can_Pass_4 = true;
        LLast_Pos = Last_Pos = Destination = transform.position;
        Is_Going_Somewhere = false;
        Is_Out_Of_Screen = false;
        Is_Digging = false;
        Dir = 1;
        Speed = 2f;
        Move_State = "None";
        Dig_Round = Calender.GetComponent<Calendar>().Round;
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

        if (!Is_Digging)
        {
            Change_Sprite();
        }

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
                else if (Calender.GetComponent<Calendar>().Round - Dig_Round >= 5)
                {
                    Move_State = "Dig";
                }
                else
                {
                    Move_State = "None";
                }

                if (Move_State == "None" || Move_State == "Dig")
                {
                    Search("Obj_Little_Rock");
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
                    case "Searching":
                        if (Vector3.Distance(Floor_Stand.transform.position, Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Target, GetComponent<Object_Normal>().Class_Now).transform.position) < 1 && Floor_Stand.transform.position == transform.position)
                        {
                            if (Target.x < transform.position.x)
                            {
                                Dir = 1;
                            }
                            else if (Target.x > transform.position.x)
                            {
                                Dir = 2;
                            }
                            else if (Target.y > transform.position.y)
                            {
                                Dir = 3;
                            }
                            else
                            {
                                Dir = 4;
                            }
                            for (int k = 0; k < Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Target, GetComponent<Object_Normal>().Class_Now).transform.childCount; k++)
                            {
                                if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Target, GetComponent<Object_Normal>().Class_Now).transform.GetChild(k).gameObject.name == "Obj_Little_Rock")
                                {
                                    Destroy(Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Target, GetComponent<Object_Normal>().Class_Now).transform.GetChild(k).gameObject);
                                    Rock_Num++;
                                }
                            }
                            Move_State = "None";
                            GetComponent<Object_Normal>().Obj_Round = false;
                        }
                        else
                        {
                            Move_Point(Target);
                        }
                        if (Stuck_Round > 5)
                        {
                            Move_State = "None";
                        }
                        break;
                    case "Attacking":
                        if (Attack_Target == null)
                        {
                            Anger = 0;
                            break;
                        }
                        if (Shoot_Round != Calender.GetComponent<Calendar>().Round)
                        {
                            if (Rock_Num <= 0)
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
                                    Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Attack_Target.transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Tool_Effect("None", 5, gameObject);
                                    Anger = 10;
                                    GetComponent<Object_Normal>().Obj_Round = false;

                                }
                                else
                                {
                                    Move_Point(Attack_Target.transform.position);
                                }
                            }
                            else
                            {
                                if (!Is_Digging)
                                {
                                    if (transform.position.y == Attack_Target.transform.position.y)
                                    {
                                        if (Attack_Target.transform.position.x < transform.position.x)
                                        {
                                            Dir = 1;
                                            Rock = Instantiate(Rock_Bullet, transform.position + Vector3.left, transform.rotation);
                                            Rock.GetComponent<Rock_Bullet>().Dir = Dir;
                                        }
                                        else
                                        {
                                            Dir = 2;
                                            Rock = Instantiate(Rock_Bullet, transform.position + Vector3.right, transform.rotation);
                                            Rock.GetComponent<Rock_Bullet>().Dir = Dir;
                                        }
                                        Rock.GetComponent<Rock_Bullet>().Shooter = gameObject;
                                        Rock.GetComponent<Rock_Bullet>().Is_Out_Of_Screen = Is_Out_Of_Screen;
                                        Shoot_Round = Calender.GetComponent<Calendar>().Round;
                                        Rock_Num--;
                                    }
                                    else if (transform.position.x == Attack_Target.transform.position.x)
                                    {
                                        if (Attack_Target.transform.position.y > transform.position.y)
                                        {
                                            Dir = 3;
                                            Rock = Instantiate(Rock_Bullet, transform.position + Vector3.up, transform.rotation);
                                            Rock.GetComponent<Rock_Bullet>().Dir = Dir;
                                        }
                                        else
                                        {
                                            Dir = 4;
                                            Rock = Instantiate(Rock_Bullet, transform.position + Vector3.down, transform.rotation);
                                            Rock.GetComponent<Rock_Bullet>().Dir = Dir;
                                        }
                                        Rock.GetComponent<Rock_Bullet>().Shooter = gameObject;
                                        Rock.GetComponent<Rock_Bullet>().Is_Out_Of_Screen = Is_Out_Of_Screen;
                                        Shoot_Round = Calender.GetComponent<Calendar>().Round;
                                        Rock_Num--;
                                        Anger = 10;
                                    }
                                    else
                                    {
                                        if (!Is_Digging)
                                        {
                                            if (!Is_Out_Of_Screen)
                                            {
                                                StartCoroutine(Dig(0));
                                                Is_Digging = true;
                                            }
                                            else
                                            {
                                                Dig_Random();
                                                GetComponent<Object_Normal>().Obj_Round = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "Dig":
                        if (!Is_Digging)
                        {
                            if (!Is_Out_Of_Screen)
                            {
                                StartCoroutine(Dig(0));
                                Is_Digging = true;
                            }
                            else
                            {
                                Dig_Random();
                                GetComponent<Object_Normal>().Obj_Round = false;
                                Dig_Round = Calender.GetComponent<Calendar>().Round;
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
    void Search(String _Obj_Name)
    {
        Vector3 _temp = transform.position, _min = Vector3.zero;
        for(int i = -5; i <= 5; i++)
        {
            for(int j = -5; j <= 5; j++)
            {
                _temp.Set(transform.position.x + i, transform.position.y + j, 0);
                for(int k=0;k < Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_temp, GetComponent<Object_Normal>().Class_Now).transform.childCount; k++)
                {
                    if(Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_temp, GetComponent<Object_Normal>().Class_Now).transform.GetChild(k).gameObject.name == _Obj_Name)
                    {
                        Move_State = "Searching";
                        if(Vector3.Distance(_min,transform.position)> Vector3.Distance(_temp, transform.position))
                        {
                            _min = _temp;
                        }
                    }
                }
            }
        }
        Target = _min;
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
        /*
        if (transform.position == Destination)
        {
            GetComponent<Animator>().speed = 0f;
            GetComponent<Animator>().Play(0);
        }
        else
        {
            GetComponent<Animator>().speed = 2f;
        }
        */
    }

    void Dig_Anim()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)transform.position.y;
        switch (Dir)
        {
            case 1:
                GetComponent<Animator>().runtimeAnimatorController = Anim[5];
                break;
            case 2:
                GetComponent<Animator>().runtimeAnimatorController = Anim[6];
                break;
            case 3:
                GetComponent<Animator>().runtimeAnimatorController = Anim[7];
                break;
            case 4:
                GetComponent<Animator>().runtimeAnimatorController = Anim[8];
                break;
        }
        if (transform.position == Destination)
        {
            GetComponent<Animator>().speed = 0f;
            GetComponent<Animator>().Play(0);
        }
        else
        {
            GetComponent<Animator>().speed = 1f;
        }
    }

    IEnumerator Dig(int _state)
    {
        AnimatorClipInfo[] m_CurrentClipInfo;

        Debug.Log(_state);
        //Debug.Log(m_CurrentClipInfo[0].clip.length);

        if (_state == 0)
        {
            switch (Dir)
            {
                case 1:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[4];
                    break;
                case 2:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[5];
                    break;
                case 3:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[6];
                    break;
                case 4:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[7];
                    break;
            }
            m_CurrentClipInfo = this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);

            GetComponent<Animator>().Play(0, 0, m_CurrentClipInfo[0].clip.length);

            GetComponent<Animator>().speed = 0.7f;
            GetComponent<Animator>().SetFloat("Speed_M", -1f);


            _state++;

            yield return new WaitForSeconds(m_CurrentClipInfo[0].clip.length * 10/7);
            StartCoroutine(Dig(_state));
        }
        else if (_state == 1)
        {
            int _try = 0;
            GetComponent<SpriteRenderer>().sortingOrder = 100000;
            _state++;

            //----------------------------------------------------------------------隨機鑽出
            if (Move_State != "Attacking")
            {
                switch (Dir)
                {
                    case 0:
                        temp.Set(UnityEngine.Random.Range(transform.position.x - 2, transform.position.x - 5), transform.position.y, 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(UnityEngine.Random.Range(transform.position.x - 2, transform.position.x - 5), transform.position.y, 0);
                        }
                        break;
                    case 1:
                        temp.Set(UnityEngine.Random.Range(transform.position.x + 2, transform.position.x + 5), transform.position.y, 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(UnityEngine.Random.Range(transform.position.x + 2, transform.position.x + 5), transform.position.y, 0);
                        }
                        break;
                    case 2:
                        temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y + 2, transform.position.y + 5), 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y + 2, transform.position.y + 5), 0);
                        }
                        break;
                    case 3:
                        temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y - 2, transform.position.y - 5), 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y - 2, transform.position.y - 5), 0);
                        }
                        break;
                }
            }
            else
            {
                switch (UnityEngine.Random.Range(0, 5))
                {
                    case 0:
                        temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x - 2, Attack_Target.transform.position.x - 5), Attack_Target.transform.position.y, 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x - 2, Attack_Target.transform.position.x - 5), Attack_Target.transform.position.y, 0);
                        }
                        break;
                    case 1:
                        temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x + 2, Attack_Target.transform.position.x + 5), Attack_Target.transform.position.y, 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x + 2, Attack_Target.transform.position.x + 5), Attack_Target.transform.position.y, 0);
                        }
                        break;
                    case 2:
                        temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y + 2, Attack_Target.transform.position.y + 5), 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y + 2, Attack_Target.transform.position.y + 5), 0);
                        }
                        break;
                    case 3:
                        temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y - 2, Attack_Target.transform.position.y - 5), 0);
                        while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                        {
                            _try++;
                            temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y - 2, Attack_Target.transform.position.y - 5), 0);
                        }
                        break;
                }
            }
            if (_try <= 30)
            {
                temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).transform.position;
                transform.position = temp;
                Floor_Change();
            }

            //----------------------------------------------------------------------隨機鑽出
            yield return new WaitForSeconds(2);
            StartCoroutine(Dig(_state));
        }
        else if (_state==2)
        {
            GetComponent<SpriteRenderer>().sortingOrder = -(int)transform.position.y;
            switch (Dir)
            {
                case 1:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[4];
                    break;
                case 2:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[5];
                    break;
                case 3:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[6];
                    break;
                case 4:
                    GetComponent<Animator>().runtimeAnimatorController = Anim[7];
                    break;
            }
            m_CurrentClipInfo = this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
            GetComponent<Animator>().speed = 0.7f;
            GetComponent<Animator>().Play(0);
            GetComponent<Animator>().SetFloat("Speed_M", 1f);
            _state++;
            //位移
            yield return new WaitForSeconds(m_CurrentClipInfo[0].clip.length*10/7);
            StartCoroutine(Dig(_state));
        }
        else if (_state == 3)
        {
            GetComponent<Object_Normal>().Obj_Round = false;
            Is_Digging = false;
            Dig_Round = Calender.GetComponent<Calendar>().Round;
            StopCoroutine(Dig(_state));
        }
    }
    void Dig_Random()
    {
        int _try = 0;
        if (Move_State != "Attacking")
        {
            switch (Dir)
            {
                case 0:
                    temp.Set(UnityEngine.Random.Range(transform.position.x - 2, transform.position.x - 5), transform.position.y, 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(UnityEngine.Random.Range(transform.position.x - 2, transform.position.x - 5), transform.position.y, 0);
                    }
                    break;
                case 1:
                    temp.Set(UnityEngine.Random.Range(transform.position.x + 2, transform.position.x + 5), transform.position.y, 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(UnityEngine.Random.Range(transform.position.x + 2, transform.position.x + 5), transform.position.y, 0);
                    }
                    break;
                case 2:
                    temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y + 2, transform.position.y + 5), 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y + 2, transform.position.y + 5), 0);
                    }
                    break;
                case 3:
                    temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y - 2, transform.position.y - 5), 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(transform.position.x, UnityEngine.Random.Range(transform.position.y - 2, transform.position.y - 5), 0);
                    }
                    break;
            }
        }
        else
        {
            switch (UnityEngine.Random.Range(0, 5))
            {
                case 0:
                    temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x - 2, Attack_Target.transform.position.x - 5), Attack_Target.transform.position.y, 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x - 2, Attack_Target.transform.position.x - 5), Attack_Target.transform.position.y, 0);
                    }
                    break;
                case 1:
                    temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x + 2, Attack_Target.transform.position.x + 5), Attack_Target.transform.position.y, 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x + 2, Attack_Target.transform.position.x + 5), Attack_Target.transform.position.y, 0);
                    }
                    break;
                case 2:
                    temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y + 2, Attack_Target.transform.position.y + 5), 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y + 2, Attack_Target.transform.position.y + 5), 0);
                    }
                    break;
                case 3:
                    temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y - 2, Attack_Target.transform.position.y - 5), 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y - 2, Attack_Target.transform.position.y - 5), 0);
                    }
                    break;
            }
        }
        if (_try <= 30)
        {
            temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp, GetComponent<Object_Normal>().Class_Now).transform.position;
            transform.position = temp;
            Floor_Change();
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
            if (Player_Hurted)
            {
                GetComponent<Object_Normal>().Player.GetComponent<Player>().Marmot_Kill++;
            }

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

/*
  switch (UnityEngine.Random.Range(0, 5))
            {
                case 0:
                    temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x - 2, Attack_Target.transform.position.x - 5), Attack_Target.transform.position.y, 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try ++;
                        temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x - 2, Attack_Target.transform.position.x - 5), Attack_Target.transform.position.y, 0);
                    }
                    break;
                case 1:
                    temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x + 2, Attack_Target.transform.position.x + 5), Attack_Target.transform.position.y, 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(UnityEngine.Random.Range(Attack_Target.transform.position.x + 2, Attack_Target.transform.position.x + 5), Attack_Target.transform.position.y, 0);
                    }
                    break;
                case 2:
                    temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y + 2, Attack_Target.transform.position.y + 5), 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y + 2, Attack_Target.transform.position.y + 5), 0);
                    }
                    break;
                case 3:
                    temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y - 2, Attack_Target.transform.position.y - 5), 0);
                    while (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(temp).GetComponent<Floor_Normal>().Is_Empty && _try <= 30)
                    {
                        _try++;
                        temp.Set(Attack_Target.transform.position.x, UnityEngine.Random.Range(Attack_Target.transform.position.y - 2, Attack_Target.transform.position.y - 5), 0);
                    }
                    break;
            }
*/
