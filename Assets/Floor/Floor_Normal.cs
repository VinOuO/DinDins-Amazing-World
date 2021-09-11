using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Floor_Normal : MonoBehaviour {

    GameObject Player, Creature_Manager;
    public string Type;
    public Sprite Fog, Floor_Sprite;
    public bool Is_Empty,Is_Cover_By_Fog;
    public bool Is_Zapping = false;
    /// <summary>
    /// 這個地板上的物件
    /// </summary>
    public GameObject Object_Up;
    /// <summary>
    /// 自然生成物件
    /// </summary>
    public int Spawn_Obj_Num;
    public GameObject[] Spawn_Obj;
    public GameObject Creat_Obj;
    GameObject Calender;
    /// <summary>
    /// 地板上的建築
    /// </summary>
    //public GameObject Building_Up;
    SpriteRenderer Sprite_Renderer;
    GameObject Floor_creater;
    public int Class_Now = 3;
    int Floor_Effect_Round = 0;
    int Floor_Spown_Round = 0;
    public int Floor_ID;
    Vector3 Screen_Pos;
    bool Is_Out_Of_Screen;
    public bool Is_Edge = false;
    void Start () {
        Player = GameObject.Find("Player");
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Creature_Manager = GameObject.Find("Creature_Manager");
        Floor_creater = GameObject.Find("Floor_creater");
        Sprite_Renderer = GetComponent<SpriteRenderer>();
        Floor_creater = GameObject.Find("Floor_creater");

        Is_Empty = true;
        //-------------------------------CoverByFog
        Sprite_Renderer.sprite = Fog;
        Sprite_Renderer.sortingOrder = 5000;
        Is_Cover_By_Fog = true;
        //-------------------------------CoverByFog
        transform.localScale = Vector3.one * 0.1f;
        if (Random.Range(0, 100) >= 80 && Spawn_Obj_Num > 0 && transform.position != Player.transform.position)
        {
            Spown(Spawn_Obj[Random.Range(0, Spawn_Obj_Num)]);
        }
    }

    void Update () {
        if (Object_Up == null && !Is_Empty)
        {
            Is_Empty = true;
        }
        /*
        if (transform.position == new Vector3(2024,24,0) && Input.GetKeyDown(KeyCode.N))
        {
            //Spown(Creature_Manager.GetComponent<Creature_Manager>().Creature_Prefab[5]);
        }
        */
        if (Calender.GetComponent<Calendar>().Round - Floor_Effect_Round >= 1)
        {
            Floor_Effect_Round = Calender.GetComponent<Calendar>().Round;
            Floor_Effect();
        }

        if (Floor_creater.GetComponent<Floor_crtater>().Floor_Num - Floor_creater.GetComponent<Floor_crtater>().Floor_Run_ID == Floor_ID + 1 && !GameObject.Find("God").GetComponent<God>().Simple_Mod)
        {
            Debug.Log("Hi~" + gameObject.name);
            Floor_Spown_Round = Calender.GetComponent<Calendar>().Round;
            Floor_creater.GetComponent<Floor_crtater>().Floor_Run_ID++;
            Spown_Creature();
            if(Floor_ID == 0)
            {
                Floor_creater.GetComponent<Floor_crtater>().Floor_Run_ID = 0;
            }
        }

        Glow();
        //-------------------------------UnCoverFog
        if (Vector3.Distance(Player.transform.position, transform.position) <= 10000 && Is_Cover_By_Fog)
        {
            Sprite_Renderer.sprite = Floor_Sprite;
            Sprite_Renderer.sortingOrder = -10000;
            if (Type == "Cloud" || Type == "Dark_Cloud")
            {
                transform.localScale = Vector3.one * 0.11f;
            }
            else
            {
                transform.localScale = Vector3.one * 0.095f;
            }
            Is_Cover_By_Fog = false;
        }
        //-------------------------------UnCoverFog
	}


    public void Spown(GameObject _Spown_Object)
    {
        Creat_Obj = Instantiate(_Spown_Object, transform.position, _Spown_Object.transform.rotation);
        Creat_Obj.name = _Spown_Object.name;
        if (Creat_Obj.GetComponent<Object_Normal>().Type != "Item")
        {
            Object_Up = Creat_Obj;
            Object_Up.GetComponent<Object_Normal>().Class_Now = Class_Now;
            if (Object_Up.name != "Obj_Marmot_King")
            {
                Is_Empty = false;
            }
        }
        else
        {
            Creat_Obj.transform.parent = transform;
        }
    }

    void Spown_Creature()
    {
        if (Is_Empty)
        {
            switch (Type)
            {
                case "Swamp":
                    if (Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[2] <= 10)
                    {
                        if (Random.Range(-10, 10) >= Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[2])
                        {
                            Spown(Creature_Manager.GetComponent<Creature_Manager>().Creature_Prefab[2]);
                        }
                    }
                    break;
                case "Grass":
                    if (Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[0] <= 10)
                    {
                        if (Random.Range(-10, 10) >= Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[0])
                        {
                            Spown(Creature_Manager.GetComponent<Creature_Manager>().Creature_Prefab[0]);
                        }
                    }
                    break;
                case "Sand":
                    if (Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[1] <= 10)
                    {
                        if (Random.Range(-10, 10) >= Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[1])
                        {
                            Spown(Creature_Manager.GetComponent<Creature_Manager>().Creature_Prefab[1]);
                        }
                    }
                    break;
                case "Cloud":
                    if (Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[4] <= 10)
                    {
                        if (Random.Range(-10, 10) >= Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[4])
                        {
                            Spown(Creature_Manager.GetComponent<Creature_Manager>().Creature_Prefab[4]);
                        }
                        else
                        {
                            if (Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[3] <= 10)
                            {
                                if (Random.Range(0, 10) >= Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[3])
                                {
                                    Spown(Creature_Manager.GetComponent<Creature_Manager>().Creature_Prefab[3]);
                                }
                            }
                        }
                    }
                    break;
                case "Dark_Cloud":
                    if (Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[5] <= 10)
                    {
                        if (Random.Range(-10, 10) >= Creature_Manager.GetComponent<Creature_Manager>().Creature_Type_Num[5])
                        {
                            Spown(Creature_Manager.GetComponent<Creature_Manager>().Creature_Prefab[5]);
                        }
                    }
                    break;
                case "Lava":

                    break;
            }
        }
    }

    void Floor_Effect()
    {
        if(!Is_Empty)
        {
            switch (Type)
            {
                case "Dark_Cloud":
                    if (Random.Range(0, 100) > 98)
                    {
                        if (Object_Up.name == "Player")
                        {
                            Object_Up.GetComponent<Player>().health -= 100;
                        }
                        else
                        {
                            Object_Up.GetComponent<Object_Normal>().Health -= 100;
                        }
                    }
                    break;
                case "Lava":
                    if (Object_Up.name == "Player")
                    {
                        Object_Up.GetComponent<Player>().health -= 10;
                    }
                    else
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= 10;
                    }
                    break;
            }
            if (Is_Zapping)
            {
                if (Object_Up.name == "Player")
                {
                    Object_Up.GetComponent<Player>().health -= 10;
                }
                else
                {
                    Object_Up.GetComponent<Object_Normal>().Health -= 10;
                }
            }
        }
    }
    public void Tool_Effect(string _Act ,int _Hurt, GameObject _User)
    {
        if (!Is_Empty)
        {
            switch (Object_Up.name)
            {
                case "Player":
                    Object_Up.GetComponent<Player>().health -= _Hurt;
                    if(_Act == "Knock")
                    {
                        Object_Up.GetComponent<Player>().Player_Round++;
                    }
                    break;
                case "Obj_Magic_Tree":
                    if (_Act == "Chop")
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    }
                    if (_Act == "Hand")
                    {
                        Floor_creater.GetComponent<Floor_crtater>().Transfer_To_World(2, transform.position - Vector3.right * (Class_Now - 1) * 1000);
                    }
                    break;
                case "Obj_Cave":
                    if (_Act == "Hand")
                    {
                        Floor_creater.GetComponent<Floor_crtater>().Transfer_To_World(4, transform.position - Vector3.right * (Class_Now - 1) * 1000);
                    }
                    break;
                case "Obj_Magic_Tree_Top":
                    if (_Act == "Chop")
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    }
                    if (_Act == "Hand")
                    {
                        Floor_creater.GetComponent<Floor_crtater>().Transfer_To_World(3, transform.position - Vector3.right * (Class_Now - 1) * 1000);
                    }
                    break;
                case "Obj_Tree1":
                    if (_Act == "Chop")
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    }
                    break;
                case "Obj_Tree2":
                    if (_Act == "Chop")
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    }
                    break;
                case "Obj_Rock":
                    if (_Act == "PickAxe")
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    }
                    break;
                case "Obj_Tree_Stump":
                    if (_Act == "Dig")
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    }
                    break;
                case "Obj_Pig_Man":
                    Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    Object_Up.GetComponent<Obj_Pig_Man>().Anger = 10;
                    Object_Up.GetComponent<Obj_Pig_Man>().Attack_Target = _User;
                    if (_Act == "Knock")
                    {
                        Object_Up.GetComponent<Object_Normal>().cc_Round++;
                    }
                    break;
                case "Obj_Ray":
                    Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    Object_Up.GetComponent<Obj_Ray>().Anger = 10;
                    Object_Up.GetComponent<Obj_Ray>().Attack_Target = _User;
                    if (_Act == "Knock")
                    {
                        Object_Up.GetComponent<Object_Normal>().cc_Round++;
                    }
                    break;
                case "Obj_Sheep":
                    Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    Object_Up.GetComponent<Obj_Sheep>().Anger = 10;
                    Object_Up.GetComponent<Obj_Sheep>().Attack_Target = _User;
                    if (_Act == "Knock")
                    {
                        Object_Up.GetComponent<Object_Normal>().cc_Round++;
                    }
                    break;
                case "Obj_Black_Sheep":
                    Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    Object_Up.GetComponent<Obj_Black_Sheep>().Anger = 10;
                    Object_Up.GetComponent<Obj_Black_Sheep>().Attack_Target = _User;
                    if (_Act == "Knock")
                    {
                        Object_Up.GetComponent<Object_Normal>().cc_Round++;
                    }
                    break;
                case "Obj_Marmot":
                    if (_User == Player)
                    {
                        Object_Up.GetComponent<Obj_Marmot>().Player_Hurted = true;
                    }
                    Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    Object_Up.GetComponent<Obj_Marmot>().Anger = 10;
                    Object_Up.GetComponent<Obj_Marmot>().Attack_Target = _User;
                    if (_Act == "Knock")
                    {
                        Object_Up.GetComponent<Object_Normal>().cc_Round++;
                    }
                    break;
                case "Obj_Marmot_King":
                    Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    Object_Up.GetComponent<Obj_Marmot_King>().Anger = 10;
                    Object_Up.GetComponent<Obj_Marmot_King>().Attack_Target = _User;
                    if (_Act == "Knock")
                    {
                        Object_Up.GetComponent<Object_Normal>().cc_Round++;
                    }
                    break;
                case "Obj_Crokong":
                    Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    Object_Up.GetComponent<Obj_Crokong>().Anger = 10;
                    Object_Up.GetComponent<Obj_Crokong>().Attack_Target = _User;
                    if (_Act == "Knock")
                    {
                        Object_Up.GetComponent<Object_Normal>().cc_Round++;
                    }
                    break;
                case "Obj_Berry_Tree":
                    if (_Act == "Hand")
                    {
                        Object_Up.GetComponent<Obj_Berry_Tree>().Drop_Berry();
                    }
                    if (_Act == "Chop")
                    {
                        Object_Up.GetComponent<Object_Normal>().Health -= _Hurt;
                    }
                    break;
                case "Obj_Pot":
                    if (Object_Up.GetComponent<Obj_Pot>().Is_Showing)
                    {
                        Object_Up.GetComponent<Obj_Pot>().Close();
                    }
                    else
                    {
                        Object_Up.GetComponent<Obj_Pot>().Open();
                    }
                    break;
                case "Obj_Box":
                    if (Object_Up.GetComponent<Obj_Box>().Is_Showing)
                    {
                        Object_Up.GetComponent<Obj_Box>().Close();
                    }
                    else
                    {
                        Object_Up.GetComponent<Obj_Box>().Open();
                    }
                    break;
                case "Obj_Tesla_Tower":
                    if (_Act == "Hand")
                    {
                        _User.GetComponent<Player>().Tesla_Tower_Last = Object_Up.GetComponent<Obj_Tesla_Tower>().Matching_Tower(_User.GetComponent<Player>().Tesla_Tower_Last);
                    }
                    break;
            }
        }
    }


    void Glow()
    {
        Vector3 _temp = transform.position;
        if (!Is_Empty)
        {
            if (Object_Up.name=="Player")
            {
                if (Object_Up.GetComponent<Player>().Is_Glowing) {
                    for (int i = -4; i <= 4; i++)
                    {
                        for (int j = -4; j <= 4; j++)
                        {
                            if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).transform.position, Object_Up.transform.position) < 2 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).GetComponent<Night_Mask>().Darkness > 0)
                            {
                                Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).GetComponent<Night_Mask>().Darkness = 0;
                            }
                            else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).transform.position, Object_Up.transform.position) < 3 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).GetComponent<Night_Mask>().Darkness > 1)
                            {
                                Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).GetComponent<Night_Mask>().Darkness = 1;
                            }
                            else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).transform.position, Object_Up.transform.position) < 4 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).GetComponent<Night_Mask>().Darkness > 2)
                            {
                                Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).GetComponent<Night_Mask>().Darkness = 2;
                            }
                            else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).transform.position, Object_Up.transform.position) >= 4 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Player>().Class_Now).GetComponent<Night_Mask>().Darkness > 3)
                            {
                                //Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness = 3;
                            }
                        }
                    }
                }
            }
            else
            {
                if (Object_Up.GetComponent<Object_Normal>().Is_Glowing)
                {
                    for (int i = -Object_Up.GetComponent<Object_Normal>().Fire_Size; i <= Object_Up.GetComponent<Object_Normal>().Fire_Size; i++)
                    {
                        for (int j = -Object_Up.GetComponent<Object_Normal>().Fire_Size; j <= Object_Up.GetComponent<Object_Normal>().Fire_Size; j++)
                        {
                            if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).transform.position, Object_Up.transform.position) < Object_Up.GetComponent<Object_Normal>().Fire_Size - 2 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).GetComponent<Night_Mask>().Darkness > 0)
                            {
                                Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).GetComponent<Night_Mask>().Darkness = 0;
                            }
                            else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).transform.position, Object_Up.transform.position) < Object_Up.GetComponent<Object_Normal>().Fire_Size - 1 && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).GetComponent<Night_Mask>().Darkness > 1)
                            {
                                Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).GetComponent<Night_Mask>().Darkness = 1;
                            }
                            else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).transform.position, Object_Up.transform.position) < Object_Up.GetComponent<Object_Normal>().Fire_Size && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).GetComponent<Night_Mask>().Darkness > 2)
                            {
                                Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).GetComponent<Night_Mask>().Darkness = 2;
                            }
                            else if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).transform.position, Object_Up.transform.position) >= Object_Up.GetComponent<Object_Normal>().Fire_Size && Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j, Object_Up.GetComponent<Object_Normal>().Class_Now).GetComponent<Night_Mask>().Darkness > 3)
                            {
                                //Floor_creater.GetComponent<Floor_crtater>().Night_Mask_Find(transform.position + Vector3.up * i + Vector3.right * j).GetComponent<Night_Mask>().Darkness = 3;
                            }
                        }
                    }
                }
            }
        }
    }

}
