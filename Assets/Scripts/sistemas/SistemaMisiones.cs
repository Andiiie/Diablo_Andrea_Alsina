using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] EventManagerSO eventManager;

    [SerializeField] ToggleMision[] toggleMision;

    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision;
        eventManager.OnActualizarMision += ActualizarToggle;
        eventManager.OnTerminarMision += TerminarToggle;
    }


    private void ActivarToggleMision(MisionSO mision)
    {

        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        if(mision.repetir)
        {
            toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
        }

        toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
    private void ActualizarToggle(MisionSO obj)
    {
        
    }
    private void TerminarToggle(MisionSO mision)
    {
        toggleMision[mision.indiceMision].Toggle.isOn = true;
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
    }


}
