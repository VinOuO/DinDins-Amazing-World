using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Berry_Tree : MonoBehaviour {

    GameObject Calender;
    bool Is_Closing = false;
    public GameObject Branch, Seed, temp;
    public GameObject[] Berry;
    public Sprite[] Grow_State;
    SpriteRenderer Berry_Tree_SR;
    public int Tree_State = 0;
    public int Start_Round;

    void Start()
    {
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Berry_Tree_SR = GetComponent<SpriteRenderer>();
        Change_Sprite();
        if (Calender.GetComponent<Calendar>().Round <= 5)
        {
            Tree_State = Random.Range(1, 4);
            Change_Sprite();
            Start_Round = -1800;
        }
        else
        {
            Start_Round = Calender.GetComponent<Calendar>().Round;
        }

    }

    void Update()
    {
        if (Calender.GetComponent<Calendar>().Round - Start_Round >= 20 && Tree_State == 0)
        {
            Tree_State = Random.Range(1, 4);
            Change_Sprite();
        }


        if (GetComponent<Object_Normal>().Health <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnApplicationQuit()
    {

        Is_Closing = true;

    }


    void Change_Sprite()
    {
        Berry_Tree_SR.sortingOrder = -(int)transform.position.y;
        switch (Tree_State)
        {
            case 0:
                Berry_Tree_SR.sprite = Grow_State[0];
                break;
            case 1:
                Berry_Tree_SR.sprite = Grow_State[1];
                break;
            case 2:
                Berry_Tree_SR.sprite = Grow_State[2];
                break;
            case 3:
                Berry_Tree_SR.sprite = Grow_State[3];
                break;
        }

    }

    public void Drop_Berry()
    {
        if (Tree_State > 0)
        {
            for (int i = 0; i <= Random.Range(1, 3); i++)
            {
                temp = Instantiate(Berry[Tree_State - 1], transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp.transform.localScale /= 0.09f;
                temp.name = Berry[Tree_State - 1].name;
            }
            Start_Round = Calender.GetComponent<Calendar>().Round;
            Tree_State = 0;
            Change_Sprite();
        }
    }

    private void OnDestroy()
    {
        if (!Is_Closing)
        {
            GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Object_Up = null;
            GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Empty = true;
            for (int i = 0; i <= Random.Range(2, 5); i++)
            {
                temp = Instantiate(Branch, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp.transform.localScale /= 0.09f;
                temp.name = Branch.name;
            }
            for (int i = 0; i <= Random.Range(0, 3); i++)
            {
                temp = Instantiate(Seed, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp.transform.localScale /= 0.09f;
                temp.name = Seed.name;
            }
        }
    }

}
