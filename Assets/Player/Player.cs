using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {
    bool Is_Closing = false;
    /// <summary>
    /// 日歷
    /// </summary>
    public GameObject Calender;
    public GameObject Floor_creater;
    GameObject Obj_Manager;

    //--------------------------------------素質
    public float Health = 500, health;
    public float Hunger = 200, hunger;
    public float Sanity = 100, sanity;
    //--------------------------------------素質

    public GameObject Mini_Map_Camera;
    /// <summary>
    /// 玩家剛體
    /// </summary>
    Rigidbody2D Player_Rigidbody;
    /// <summary>
    /// 背包
    /// </summary>
    public GameObject Back_Pack;
    /// <summary>
    /// 玩家Sprite
    /// </summary>
    SpriteRenderer Player_Sprite_Renderer;
    public Sprite[] Player_Sprite = new Sprite[4];
    /// <summary>
    /// 玩家Anim
    /// </summary>
    Animator Player_Animator;
    public RuntimeAnimatorController[] Player_Anim;
    /// <summary>
    /// 是否有目的地
    /// </summary>
    public bool Is_Going_Somewhere;
    /// <summary>
    /// 目的地
    /// </summary>
    public Vector3 Destination;
    public int Dir,Last_Press_Dir;
    /// <summary>
    /// 走路速度
    /// </summary>
    float Speed, Speed_Default;
    /// <summary>
    /// 目前所在地形
    /// </summary>
    string Floor_Now;
    public int Class_Now = 3;
    public GameObject Floor_Stand;
    Vector3 temp;
    public GameObject Tesla_Tower_Last;

    public bool Is_Glowing;

    public int Player_Round;
    public bool Round_Attack, Round_Move;
    public bool Swing_Tool = false;

    int Effect_Round = 0;
    int teemp = 0;
    public int Marmot_Kill = 0;

	void Start () {
        Obj_Manager = GameObject.Find("Object_Manager");
        Player_Rigidbody = GetComponent<Rigidbody2D>();
        Player_Sprite_Renderer = GetComponent<SpriteRenderer>();
        Player_Animator = GetComponent<Animator>();
        Floor_creater = GameObject.Find("Floor_creater");
        Back_Pack = GameObject.Find("Back_Pack");

        Floor_Stand = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now);
        Floor_Stand.GetComponent<Floor_Normal>().Is_Empty = false;
        Floor_Stand.GetComponent<Floor_Normal>().Object_Up = gameObject;
        Player_Round = Calender.GetComponent<Calendar>().Round;
        Round_Move = Round_Attack = false;
        Is_Going_Somewhere = false;
        //Is_Glowing = true;
        Speed = Speed_Default = 2;
        Floor_Now = "None";
        Destination = transform.position;
        Last_Press_Dir = 0;
        Dir = 0;
        health = Health;
        hunger = Hunger;
        sanity = Sanity;
    }
	
	void Update () {
        Floor_Effect();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //Mini_Map(Input.GetKey(KeyCode.Tab));
        if (Player_Round == Calender.GetComponent<Calendar>().Round && !Swing_Tool)
        {
            if (Is_Going_Somewhere)
            {
                Move(Speed);
            }
            else
            {
                teemp = UnityEngine.Random.Range(0, 100);
                if (sanity / Sanity <= 0.5f && teemp > 100 * (sanity / Sanity) && Input.anyKey)
                {
                    teemp = UnityEngine.Random.Range(0, 100);
                    if (teemp <= 15)
                    {
                        Destination += Vector3.left;
                        Is_Going_Somewhere = true;
                    }
                    else if (teemp <= 30)
                    {
                        Destination += Vector3.right;
                        Is_Going_Somewhere = true;
                    }
                    else if (teemp <= 45)
                    {
                        Destination += Vector3.up;
                        Is_Going_Somewhere = true;
                    }
                    else if (teemp <= 60)
                    {
                        Destination += Vector3.down;
                        Is_Going_Somewhere = true;
                    }
                    else
                    {
                        Use_Tool();
                        Player_Round++;
                    }
                }
                else
                {
                    Player_Control();
                }
            }
        }

        if (Calender.GetComponent<Calendar>().Round - Effect_Round >= 1)
        {
            Effect_Round = Calender.GetComponent<Calendar>().Round;
            HSH_Effect();
        }

        Change_Sprite();

        if (!Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                health -= 5;
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                hunger -= 5;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                sanity -= 5;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                health += 5;
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                hunger += 5;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                sanity += 5;
            }
        }

    }

    void HSH_Effect()
    {
        if (hunger < 0)
        {
            hunger = 0;
        }
        if (sanity < 0)
        {
            sanity = 0;
        }
        switch(Calender.GetComponent<Calendar>().Weather)
        {
            case "Rain":
                sanity--;
                break;
        }
        hunger--;
        if (hunger / Hunger <= 0.3)
        {
            sanity--;
        }
        if (hunger <= 0)
        {
            health--;
        }
    }

    void Player_Control()
    {
        //----------------------------------------------------------------------移動
        if (!Is_Going_Somewhere)
        {
            temp.Set((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y), (int)Math.Round(transform.position.z));
            Destination = temp;
            if (Input.GetKeyDown(KeyCode.A) || Last_Press_Dir == 1)
            {
                Destination += Vector3.left;
                Is_Going_Somewhere = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Last_Press_Dir == 2)
            {
                Destination += Vector3.right;
                Is_Going_Somewhere = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) || Last_Press_Dir == 3)
            {
                Destination += Vector3.up;
                Is_Going_Somewhere = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Last_Press_Dir == 4)
            {
                Destination += Vector3.down;
                Is_Going_Somewhere = true;
            }
            /*
            if(Last_Press_Dir != 0)
            {
                Last_Press_Dir = 0;
            }
            */
        }
        else
        {
            /*
            if (Input.GetKeyDown(KeyCode.A))
            {
                Last_Press_Dir = 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Last_Press_Dir = 2;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Last_Press_Dir = 3;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Last_Press_Dir = 4;
            }
            */
        }
        //----------------------------------------------------------------------移動

        //----------------------------------------------------------------------撿東西
        if (Input.GetKey(KeyCode.Space) && !Is_Going_Somewhere)
        {
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                Pick_Up(0);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Dir = 1;
                Pick_Up(1);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                Dir = 2;
                Pick_Up(2);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                Dir = 3;
                Pick_Up(3);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Dir = 4;
                Pick_Up(4);
            }
        }
        //----------------------------------------------------------------------撿東西

        //----------------------------------------------------------------------用工具
        if (!Input.GetKey(KeyCode.Space) && !Is_Going_Somewhere)
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Dir = 1;
                Use_Tool();
                Player_Round++;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                Dir = 2;
                Use_Tool();
                Player_Round++;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                Dir = 3;
                Use_Tool();
                Player_Round++;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Dir = 4;
                Use_Tool();
                Player_Round++;
            }
        }
        //----------------------------------------------------------------------用工具
    }

    void Move(float _Speed)
    {
        if (Vector3.Distance(transform.position, Destination) > 0.1f)
        {
            if (transform.position.x != Destination.x)
            {
                if (transform.position.x < Destination.x)
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Destination, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        Player_Rigidbody.MovePosition(transform.position + Vector3.right * _Speed * Time.deltaTime);
                    }
                    else
                    {
                        Destination = transform.position;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        Player_Round++;
                    }
                    Dir = 2;
                }
                else
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Destination, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        Player_Rigidbody.MovePosition(transform.position + Vector3.left * _Speed * Time.deltaTime);
                    }
                    else
                    {
                        Destination = transform.position;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        Player_Round++;
                    }
                    Dir = 1;
                }
            }
            else
            {
                if (transform.position.y < Destination.y)
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Destination, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        Player_Rigidbody.MovePosition(transform.position + Vector3.up * _Speed * Time.deltaTime);
                    }
                    else
                    {
                        Destination = transform.position;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        Player_Round++;
                    }
                    Dir = 3;
                }
                else
                {
                    if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Destination, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        Player_Rigidbody.MovePosition(transform.position + Vector3.down * _Speed * Time.deltaTime);
                    }
                    else
                    {
                        Destination = transform.position;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        Player_Round++;
                    }
                    Dir = 4;
                }
            }
        }
        else
        {
            transform.position = Destination;
            Is_Going_Somewhere = false;
            Floor_Change();
            Player_Round++;
        }
    }

    void Change_Sprite()
    {
        Player_Sprite_Renderer.sortingOrder = -(int)transform.position.y;
        switch (Dir)
        {
            case 1:
                Player_Animator.runtimeAnimatorController = Player_Anim[0];
                break;
            case 2:
                Player_Animator.runtimeAnimatorController = Player_Anim[1];
                break;
            case 3:
                Player_Animator.runtimeAnimatorController = Player_Anim[2];
                break;
            case 4:
                Player_Animator.runtimeAnimatorController = Player_Anim[3];
                break;
        }
        if(transform.position == Destination)
        {
            Player_Animator.speed = 0f;
            Player_Animator.Play(0);
        }
        else
        {
            Player_Animator.speed = 2f;
        }
    }

    public void Floor_Change()
    {
        Floor_Stand.GetComponent<Floor_Normal>().Is_Empty = true;
        Floor_Stand.GetComponent<Floor_Normal>().Object_Up = null;
        Floor_Stand = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now);
        Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Is_Empty = false;
        Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Object_Up = gameObject;
    }

    public void First_Class_2()
    {
        switch (Dir)
        {
            case 1:
                Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Knock_Out(2, true), GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(Obj_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Magic_Tree_Top"));
                break;
            case 2:
                Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Knock_Out(1, true), GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(Obj_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Magic_Tree_Top"));
                break;
            case 3:
                Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Knock_Out(4, true), GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(Obj_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Magic_Tree_Top"));
                break;
            case 4:
                Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Knock_Out(3, true), GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(Obj_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Magic_Tree_Top"));
                break;
        }
    }

    public Vector3 Knock_Out(int _Dir,bool _PPAP)
    {
        Vector3 _Original_Pos = transform.position;
        if (!_PPAP)
        {
            if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.up, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
            {
                if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.down, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                {
                    if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.right, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                    {
                        if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.left, Class_Now).GetComponent<Floor_Normal>().Is_Empty)
                        {
                            transform.position += Vector3.left;
                            Destination = transform.position;
                            Is_Going_Somewhere = false;
                            Destroy(Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Object_Up);
                            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Is_Empty = true;
                            Floor_Change();
                            Player_Round++;
                        }
                        else
                        {
                            transform.position += Vector3.left;
                            Destination = transform.position;
                            Is_Going_Somewhere = false;
                            Floor_Change();
                            Player_Round++;
                        }
                    }
                    else
                    {
                        transform.position += Vector3.right;
                        Destination = transform.position;
                        Is_Going_Somewhere = false;
                        Floor_Change();
                        Player_Round++;
                    }
                }
                else
                {
                    transform.position += Vector3.down;
                    Destination = transform.position;
                    Is_Going_Somewhere = false;
                    Floor_Change();
                    Player_Round++;
                }
            }
            else
            {
                transform.position += Vector3.up;
                Destination = transform.position;
                Is_Going_Somewhere = false;
                Floor_Change();
                Player_Round++;
            }
        }
        else
        {
            switch (_Dir)
            {
                case 0:
                    break;
                case 1:
                    transform.position += Vector3.left;
                    break;
                case 2:
                    transform.position += Vector3.right;
                    break;
                case 3:
                    transform.position += Vector3.up;
                    break;
                case 4:
                    transform.position += Vector3.down;
                    break;
            }
            Destination = transform.position;
            Is_Going_Somewhere = false;
            Destroy(Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Object_Up);
            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now).GetComponent<Floor_Normal>().Is_Empty = true;
            Floor_Change();
            Player_Round++;
        }
        return _Original_Pos;
    }

    void Floor_Effect()
    {
        Speed = Speed_Default;
        switch (Floor_Now)
        {
            case "Swamp":
                Speed = Speed_Default / 2;
                break;
        }
    }

    void Pick_Up(int _Dir)
    {
        if (!Is_Going_Somewhere)
        {
            GameObject _temp;
            if (_Dir == 0)
            {
                _temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, Class_Now);
            }
            else if (_Dir == 1)
            {
                _temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.left, Class_Now);
            }
            else if (_Dir == 2)
            {
                _temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.right, Class_Now);
            }
            else if (_Dir == 3)
            {
                _temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.up, Class_Now);
            }
            else
            {
                _temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position + Vector3.down, Class_Now);
            }

            if (_temp.transform.childCount > 0)
            {
                if (Back_Pack.GetComponent<Back_Pack>().Put_In(_temp.transform.GetChild(0).gameObject.name, _temp.transform.GetChild(0).GetComponent<Object_Normal>().Useage))
                {
                    Destroy(_temp.transform.GetChild(0).gameObject);
                    Player_Round++;
                }
            }
        }
    }

    void Use_Tool()
    {
        hunger--;
        if (transform.childCount > 1)
        {
            Swing_Tool = true;
            transform.GetChild(1).GetComponent<Tool_Normal>().Time_Swing = Time.time;

            transform.GetChild(1).GetComponent<Tool_Normal>().Tool_Use(transform.position, Dir, gameObject);

        }
        else
        {
            Hand_Use(transform.position, Dir);
        }
    }
    /*
    void Glow(int _Range)
    {
        Vector3 _temp = transform.position;
        if (Is_Glowing)
        {
            for(int i = -_Range; i <= _Range; i++)
            {
                for (int j = -_Range; j <= _Range; j++)
                {
                    if(Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position+Vector3.up*i+Vector3.right*j).transform.position,transform.position) < 2 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness > 2)
                    {
                        Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness = 0;
                    }
                    else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).transform.position, transform.position) < 3 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness > 3)
                    {
                        Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness = 1;
                    }
                    else if(Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).transform.position, transform.position) < 4 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness > 4)
                    {
                        Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness = 2;
                    }
                    else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).transform.position, transform.position) >= 4)
                    {
                        Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness = 3;
                    }
                }
            }
        }
    }
    */
    void Hand_Use(Vector3 _Pos, int _Dir)
    {
        GameObject _Target = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Vector3.zero, Class_Now);
        Vector3 _temp = Vector3.zero;
        switch (_Dir)
        {
            case 1:
                _temp.Set((_Pos.x - 1), _Pos.y, 0);
                break;
            case 2:
                _temp.Set((_Pos.x + 1), _Pos.y, 0);
                break;
            case 3:
                _temp.Set(_Pos.x, (_Pos.y + 1), 0);
                break;
            case 4:
                _temp.Set(_Pos.x, (_Pos.y - 1), 0);
                break;
        }
        _Target = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_temp, Class_Now);
        //Debug.Log(_Target);
        _Target.GetComponent<Floor_Normal>().Tool_Effect("Hand", 5, gameObject);

    }

    void Mini_Map(bool _Tab_Pressing)
    {
        if (_Tab_Pressing)
        {
            if (!Mini_Map_Camera.activeSelf)
            {
                Mini_Map_Camera.SetActive(true);
            }
        }
        else
        {
            if (Mini_Map_Camera.activeSelf)
            {
                Mini_Map_Camera.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Floor_Now = collision.gameObject.GetComponent<Floor_Normal>().Type;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            switch (collision.gameObject.GetComponent<Floor_Normal>().Type)
            {
                case "Swamp":
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            switch (collision.gameObject.GetComponent<Floor_Normal>().Type)
            {
                case "Swamp":
                    break;
            }
        }
    }
    void OnApplicationQuit()
    {

        Is_Closing = true;

    }
    private void OnDestroy()
    {
        Debug.Log("Why???");
        if (!Is_Closing)
        {
            Debug.Log("Why??????");
            Application.LoadLevel(2);
        }
    }
}
