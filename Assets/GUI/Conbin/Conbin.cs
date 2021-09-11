using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conbin : MonoBehaviour {

    GameObject Item_Manager;

    void Start () {
        if (!GameObject.Find("God").GetComponent<God>().God_Mod)
        {
            gameObject.SetActive(false);
        }
        Item_Manager = GameObject.Find("Item_Manager");
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Item_Manager.GetComponent<Item_Manager>().God_Item_Combin(transform.GetChild(2).GetComponent<Text>().text);
            transform.GetChild(2).GetComponent<Text>().text = " ";
        }
	}
}
