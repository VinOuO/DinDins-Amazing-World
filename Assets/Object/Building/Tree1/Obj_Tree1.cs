using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Tree1 : MonoBehaviour {
    bool Is_Closing = false;
    GameObject Calender;
    public GameObject Tree_Stump, Branch, Wood, Seed, temp;
    Animator Tree1_Animator;
    //public Sprite[] Grow_State;
    SpriteRenderer Tree1_SR;
    public RuntimeAnimatorController[] Tree1_Anim;
    public int Tree_Size = 1;
    public int Start_Round;
    void Start()
    {
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Tree1_SR = GetComponent<SpriteRenderer>();
        Tree1_Animator = GetComponent<Animator>();
        Change_Sprite();
        if (Calender.GetComponent<Calendar>().Round <= 5)
        {
            Tree_Size = 2;
            Change_Sprite();
            Tree1_Animator.SetFloat("Offset", Random.Range(0, 1.0f));
            Start_Round = -1800;
        }
        else
        {
            Tree1_Animator.SetFloat("Offset", Random.Range(0, 1.0f));
            Start_Round = Calender.GetComponent<Calendar>().Round;
        }

    }

    void Update()
    {
        if (Tree_Size == 1)
        {
            Debug.Log(Calender.GetComponent<Calendar>().Round - Start_Round);
        }
        if (Calender.GetComponent<Calendar>().Round - Start_Round >= 20 && Tree_Size == 1)
        {
            Tree_Size = 2;
            Change_Sprite();
        }


        if (GetComponent<Object_Normal>().Health <= 0)
        {
            Destroy(gameObject);
        }

    }
    void Change_Sprite()
    {
        Tree1_SR.sortingOrder = -(int)transform.position.y;
        switch (Tree_Size)
        {
            case 1:
                Tree1_Animator.runtimeAnimatorController = Tree1_Anim[0];
                break;
            case 2:
                Tree1_Animator.runtimeAnimatorController = Tree1_Anim[1];
                break;
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
            if (GetComponent<Object_Normal>().Health <= 0)
            {
                temp = Instantiate(Tree_Stump, transform.position, transform.rotation);
                GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Object_Up = temp;
                temp.name = Tree_Stump.name;
            }
            for (int i = 0; i <= Random.Range(2, 5); i++)
            {
                temp = Instantiate(Branch, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp.transform.localScale /= 0.09f;
                temp.name = Branch.name;
            }
            for (int i = 0; i <= Random.Range(1, 5); i++)
            {
                temp = Instantiate(Wood, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp.transform.localScale /= 0.09f;
                temp.name = Wood.name;
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
