using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour {
    GameObject Floor_creater;
    void Start () {
        Floor_creater = GameObject.Find("Floor_creater");
    }
	
	// Update is called once per frame
	void Update () {
        if (Floor_creater.GetComponent<Floor_crtater>().Is_Loading)
        {
            if(transform.GetChild(4).gameObject.activeSelf == false)
            {
                transform.GetChild(4).gameObject.SetActive(true);
            }
        }
        else
        {
            if (transform.GetChild(4).gameObject.activeSelf == true)
            {
                transform.GetChild(4).gameObject.SetActive(false);
            }
        }

    }
}
