using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Tesla_Tower : MonoBehaviour
{

    public GameObject Little_Rock, temp;
    public int Tower_ID = 0;
    public GameObject Match_Tower;
    public bool Is_Matching = false;
    public GameObject Lightning_Wall, Lightning_Wall_2;
    bool Is_Closing = false;
    bool Main_Tower = false;
    void Start()
    {
    }

    void Update()
    {
        if (GetComponent<Object_Normal>().Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public GameObject Matching_Tower(GameObject _Match_Tower)
    {
        Vector3 _temp = Vector3.zero;
        if (_Match_Tower != null && _Match_Tower != gameObject && !_Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching && !Is_Matching)
        {
            if (_Match_Tower.transform.position.y == transform.position.y)
            {
                if(_Match_Tower.transform.position.x - transform.position.x >= 2)
                {
                    for(int i =  (int)transform.position.x+1; i <= (int)_Match_Tower.transform.position.x - 1; i++)
                    {
                        _temp.Set(i, transform.position.y, 0);
                        Instantiate(Lightning_Wall, _temp, Lightning_Wall.transform.rotation, transform);
                    }
                    Is_Matching = true;
                    Match_Tower = _Match_Tower;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching = true;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Match_Tower = gameObject;
                    Main_Tower = true;
                    return null;
                }
                else if(_Match_Tower.transform.position.x - transform.position.x <= -2)
                {
                    for (int i = (int)transform.position.x -1; i >= (int)_Match_Tower.transform.position.x +1; i--)
                    {
                        _temp.Set(i, transform.position.y, 0);
                        Instantiate(Lightning_Wall, _temp, Lightning_Wall.transform.rotation, transform);
                    }
                    Is_Matching = true;
                    Match_Tower = _Match_Tower;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching = true;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Match_Tower = gameObject;
                    Main_Tower = true;
                    return null;
                }
            }
            else if (_Match_Tower.transform.position.x == transform.position.x)
            {
                if (_Match_Tower.transform.position.y - transform.position.y >= 2)
                {
                    for (int i = (int)transform.position.y + 1; i <= (int)_Match_Tower.transform.position.y - 1; i++)
                    {
                        _temp.Set(transform.position.x, i, 0);
                        Instantiate(Lightning_Wall_2, _temp, Lightning_Wall.transform.rotation, transform);
                    }
                    Is_Matching = true;
                    Match_Tower = _Match_Tower;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching = true;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Match_Tower = gameObject;
                    Main_Tower = true;
                    return null;
                }
                else if (_Match_Tower.transform.position.y - transform.position.y <= -2)
                {
                    for (int i = (int)transform.position.y - 1; i >= (int)_Match_Tower.transform.position.y + 1; i--)
                    {
                        _temp.Set(transform.position.x, i, 0);
                        Instantiate(Lightning_Wall_2, _temp, Lightning_Wall.transform.rotation, transform);
                    }
                    Is_Matching = true;
                    Match_Tower = _Match_Tower;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching = true;
                    _Match_Tower.GetComponent<Obj_Tesla_Tower>().Match_Tower = gameObject;
                    Main_Tower = true;
                    return null;
                }
            }
        }
        else if (Is_Matching)
        {
            if (!Main_Tower)
            {
                for (int i = 0; i < Match_Tower.transform.childCount; i++)
                {
                    Destroy(Match_Tower.transform.GetChild(i).gameObject);
                }
                Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching = false;
                Match_Tower.GetComponent<Obj_Tesla_Tower>().Match_Tower = null;
                Is_Matching = false;
                Match_Tower = null;
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
                Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching = false;
                Match_Tower.GetComponent<Obj_Tesla_Tower>().Match_Tower = null;
                Is_Matching = false;
                Match_Tower = null;
            }
            return _Match_Tower;
        }
        return gameObject;
    }

    void OnApplicationQuit()
    {

        Is_Closing = true;

    }
    private void OnDestroy()
    {
        if (!Is_Closing)
        {
            if (!Main_Tower && Is_Matching)
            {
                for(int i = 0;i< Match_Tower.transform.childCount; i++)
                {
                    Destroy(Match_Tower.transform.GetChild(i).gameObject);
                }
                Match_Tower.GetComponent<Obj_Tesla_Tower>().Is_Matching = false;
                Match_Tower.GetComponent<Obj_Tesla_Tower>().Match_Tower = null;
            }
            GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Object_Up = null;
            GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty = true;
            for (int i = 0; i <= Random.Range(2, 5); i++)
            {
                temp = Instantiate(Little_Rock, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp.transform.localScale /= 0.09f;
                temp.name = Little_Rock.name;
            }
        }
    }
}
