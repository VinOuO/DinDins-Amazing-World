using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour {

    GameObject Player;
    Vector3 _temp;
	void Start () {
        Player = GameObject.Find("Player");
        _temp = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        _temp.x = Player.transform.position.x;
        transform.position = _temp;
	}
}
