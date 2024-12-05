using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SistemaDialogo : MonoBehaviour
{
    // PATRON SINGLE-TONE   
    // asegura que esta sea una UNICA INSTANCIA de "sistema de dialigo"
    // asegura que esa instancia SEA ACCESIBLE desde cualquier punto del programa

    // referencia al gameObject "Marcos" 

    [SerializeField] GameObject marcos;
    [SerializeField] TMP_Text textoDialogo;

    bool escribiendo;
    int indiceFraseActual;


    public static SistemaDialogo trono;


    private void Awake()
    {
        if (trono == null)
        {
            // reclamo el trono y me lo quedo
            trono = this;

            // no me destruyo entre escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogoSO dialogue)    //DialogoSO dialogue)
    {
        marcos.SetActive(true);
    }

    void EscribirFrase()
    {

    }

    void TerminarDialogo()
    {

    }

    void SiguienteFrase()
    {

    }
}
