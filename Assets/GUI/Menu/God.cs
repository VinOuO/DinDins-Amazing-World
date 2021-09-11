using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour {

    public bool God_Mod = false, Simple_Mod = false;
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		
	}
}
