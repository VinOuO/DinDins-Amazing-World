using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_Manager : MonoBehaviour {
    GameObject Calender;
    void Start () {
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
    }
	
	void Update () {

	}

    public void Weather_Contral(string _Weather)
    {
        switch (_Weather)
        {
            case "Rain":
                if (!transform.GetChild(0).gameObject.activeSelf)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                break;
            case "None":
                if (transform.GetChild(0).gameObject.activeSelf)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                break;
        }
    }
}
