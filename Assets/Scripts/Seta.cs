using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractuable
{
    [SerializeField] EventManagerSO eventManager;
    [SerializeField] MisionSO misionAsociada;
    Outline outline;

    public void Interactuar(Transform interactuador)
    {
        misionAsociada.estadoActual++; // estamos a un paso más de completar la mision
        if(misionAsociada.estadoActual < misionAsociada.repeticionesTotales)
        {
            eventManager.ActualizarMision(misionAsociada);
        }
        eventManager.ActualizarMision(misionAsociada);
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
