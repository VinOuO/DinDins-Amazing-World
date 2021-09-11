using UnityEngine;
using System.Collections;

public class Mouse_Icon : MonoBehaviour
{
    public Texture2D[] cursorTexture;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    Vector2 hotSpot;
    bool Pressed = false;
    private void Start()
    {
        hotSpot.Set(0, 0);
        Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!Pressed)
            {
                Cursor.SetCursor(cursorTexture[1], hotSpot, cursorMode);
                Pressed = true;
            }
        }
        else
        {
            if (Pressed)
            {
                Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
                Pressed = false;
            }
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }
}