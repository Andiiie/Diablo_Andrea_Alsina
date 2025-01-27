using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; // indica lo que tienes que hacer, como recoger algo...
    public string ordenFinal; // vuelve a hablar con tal...

    public bool repetir; // indica si la mision tiene varios pasos
    public int repeticionesTotales;

    public int estadoActual;

    public int indiceMision; // es el identificador unico de las misiones y cuantas son
}
