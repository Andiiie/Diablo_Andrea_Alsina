using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] EventManagerSO eventManager;

    [SerializeField] GameObject toggleMision;

    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision; ;
    }

    private void ActivarToggleMision()
    {
        toggleMision.SetActive(true);
    }
}
