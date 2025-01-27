using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo")]
public class DialogoSO  : ScriptableObject
{
    [TextArea(3, 7)] 
    public string[] frases;
    public float tiempoEntreLetras;

    public bool tieneMision;

    public MisionSO mision;
}
