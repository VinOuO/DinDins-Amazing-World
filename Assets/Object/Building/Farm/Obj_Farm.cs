using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Farm : MonoBehaviour {
    GameObject Floor_creater, temp;
    GameObject Calender;
    public bool Is_Planted = false;
    public int Planted_Round = 0;
    public GameObject[] Crop;
    int Crop_Type = 0;
	void Start () {
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Floor_creater = GameObject.Find("Floor_creater");
        Planted_Round = Calender.GetComponent<Calendar>().Round;
    }
	
	void Update () {
        if (Calender.GetComponent<Calendar>().Round - Planted_Round >= 3 && Is_Planted)
        {
            Crop_Type = Random.Range(0, 5);
            temp = Instantiate(Crop[Crop_Type], transform.position, transform.rotation, Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, GetComponent<Object_Normal>().Class_Now).transform);
            temp.transform.localScale /= 0.09f;
            temp.name = Crop[Crop_Type].name;
            Is_Planted = false;
        }
	}
}
