using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T : MonoBehaviour {

    bool updown = false;
    Color T_Color = Color.black;
    float time = 0;
	void Start () {
        GetComponent<Text>().color = T_Color;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time >= 0.1f)
        {
            time = Time.time;
            if (updown)
            {
                T_Color.a+=0.1f;
                GetComponent<Text>().color = T_Color;
                if (T_Color.a >= 1)
                {
                    updown = false;
                }
            }
            else
            {
                T_Color.a-=0.1f;
                GetComponent<Text>().color = T_Color;
                if (T_Color.a <= 0)
                {
                    updown = true;
                }
            }
            Debug.Log(T_Color.a);
        }
	}
}
