using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Outline linea;

    [SerializeField] Texture2D cursorInteract;
    [SerializeField] Texture2D cursorNormal;

    [SerializeField] float tiempoRotacion;
    private void Awake()
    {
        linea = GetComponent<Outline>();
    }

    public void Interactuar(Transform interactuador)
    {
        Debug.Log("Puto!");
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y);
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
