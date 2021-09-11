using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_Normal : MonoBehaviour {

    public int Range;
    public float Time_Swing;
    Vector3 Tool_Rotate, Hand_Pos_FB, Hand_Pos_LR;
    GameObject Floor_creater, temp;
	void Start () {
        Floor_creater = GameObject.Find("Floor_creater");
        Time_Swing = -1;
        Tool_Rotate = Vector3.zero;
        Hand_Pos_FB.Set(-2.53f, 1.81f, 0);
        Hand_Pos_LR.Set(0, 1.4f, 0);

    }

    void Update() {
        Anim();
    }

    public void Tool_Use(Vector3 _Pos, int _Dir,GameObject _User)
    {
        GameObject _Target = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Vector3.zero ,3);
        Vector3 _temp = Vector3.zero;
        for(int i = 1; i <= Range; i++)
        {
            switch (_Dir)
            {
                case 1:
                    _temp.Set((_Pos.x - i), _Pos.y, 0);
                    break;
                case 2:
                    _temp.Set((_Pos.x + i), _Pos.y, 0);
                    break;
                case 3:
                    _temp.Set(_Pos.x, (_Pos.y + i), 0);
                    break;
                case 4:
                    _temp.Set(_Pos.x, (_Pos.y - i), 0);
                    break;
            }
            if (_User.name == "Player")
            {
                _Target = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_temp,_User.GetComponent<Player>().Class_Now);
            }
            else
            {
                _Target = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(_temp,_User.GetComponent<Object_Normal>().Class_Now);
            }

            Debug.Log(_Target);
            switch (gameObject.name)
            {
                case "Tool_Axe":
                    _Target.GetComponent<Floor_Normal>().Tool_Effect("Chop", 20, _User);
                    break;
                case "Tool_Pick":
                    _Target.GetComponent<Floor_Normal>().Tool_Effect("PickAxe", 20, _User);
                    break;
                case "Tool_Shovel":
                    _Target.GetComponent<Floor_Normal>().Tool_Effect("Dig", 1000, _User);
                    break;
                case "Tool_Corkong_Hammer":
                    _Target.GetComponent<Floor_Normal>().Tool_Effect("Knock", 1000, _User);
                    break;
                case "Tool_Lightning_Staff":
                    switch (_User.GetComponent<Player>().Dir)
                    {
                        case 1:
                            temp = Instantiate(GetComponent<Tool_Lightning_Staff>().Lightning_Ball, _Pos + Vector3.left, transform.rotation);
                            break;
                        case 2:
                            temp = Instantiate(GetComponent<Tool_Lightning_Staff>().Lightning_Ball, _Pos + Vector3.right, transform.rotation);
                            break;
                        case 3:
                            temp = Instantiate(GetComponent<Tool_Lightning_Staff>().Lightning_Ball, _Pos + Vector3.up, transform.rotation);
                            break;
                        case 4:
                            temp = Instantiate(GetComponent<Tool_Lightning_Staff>().Lightning_Ball, _Pos + Vector3.down, transform.rotation);
                            break;
                    }
                    temp.GetComponent<Lightning_Ball>().Dir = _User.GetComponent<Player>().Dir;
                    temp.GetComponent<Lightning_Ball>().Shooter = _User;
                    temp.GetComponent<Lightning_Ball>().Is_Out_Of_Screen = false;
                    break;
            }
        }
    }



    void Anim()
    {
        GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<SpriteRenderer>().sortingOrder + 1;
        if (Time.time - Time_Swing <= 0.5f)
        {
            if (transform.parent.GetComponent<Player>().Dir == 1 || transform.parent.GetComponent<Player>().Dir == 2)
            {
                Tool_Rotate.z = 20;
            }
            else
            {
                Tool_Rotate.z = -80;
            }
        }
        else
        {
            if (transform.parent.GetComponent<Player>().Swing_Tool)
            {
                Tool_Rotate.z = -30;
                if (gameObject.name != "Tool_Lightning_Staff")
                {
                    transform.parent.GetComponent<Player>().Swing_Tool = false;
                    transform.parent.GetComponent<Player>().Back_Pack.transform.GetChild(11).transform.GetChild(1).GetComponent<Weapen_Normal>().Weapen_Use();
                }
            }
        }


        if (transform.parent.GetComponent<Player>().Dir == 1)
        {
            transform.localPosition = Hand_Pos_LR;
            Tool_Rotate.y = 0;
        }
        else if (transform.parent.GetComponent<Player>().Dir == 2)
        {
            transform.localPosition = Hand_Pos_LR;
            Tool_Rotate.y = 180;
            GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
        else if (transform.parent.GetComponent<Player>().Dir == 3)
        {
            Tool_Rotate.y = 0;
            transform.localPosition = Hand_Pos_FB;
            GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
        else
        {
            Tool_Rotate.y = 0;
            transform.localPosition = Hand_Pos_FB;
        }
        transform.eulerAngles = Tool_Rotate;
    }

}
