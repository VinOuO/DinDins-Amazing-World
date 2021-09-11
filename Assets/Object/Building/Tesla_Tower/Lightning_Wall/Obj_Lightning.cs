using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Lightning : MonoBehaviour {

    GameObject Floor_creater;

	void Start () {
        Floor_creater = GameObject.Find("Floor_creater");
        GetComponent<SpriteRenderer>().sortingOrder = -(int)transform.position.y;
    }
	
	void Update () {
		if(!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, transform.parent.GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Zapping)
        {
            Floor_creater.GetComponent<Floor_crtater>().Floor_Find(transform.position, transform.parent.GetComponent<Object_Normal>().Class_Now).GetComponent<Floor_Normal>().Is_Zapping = true;
        }
	}
}
