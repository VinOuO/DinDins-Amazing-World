using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Floor_crtater : MonoBehaviour {

    public bool Is_Loading = false, Is_All_Set;
    public int Grid_X_Num, Grid_Y_Num;
    public GameObject[] Floor_Type = new GameObject[10];
    public GameObject Fog, Night_Mask;
    public int Area_Num;
    int[,] Grid_Type;   //0 = water 1 = earth 2 = grass 3 = sand 4 = swamp 5 = lava
    int[,] Grid_Type_Last;
    //int Type_Num;
    float Floor_Size = 1;
    GameObject Player, Floor_Creat;
    public float Loading_Percent = 0;
    public bool[] Class_Created;
    public int[] Type_Num;
    public int Class_Creating = 3;
    public int Floor_Num = 0;
    public int Floor_Run_ID = 0;

    public GameObject[,] Floor_1, Floor_2, Floor_3, Floor_4, Floor_5, Night_Mask_t_1, Night_Mask_t_2, Night_Mask_t_3, Night_Mask_t_4, Night_Mask_t_5;

	void Start () {
        Player = GameObject.Find("Player");
        //Type_Num = 5;
        Grid_Type = new int[Grid_X_Num, Grid_Y_Num];
        Grid_Type_Last = new int[Grid_X_Num, Grid_Y_Num];

        Floor_1 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Floor_2 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Floor_3 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Floor_4 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Floor_5 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Night_Mask_t_1 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Night_Mask_t_2 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Night_Mask_t_3 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Night_Mask_t_4 = new GameObject[Grid_X_Num, Grid_Y_Num];
        Night_Mask_t_5 = new GameObject[Grid_X_Num, Grid_Y_Num];

        GameObject.Find("GUI").transform.GetChild(4).gameObject.SetActive(true);
        Reset_Grid_Type();
        Set_Grid_Type(Area_Num, 3, 4);
        Creat_Floor(3);
        //StartCoroutine(Start_Creat_Floor(3, 0, 0));
        GameObject.Find("GUI").transform.GetChild(4).gameObject.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Transfer_To_World(4, new Vector3(1, 1, 0));
        }
	}

    public void Transfer_To_World(int _Class,Vector3 _Pos)
    {
        if (!Class_Created[_Class])
        {
            //
            Reset_Grid_Type();
            Set_Grid_Type(Area_Num, _Class,2);
            StartCoroutine(Start_Creat_Floor(_Class, 0, 0));
            //
            Player.transform.position = _Pos + Vector3.right * (_Class - 1) * 1000;
            Player.GetComponent<Player>().Destination = Player.transform.position;
            Player.GetComponent<Player>().Is_Going_Somewhere = false;
        }
        else
        {
            Player.transform.position = _Pos + Vector3.right * (_Class - 1) * 1000;
            Debug.Log("Pos_Back: " + Player.transform.position);
            Player.GetComponent<Player>().Destination = Player.transform.position;
            Player.GetComponent<Player>().Is_Going_Somewhere = false;
            Player.GetComponent<Player>().Class_Now = _Class;
            switch (Player.GetComponent<Player>().Dir)
            {
                case 1:
                    Player.GetComponent<Player>().Knock_Out(2, true);
                    break;
                case 2:
                    Player.GetComponent<Player>().Knock_Out(1, true);
                    break;
                case 3:
                    Player.GetComponent<Player>().Knock_Out(4, true);
                    break;
                case 4:
                    Player.GetComponent<Player>().Knock_Out(3, true);
                    break;
            }
            Player.GetComponent<Player>().Floor_Change();
        }
    }

    void Player_Change_Class()
    {
        Player.GetComponent<Player>().Is_Going_Somewhere = false;
        Player.GetComponent<Player>().Floor_Change();
        Player.GetComponent<Player>().Class_Now = 1;
        Player.transform.position = new Vector3(25, 25, 0);
        Player.GetComponent<Player>().Destination = Player.transform.position;
    }

    void Reset_Grid_Type()
    {
        for (int i = 0; i < Grid_X_Num; i++)
        {
            for (int j = 0; j < Grid_Y_Num; j++)
            {
                Grid_Type[i, j] = 0;
                Grid_Type_Last[i, j] = 0;
            }
        }
    }

    void Set_Grid_Type_Last()
    {
        for (int i = 0; i < Grid_X_Num; i++)
        {
            for (int j = 0; j < Grid_Y_Num; j++)
            {
                Grid_Type_Last[i, j] = Grid_Type[i, j];
            }
        }
    }

    void Set_Grid_Type(int _Area_Num,int _Class,int _Type_Num)
    {
        int k = 1;
        Vector2 _Area_Center = Vector2.zero;
        bool _Is_All_Set = false;
        float _Start_Time;
        _Start_Time = Time.time;

        if (!Is_Loading)
        {
            //Is_Loading = true;
        }

        //-------------------------------------------------選擇中心點以及種類
        if (_Class == 3)
        {
            Grid_Type[(int)Player.transform.position.x - (_Class-1) * 1000, (int)Player.transform.position.y] = 11;
        }
        while (k < _Area_Num)
        {
            _Area_Center.Set(UnityEngine.Random.Range(0, Grid_X_Num), UnityEngine.Random.Range(0, Grid_Y_Num));
            if (Grid_Type[(int)_Area_Center.x, (int)_Area_Center.y] == 0)
            {
                //Grid_Type[(int)_Area_Center.x, (int)_Area_Center.y] = (k % Type_Num) + 1;
                Grid_Type[(int)_Area_Center.x, (int)_Area_Center.y] = UnityEngine.Random.Range(1 + (_Class - 1) * 5, _Type_Num + (_Class - 1) * 5 + 1);
                k++;
            }
        }
        //-------------------------------------------------選擇中心點以及種類
        Set_Grid_Type_Last();
        //-------------------------------------------------從中心拓展
        int Run = 0;
        while (!_Is_All_Set && Run <= 100000)
        {
            _Is_All_Set = true;
            Run++;
            //---------------------------------------------
            for (int i = 0; i < Grid_X_Num; i++)
            {
                for (int j = 0; j < Grid_Y_Num; j++)
                {
                    int[] _Type_Around = new int[4];
                    int _Type_Around_Num = 0;
                    if (Grid_Type[i, j] == 0)
                    {
                        //---檢查上下左右的種類
                        for (int _i = -1; _i <= 1; _i += 2)
                        {
                            if (_i + i >= 0 && _i + i < Grid_X_Num)
                                if (Grid_Type[_i + i, j] != 0)
                                {
                                    _Type_Around[_Type_Around_Num] = Grid_Type_Last[_i + i, j];
                                    _Type_Around_Num++;
                                }
                        }
                        for (int _j = -1; _j <= 1; _j += 2)
                        {
                            if (_j + j >= 0 && _j + j < Grid_Y_Num)
                                if (Grid_Type[i, _j + j] != 0)
                                {
                                    _Type_Around[_Type_Around_Num] = Grid_Type_Last[i, _j + j];
                                    _Type_Around_Num++;
                                }
                        }
                        //---檢查上下左右的種類
                        if (_Type_Around_Num > 0)
                        {
                            Grid_Type[i, j] = _Type_Around[UnityEngine.Random.Range(0, _Type_Around_Num)];
                        }
                    }
                    if (Grid_Type[i, j] == 0)
                    {
                        _Is_All_Set = false;
                    }
                }
            }
            //---------------------------------------------
            Set_Grid_Type_Last();
        }

        //-------------------------------------------------從中心拓展
        /*
        for (int i = 0; i < Grid_X_Num; i++)
        {
            Grid_Type[i, 0] = 0;
            Grid_Type[0, i] = 0;
            Grid_Type[Grid_X_Num - 1, i] = 0;
            Grid_Type[i, Grid_X_Num - 1] = 0;
        }
        */
    }
    void Creat_Floor(int _Class)
    {
        bool _Is_Down = false;
        int i = 0, j = 0;
        Vector3 Floor_Pos;
        Class_Creating = _Class;
        Floor_Pos = Vector3.zero;
        for (i = 0; i < Grid_X_Num; i++)
        {
            for (j = 0; j < Grid_Y_Num; j++)
            {
                Floor_Pos.x = i * Floor_Size + (_Class - 1) * 1000;
                Floor_Pos.y = j * Floor_Size;

                switch (Grid_Type[i, j])
                {
                    case 0:
                        Floor_Creat = Instantiate(Floor_Type[0], Floor_Pos, transform.rotation);
                        break;
                    case 1:
                        Floor_Creat = Instantiate(Floor_Type[1], Floor_Pos, transform.rotation);
                        break;
                    case 2:
                        Floor_Creat = Instantiate(Floor_Type[2], Floor_Pos, transform.rotation);
                        break;
                    case 3:
                        Floor_Creat = Instantiate(Floor_Type[3], Floor_Pos, transform.rotation);
                        break;
                    case 4:
                        Floor_Creat = Instantiate(Floor_Type[4], Floor_Pos, transform.rotation);
                        break;
                    case 5:
                        Floor_Creat = Instantiate(Floor_Type[5], Floor_Pos, transform.rotation);
                        break;
                    case 6:
                        Floor_Creat = Instantiate(Floor_Type[6], Floor_Pos, transform.rotation);
                        break;
                    case 7:
                        Floor_Creat = Instantiate(Floor_Type[7], Floor_Pos, transform.rotation);
                        break;
                    case 8:
                        Floor_Creat = Instantiate(Floor_Type[8], Floor_Pos, transform.rotation);
                        break;
                    case 9:
                        Floor_Creat = Instantiate(Floor_Type[9], Floor_Pos, transform.rotation);
                        break;
                    case 10:
                        Floor_Creat = Instantiate(Floor_Type[10], Floor_Pos, transform.rotation);
                        break;
                    case 11:
                        Floor_Creat = Instantiate(Floor_Type[11], Floor_Pos, transform.rotation);
                        break;
                    case 12:
                        Floor_Creat = Instantiate(Floor_Type[12], Floor_Pos, transform.rotation);
                        break;
                    case 13:
                        Floor_Creat = Instantiate(Floor_Type[13], Floor_Pos, transform.rotation);
                        break;
                    case 14:
                        Floor_Creat = Instantiate(Floor_Type[14], Floor_Pos, transform.rotation);
                        break;
                    case 15:
                        Floor_Creat = Instantiate(Floor_Type[15], Floor_Pos, transform.rotation);
                        break;
                }

                Floor_Creat.name = "Class_" + _Class + "_Floor_" + i + "_" + j;
                Floor_Creat.GetComponent<Floor_Normal>().Class_Now = _Class;
                Floor_Creat.GetComponent<Floor_Normal>().Floor_ID = Floor_Num;
                Floor_Num++;
                if (i == 0 || j == 0 || i == Grid_X_Num - 1 || j == Grid_Y_Num - 1)
                {
                    Floor_Creat.GetComponent<Floor_Normal>().Is_Edge = true;
                }

                switch (_Class)
                {
                    case 1:
                        Floor_1[i, j] = Floor_Creat;
                        Night_Mask_t_1[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                        //Instantiate(Fog, Floor_Pos, transform.rotation);
                        break;
                    case 2:
                        Floor_2[i, j] = Floor_Creat;
                        Night_Mask_t_2[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                        //Instantiate(Fog, Floor_Pos, transform.rotation);
                        break;
                    case 3:
                        Floor_3[i, j] = Floor_Creat;
                        Night_Mask_t_3[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                        //Instantiate(Fog, Floor_Pos, transform.rotation);
                        break;
                    case 4:
                        Floor_4[i, j] = Floor_Creat;
                        Night_Mask_t_4[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                        //Instantiate(Fog, Floor_Pos, transform.rotation);
                        break;
                    case 5:
                        Floor_5[i, j] = Floor_Creat;
                        Night_Mask_t_5[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                        //Instantiate(Fog, Floor_Pos, transform.rotation);
                        break;
                }

            }
        }
    }


    Vector2 Creat_Floor2(int _Class,float _Start_x,float _Start_y)
    {
        int i = 0, j = 0;
        float _End_x, _End_y;
        Vector3 Floor_Pos;
        Class_Creating = _Class;
        Floor_Pos = Vector3.zero;
        _End_x = _Start_x;
        _End_y = _Start_y;
        if ((int)_End_x == Grid_X_Num)
        {
            _Start_y++;
            _End_y++;
            _Start_x = _End_x = 0;
            if ((int)_End_y == Grid_Y_Num)
            {
                return Vector2.zero;
            }
        }
        _End_x += 5;
        if (_End_x> Grid_X_Num)
        {
            _End_x = Grid_X_Num;
        }
        j = (int)_Start_y;
        for (i = (int)_Start_x; i < (int)_End_x; i++)
        {
            Floor_Pos.x = i * Floor_Size + (_Class - 1) * 1000;
            Floor_Pos.y = j * Floor_Size;
            switch (Grid_Type[i, j])
            {
                case 0:
                    Floor_Creat = Instantiate(Floor_Type[0], Floor_Pos, transform.rotation);
                    break;
                case 1:
                    Floor_Creat = Instantiate(Floor_Type[1], Floor_Pos, transform.rotation);
                    break;
                case 2:
                    Floor_Creat = Instantiate(Floor_Type[2], Floor_Pos, transform.rotation);
                    break;
                case 3:
                    Floor_Creat = Instantiate(Floor_Type[3], Floor_Pos, transform.rotation);
                    break;
                case 4:
                    Floor_Creat = Instantiate(Floor_Type[4], Floor_Pos, transform.rotation);
                    break;
                case 5:
                    Floor_Creat = Instantiate(Floor_Type[5], Floor_Pos, transform.rotation);
                    break;
                case 6:
                    Floor_Creat = Instantiate(Floor_Type[6], Floor_Pos, transform.rotation);
                    break;
                case 7:
                    Floor_Creat = Instantiate(Floor_Type[7], Floor_Pos, transform.rotation);
                    break;
                case 8:
                    Floor_Creat = Instantiate(Floor_Type[8], Floor_Pos, transform.rotation);
                    break;
                case 9:
                    Floor_Creat = Instantiate(Floor_Type[9], Floor_Pos, transform.rotation);
                    break;
                case 10:
                    Floor_Creat = Instantiate(Floor_Type[10], Floor_Pos, transform.rotation);
                    break;
                case 11:
                    Floor_Creat = Instantiate(Floor_Type[11], Floor_Pos, transform.rotation);
                    break;
                case 12:
                    Floor_Creat = Instantiate(Floor_Type[12], Floor_Pos, transform.rotation);
                    break;
                case 13:
                    Floor_Creat = Instantiate(Floor_Type[13], Floor_Pos, transform.rotation);
                    break;
                case 14:
                    Floor_Creat = Instantiate(Floor_Type[14], Floor_Pos, transform.rotation);
                    break;
                case 15:
                    Floor_Creat = Instantiate(Floor_Type[15], Floor_Pos, transform.rotation);
                    break;
                case 16:
                    Floor_Creat = Instantiate(Floor_Type[16], Floor_Pos, transform.rotation);
                    break;
                case 17:
                    Floor_Creat = Instantiate(Floor_Type[17], Floor_Pos, transform.rotation);
                    break;
                case 18:
                    Floor_Creat = Instantiate(Floor_Type[18], Floor_Pos, transform.rotation);
                    break;
                case 19:
                    Floor_Creat = Instantiate(Floor_Type[19], Floor_Pos, transform.rotation);
                    break;
                case 20:
                    Floor_Creat = Instantiate(Floor_Type[20], Floor_Pos, transform.rotation);
                    break;
                case 21:
                    Floor_Creat = Instantiate(Floor_Type[21], Floor_Pos, transform.rotation);
                    break;
                case 22:
                    Floor_Creat = Instantiate(Floor_Type[22], Floor_Pos, transform.rotation);
                    break;
                case 23:
                    Floor_Creat = Instantiate(Floor_Type[23], Floor_Pos, transform.rotation);
                    break;
                case 24:
                    Floor_Creat = Instantiate(Floor_Type[24], Floor_Pos, transform.rotation);
                    break;
                case 25:
                    Floor_Creat = Instantiate(Floor_Type[25], Floor_Pos, transform.rotation);
                    break;
            }

            Floor_Creat.name = "Class_" + _Class + "_Floor_" + i + "_" + j;
            Floor_Creat.GetComponent<Floor_Normal>().Class_Now = _Class;
            Floor_Creat.GetComponent<Floor_Normal>().Floor_ID = Floor_Num;
            Floor_Num++;
            Debug.Log(Floor_Creat.name);
            switch (_Class)
            {
                case 1:
                    Floor_1[i, j] = Floor_Creat;
                    Night_Mask_t_1[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                    //Instantiate(Fog, Floor_Pos, transform.rotation);
                    break;
                case 2:
                    Floor_2[i, j] = Floor_Creat;
                    Night_Mask_t_2[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                    //Instantiate(Fog, Floor_Pos, transform.rotation);
                    break;
                case 3:
                    Floor_3[i, j] = Floor_Creat;
                    Night_Mask_t_3[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                    //Instantiate(Fog, Floor_Pos, transform.rotation);
                    break;
                case 4:
                    Floor_4[i, j] = Floor_Creat;
                    Night_Mask_t_4[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                    //Instantiate(Fog, Floor_Pos, transform.rotation);
                    break;
                case 5:
                    Floor_5[i, j] = Floor_Creat;
                    Night_Mask_t_5[i, j] = Instantiate(Night_Mask, Floor_Pos, transform.rotation);
                    //Instantiate(Fog, Floor_Pos, transform.rotation);
                    break;
            }
        }
        return new Vector2(_End_x, _End_y);
    }

    IEnumerator Start_Creat_Floor(int _Class, float _Start_x, float _Start_y)
    {
        Vector2 _pos;
        yield return new WaitForSeconds(0.00001f * Grid_X_Num);
        _pos = Creat_Floor2(_Class, _Start_x, _Start_y);
        if (_pos != Vector2.zero)
        {
            if (!Is_Loading)
            {
                Is_Loading = true;
            }
            StartCoroutine(Start_Creat_Floor(_Class, _pos.x, _pos.y));
            Loading_Percent = (_pos.y * Grid_X_Num + _pos.x) / (Grid_X_Num * Grid_Y_Num) * 100;
        }
        else
        {
            Is_Loading = false;
            Player.GetComponent<Player>().Class_Now = _Class;
            Player.GetComponent<Player>().Knock_Out(0, true);
            Player.GetComponent<Player>().Floor_Change();
            if (!Class_Created[_Class])
            {
                Class_Created[_Class] = true;
                if (_Class == 2)
                {
                    Player.GetComponent<Player>().First_Class_2();
                }
            }
            StopCoroutine(Start_Creat_Floor(_Class, _Start_x, _Start_y));
        }
    }

    public GameObject Floor_Find(Vector3 _Pos,int _Class)
    {
        Vector3 _temp;
        
        _temp = _Pos;
        if ((int)Math.Round(_temp.x) < (_Class - 1) * 1000)
        {
            _temp.x = (_Class-1) * 1000;
        }
        else if ((int)Math.Round(_temp.x) >= Grid_X_Num + (_Class - 1) * 1000)
        {
            _temp.x = Grid_X_Num - 1 + (_Class - 1) * 1000;
        }
        if ((int)Math.Round(_temp.y) < 0)
        {
            _temp.y = 0;
        }
        else if ((int)Math.Round(_temp.y) >= Grid_Y_Num)
        {
            _temp.y = Grid_Y_Num - 1;
        }

        switch (_Class)
        {
            case 1:
                return Floor_1[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 2:
                return Floor_2[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 3:
                return Floor_3[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 4:
                return Floor_4[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 5:
                return Floor_5[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
        }
        return Floor_1[1, 1];
    }
    public GameObject Night_Mask_Find(Vector3 _Pos, int _Class)
    {
        Vector3 _temp;

        _temp = _Pos;
        if ((int)Math.Round(_temp.x) < (_Class - 1) * 1000)
        {
            _temp.x = (_Class - 1) * 1000;
        }
        else if ((int)Math.Round(_temp.x) >= Grid_X_Num + (_Class - 1) * 1000)
        {
            _temp.x = Grid_X_Num - 1 + (_Class - 1) * 1000;
        }
        if ((int)Math.Round(_temp.y) < 0)
        {
            _temp.y = 0;
        }
        else if ((int)Math.Round(_temp.y) >= Grid_Y_Num)
        {
            _temp.y = Grid_Y_Num - 1;
        }

        switch (_Class)
        {
            case 1:
                return Night_Mask_t_1[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 2:
                return Night_Mask_t_2[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 3:
                return Night_Mask_t_3[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 4:
                return Night_Mask_t_4[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
            case 5:
                return Night_Mask_t_5[(int)Math.Round(_temp.x - (_Class - 1) * 1000), (int)Math.Round(_temp.y)];
        }
        return Night_Mask_t_1[1, 1];
    }
    /*
    public GameObject Night_Mask_Find(Vector3 _Pos)
    {
        if ((int)Math.Round(_Pos.x) >= 0 && (int)Math.Round(_Pos.y) >= 0 && (int)Math.Round(_Pos.x) < Grid_X_Num && (int)Math.Round(_Pos.y) < Grid_Y_Num)
        {
            return Night_Mask_t[(int)Math.Round(_Pos.x), (int)Math.Round(_Pos.y)];
        }
        else
        {
            return Night_Mask_t[0, 0];
        }
    }
    */
}
