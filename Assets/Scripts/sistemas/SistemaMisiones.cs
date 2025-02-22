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

        if(mision.repeticion)
        {
            toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
        }

        toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
    private void ActualizarToggle(MisionSO mision)
    {
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.estadoActual + "/" + mision.repeticionesTotales + ")";
    }
    private void TerminarToggle(MisionSO mision)
    {
        toggleMision[mision.indiceMision].Toggle.isOn = true;
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
    }


}
