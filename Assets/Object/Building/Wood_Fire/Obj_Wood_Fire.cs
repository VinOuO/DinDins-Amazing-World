using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Wood_Fire : MonoBehaviour {
    GameObject Calender;
    public int Burn_Round;
    bool Burning = false;

    void Start () {
        //gameObject.GetComponent<Object_Normal>().Is_Glowing = true;
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Burn_Round = -1800;
        Start_to_Burn(4);
    }

	void Update () {
        if (Calender.GetComponent<Calendar>().Round - Burn_Round >= 10)
        {
            Burn();
        }
        if (gameObject.GetComponent<Object_Normal>().Fire_Size > 1 && !Burning)
        {
            Start_to_Burn(gameObject.GetComponent<Object_Normal>().Fire_Size);
        }
	}

    public void Start_to_Burn(int _Fire_Size)
    {
        Burning = true;
        gameObject.GetComponent<Object_Normal>().Is_Glowing = true;
        gameObject.GetComponent<Object_Normal>().Is_On_Fire = true;
        Burn_Round = Calender.GetComponent<Calendar>().Round;
        gameObject.GetComponent<Object_Normal>().Fire_Size += _Fire_Size;
        if (gameObject.GetComponent<Object_Normal>().Fire_Size > 6)
        {
            gameObject.GetComponent<Object_Normal>().Fire_Size = 6;
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void Burn()
    {
        Burn_Round = Calender.GetComponent<Calendar>().Round;
        gameObject.GetComponent<Object_Normal>().Fire_Size--;
        if(gameObject.GetComponent<Object_Normal>().Fire_Size <= 1)
        {
            Burning = false;
            gameObject.GetComponent<Object_Normal>().Is_Glowing = false;
            gameObject.GetComponent<Object_Normal>().Is_On_Fire = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
