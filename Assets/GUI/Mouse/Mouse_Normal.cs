using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Normal : MonoBehaviour {

    public GameObject Floor_creater, Player, temp;

    void Start () {
        Player = GameObject.Find("Player");
        Floor_creater = GameObject.Find("Floor_creater");

    }

	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if (Vector3.Distance(Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Camera.main.ScreenToWorldPoint(Input.mousePosition), Player.GetComponent<Player>().Class_Now).transform.position, Player.transform.position) <= 1)
            {
                if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Camera.main.ScreenToWorldPoint(Input.mousePosition), Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty && transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Name == "Obj_Branch")
                {
                    temp = Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Camera.main.ScreenToWorldPoint(Input.mousePosition), Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up;
                    if (temp.name == "Obj_Wood_Fire")
                    {
                        Debug.Log("Burn!");
                        transform.GetChild(1).GetComponent<Mouse_Box_Normal>().Item_Give_Take(-1, 0);
                        temp.GetComponent<Obj_Wood_Fire>().Start_to_Burn(1);
                    }
                }
            }
        }
	}
}
