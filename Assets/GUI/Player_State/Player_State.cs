using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_State : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string Type;
    public Sprite[] Picture;
    public Sprite[] Value;
    GameObject Player;
    public float State_Value, SValue;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {



        if (Type == "Hunger")
        {
            State_Value = Player.GetComponent<Player>().hunger / Player.GetComponent<Player>().Hunger * 100;
            SValue = Player.GetComponent<Player>().hunger;
            if (State_Value >= 100 / 9 * 9)
            {
                GetComponent<Image>().sprite = Value[9];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 8)
            {
                GetComponent<Image>().sprite = Value[8];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 7)
            {
                GetComponent<Image>().sprite = Value[7];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 6)
            {
                GetComponent<Image>().sprite = Value[6];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 5)
            {
                GetComponent<Image>().sprite = Value[5];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 4)
            {
                GetComponent<Image>().sprite = Value[4];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 3)
            {
                GetComponent<Image>().sprite = Value[3];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 2)
            {
                GetComponent<Image>().sprite = Value[2];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
            else if (State_Value >= 100 / 9 * 1)
            {
                GetComponent<Image>().sprite = Value[1];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
            else
            {
                GetComponent<Image>().sprite = Value[0];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
        }



        if (Type == "Sanity")
        {
            State_Value = Player.GetComponent<Player>().sanity / Player.GetComponent<Player>().Sanity * 100;
            SValue = Player.GetComponent<Player>().sanity;
            if (State_Value >= 100 / 9 * 9)
            {
                GetComponent<Image>().sprite = Value[9];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 8)
            {
                GetComponent<Image>().sprite = Value[8];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 7)
            {
                GetComponent<Image>().sprite = Value[7];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 6)
            {
                GetComponent<Image>().sprite = Value[6];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 5)
            {
                GetComponent<Image>().sprite = Value[5];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 4)
            {
                GetComponent<Image>().sprite = Value[4];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 3)
            {
                GetComponent<Image>().sprite = Value[3];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 2)
            {
                GetComponent<Image>().sprite = Value[2];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
            else if (State_Value >= 100 / 9 * 1)
            {
                GetComponent<Image>().sprite = Value[1];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
            else
            {
                GetComponent<Image>().sprite = Value[0];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
        }



        if (Type == "Health")
        {
            State_Value = Player.GetComponent<Player>().health / Player.GetComponent<Player>().Health * 100;
            SValue = Player.GetComponent<Player>().health;
            if (State_Value >= 100 / 9 * 9)
            {
                GetComponent<Image>().sprite = Value[9];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 8)
            {
                GetComponent<Image>().sprite = Value[8];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 7)
            {
                GetComponent<Image>().sprite = Value[7];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[2];
            }
            else if (State_Value >= 100 / 9 * 6)
            {
                GetComponent<Image>().sprite = Value[6];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 5)
            {
                GetComponent<Image>().sprite = Value[5];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 4)
            {
                GetComponent<Image>().sprite = Value[4];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 3)
            {
                GetComponent<Image>().sprite = Value[3];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[1];
            }
            else if (State_Value >= 100 / 9 * 2)
            {
                GetComponent<Image>().sprite = Value[2];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
            else if (State_Value >= 100 / 9 * 1)
            {
                GetComponent<Image>().sprite = Value[1];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
            else
            {
                GetComponent<Image>().sprite = Value[0];
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Picture[0];
            }
        }




    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hi");
        transform.GetChild(0).GetComponent<Text>().text = "" + SValue;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<Text>().text = "";
    }
}
