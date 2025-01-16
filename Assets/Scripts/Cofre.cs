using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteractuable 
{
    Outline linea;

    [SerializeField] Texture2D cursorInteract;
    [SerializeField] Texture2D cursorNormal;

    public void Interactuar(Transform cofre)
    {
        
    }
    public void Interactuar()
    {
        
    }

    private void Awake()
    {
        linea = GetComponent<Outline>();
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteract, Vector2.zero, CursorMode.Auto);
        linea.enabled = true;
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);  
        linea.enabled = false;
    }

}
