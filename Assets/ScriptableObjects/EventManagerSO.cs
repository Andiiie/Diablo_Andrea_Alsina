using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNuevaMision;  // el termino ON representa un EVENTO
    public void nuevaMision()
    {
        // aqui notifico un nuevo evento por si a alguien le interesa
        OnNuevaMision.Invoke();
    }
}
