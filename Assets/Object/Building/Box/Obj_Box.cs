using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obj_Box : MonoBehaviour
{

    public bool Is_Showing = false;
    GameObject Calender, Obj_M;
    GameObject Box, Food;
    public Sprite[] Box_Sprite;
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
        Obj_M = GameObject.Find("Object_Manager");
        Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
        Box = transform.GetChild(0).transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Is_Showing)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) > 1.05f)
            {
                Close();
            }
        }
    }

    void Show()
    {
        transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 1;
        transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.GetChild(0).GetComponent<CanvasGroup>().interactable = true;
        Is_Showing = true;
        GetComponent<SpriteRenderer>().sprite = Box_Sprite[1];
    }

    void Hide()
    {
        transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 0;
        transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.GetChild(0).GetComponent<CanvasGroup>().interactable = false;
        Is_Showing = false;
        GetComponent<SpriteRenderer>().sprite = Box_Sprite[0];
    }

    public void Open()
    {
        Show();
    }

    public void Close()
    {
        Hide();
    }
}
