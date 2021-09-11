using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night_Mask : MonoBehaviour {

    GameObject Player, Calendar;
    public Sprite[] Dark;
    SpriteRenderer Sprite_Renderer;
    public int Darkness = 3;

    void Start()
    {
        Player = GameObject.Find("Player");
        Calendar = GameObject.Find("Calendar");
        Sprite_Renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (Calendar.GetComponent<Calendar>().Day_Night == "Day")
        {
            Sprite_Renderer.sprite = Dark[0];
        }
        else 
        {
            if (Darkness== 0)
            {
                Sprite_Renderer.sprite = Dark[0];
            }
            else if (Darkness == 1)
            {
                Sprite_Renderer.sprite = Dark[1];
            }
            else if (Darkness == 2)
            {
                Sprite_Renderer.sprite = Dark[2];
            }
            else
            {
                Sprite_Renderer.sprite = Dark[3];
            }
        }
        Darkness = 3;
        
    }
}
