using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PPAP : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (Input.GetKey(KeyCode.S))
            {
                GameObject.Find("God").GetComponent<God>().Simple_Mod = true;
            }
            if (Input.GetKey(KeyCode.G))
            {
                GameObject.Find("God").GetComponent<God>().God_Mod = true;
            }
            Application.LoadLevel(1);
        }
	}
}
