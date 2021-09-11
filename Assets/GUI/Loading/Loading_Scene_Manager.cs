using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Scene_Manager : MonoBehaviour {

    GameObject Floor_Creater;

	void Start () {
        Floor_Creater = GameObject.Find("Floor_creater");
	}
	
	void Update () {
        if (Floor_Creater.GetComponent<Floor_crtater>().Class_Creating == 2)
        {
            if (transform.GetChild(0).gameObject.activeSelf != true)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            if (transform.GetChild(1).gameObject.activeSelf == true)
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        if (Floor_Creater.GetComponent<Floor_crtater>().Class_Creating == 4)
        {
            if (transform.GetChild(1).gameObject.activeSelf != true)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            if (transform.GetChild(0).gameObject.activeSelf == true)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
