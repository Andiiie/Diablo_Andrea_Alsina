using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Misi�n")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial;//Recoge...
    public string ordenFinal;//"Vuelve a hablar con...


    public bool repeticion;//Si la mision tiene varios pasos.
    public int repeticionesTotales;
    [NonSerialized]//Para que se pueda resetear la variable entre partidas
    public int estadoActual=0;

    public int indiceMision; //Identificador unico
}
