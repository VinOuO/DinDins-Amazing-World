using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

    int Class_Now = 3;

	void Start () {
		
	}
	
	void Update () {
        if (transform.parent.GetComponent<Player>().Class_Now != Class_Now)
        {
            Class_Now = transform.parent.GetComponent<Player>().Class_Now;
            if (Class_Now == 2)
            {
                GetComponent<Camera>().backgroundColor = new Color32(80, 216, 255, 0);
            }
            else
            {
                GetComponent<Camera>().backgroundColor = new Color32(101, 40, 0, 85);
            }
        }
	}
}
