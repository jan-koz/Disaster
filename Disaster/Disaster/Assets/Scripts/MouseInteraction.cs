using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D hoverCursorTexture;
    public Texture2D handCursorTexture;
    private Ray ray;
    // public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;
    private void Start()
    {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseEnter()
    {
        if (gameObject.tag == "hover")
            Cursor.SetCursor(hoverCursorTexture, Vector2.zero, CursorMode.ForceSoftware);

        else
            Cursor.SetCursor(handCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
}
