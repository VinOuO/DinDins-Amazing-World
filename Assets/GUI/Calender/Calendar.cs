using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Calendar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //public GameObject Floor_creater;
    public GameObject Weather_Manager;
    public int Year, Day, Round, Round_Today, Round_Last;
    public string Season, Day_Night;
    Vector3 Pointer_Rotation;
    public Sprite Sprite_Day, Sprite_Night;
    //------------------------------------------------------GUI adject
    Vector2 GUI_W_H;
    Vector3 GUI_Pos;
    bool Mouse_On = false;
    Vector3 GUI_Scale;
    public string Weather = "None";
    //------------------------------------------------------GUI adject
    void Start()
    {
        //Year = Day = Round = 0;
        //Season = "Spring";
        //Day_Night = "Day";
        Round_Today = Round_Last = Round;
        /*
        //------------------------------------------------------GUI adject
        GUI_W_H.Set(Screen.width/10, Screen.width / 10);
        GUI_Pos.Set(Screen.width / 2 - Screen.width / 20, Screen.height / 2 - Screen.width / 20, 0);
        //GUI_Pos.Set(0, 0, 0);
        //------------------------------------------------------GUI adject
        //------------------------------------------------------GUI adject
        transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = GUI_W_H;
        transform.GetChild(1).gameObject.GetComponent<RectTransform>().sizeDelta = GUI_W_H;
        transform.GetChild(2).gameObject.GetComponent<RectTransform>().sizeDelta = GUI_W_H;
        transform.GetChild(3).gameObject.GetComponent<RectTransform>().sizeDelta = GUI_W_H;
        transform.GetChild(4).gameObject.GetComponent<RectTransform>().sizeDelta = GUI_W_H;
        transform.GetChild(5).gameObject.GetComponent<RectTransform>().sizeDelta = GUI_W_H;
        GetComponent<RectTransform>().localPosition = GUI_Pos;
        //------------------------------------------------------GUI adject
        */
        //------------------------------------------------------GUI adject
        GUI_Pos.Set(Screen.width / 2, Screen.height / 2, 0);
        //GUI_Pos.Set(0, 0, 0);
        GUI_Scale.Set((float)Screen.width / 1000 * 0.6f, (float)Screen.width / 1000 * 0.6f, 1);
        GetComponent<RectTransform>().localScale = GUI_Scale;
        GetComponent<RectTransform>().localPosition = GUI_Pos;
        //------------------------------------------------------GUI adject
    }

    void Update()
    {
        Pointer_Rotation.Set(0,0,(float)Round / 600 * -360);
        transform.GetChild(2).gameObject.GetComponent<RectTransform>().localEulerAngles = Pointer_Rotation;


        if (Round_Today >= 600)
        {
            Round_Today = 0;
            Day++;
            Weather_Effect();
        }

        if (Day_Night =="Day" && Round_Today >= 400)
        {
            Day_Night = "Night";
            transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Sprite_Night;
        }
        else if(Day_Night == "Night" && Round_Today < 400)
        {
            Day_Night = "Day";
            transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Sprite_Day;
        }

        if (Day < 10)
        {
            if(Season != "Spring")
                Season = "Spring";
        }
        else if (Day < 20)
        {
            if (Season != "Summer")
                Season = "Summer";
        }
        else if (Day < 30)
        {
            if (Season != "Autumn")
                Season = "Autumn";
        }
        else if (Day < 40)
        {
            if (Season != "Winter")
                Season = "Winter";
        }

        if (Day >= 40)
        {
            Day = 0;
            Year++;
        }

        if (Round_Last != Round)
        {
            Round_Last = Round;
            Round_Today++;
        }
    }

    public void Weather_Effect()
    {
        switch (Season)
        {
            case "Spring":
                if (Random.Range(0, 100) >= 5)
                {
                    Weather = "Rain";
                }
                else
                {
                    Weather = "None";
                }
                break;
        }
        Weather_Manager.GetComponent<Weather_Manager>().Weather_Contral(Weather);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Mouse_On = true;
        transform.GetChild(3).GetComponent<Text>().text = "" + Season;
        transform.GetChild(4).GetComponent<Text>().text = "" + Day;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Mouse_On = false;
        transform.GetChild(3).GetComponent<Text>().text = "";
        transform.GetChild(4).GetComponent<Text>().text = "";
    }
}
