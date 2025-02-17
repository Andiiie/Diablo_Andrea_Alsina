using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour,IInteractuable
{
    [SerializeField] EventManagerSO eventManager;
    [SerializeField] MisionSO misionAsociada;
    [SerializeField] DialogoSO dialogo1;
    [SerializeField] DialogoSO dialogo2;
    
    Outline linea;
    [SerializeField] DialogoSO dialogue;
    [SerializeField] Texture2D cursorInteract;
    [SerializeField] Texture2D cursorNormal;

    [SerializeField] float tiempoRotacion;
    [SerializeField] Transform cameraPoint;

    DialogoSO dialogoActual;

    private void Awake()
    {
        dialogoActual = dialogo1;
        linea = GetComponent<Outline>();
    }
    private void OnEnable()
    {
        // me suscribo al evento para estar atento de cuando cambiar el dialogo
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if (misionTerminada == misionAsociada)
        {
            dialogoActual = dialogo2;
            
        }
    }

    public void Interactuar(Transform interactuador)
    {

        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDialogo.trono.IniciarDialogo(dialogoActual, cameraPoint));      
        
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
