using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {
    GameObject Player;

	void Start () {
        Player = GameObject.Find("Player");
	}

	void Update () {
        if (Player.GetComponent<Player>().Is_Going_Somewhere)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= 10)
            {
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Destroy(gameObject);
        }
	}
}
