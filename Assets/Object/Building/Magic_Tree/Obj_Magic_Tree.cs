using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Magic_Tree : MonoBehaviour
{

    public GameObject Branch, temp;
    bool Is_Closing = false;
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
            for (int i = 0; i <= Random.Range(2, 5); i++)
            {
                temp = Instantiate(Branch, transform.position, transform.rotation, GetComponent<Object_Normal>().Floor_creat.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
                temp.transform.localScale /= 0.09f;
                temp.name = Branch.name;
            }
        }
    }
}
