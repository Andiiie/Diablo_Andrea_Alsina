using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MisionSO> OnNuevaMision;  // el termino ON representa un EVENTO
    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;
    public void nuevaMision(MisionSO mision)
    {
        // aqui notifico un nuevo evento por si a alguien le interesa
        OnNuevaMision?.Invoke(mision);

        // ?. significa invocacion SEGURA, porque se ASEGURA de que hayan suscriptores
    }

    public void ActualizarMision(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision);
    }

    public void TerminarMision (MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
    }
}
