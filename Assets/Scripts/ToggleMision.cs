using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{
    [SerializeField] TMP_Text textoMision; // es el recipiente donde meter los textos de cada mision

    private Toggle toggle; //cajita con el check

    public TMP_Text TextoMision { get => textoMision;}
    public Toggle Toggle { get => toggle;}

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }
}
