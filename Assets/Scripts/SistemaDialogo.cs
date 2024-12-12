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

    [SerializeField] Transform npcCamera;

    DialogoSO dialogoActual;
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

    public void IniciarDialogo(DialogoSO dialogue, Transform cameraPoint)    //DialogoSO dialogue)
    {
        Time.timeScale = 0f;

        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        // eñ dialogo actual con el que trabajemos es el que me dara como parametro de entrada
        dialogoActual = dialogue;
        marcos.SetActive(true);
        StartCoroutine(EscribirFrase());
    }

    IEnumerator EscribirFrase()
    {
        escribiendo = true;
        
        textoDialogo.text = "";
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }
   
    public void SiguienteFrase()
    {
        if (escribiendo)  // si estamos escribiendo una frase...
        {
            CompletarFrase();
        }
        else
        {
            indiceFraseActual++;  //avanzo indice de frases

           if(indiceFraseActual < dialogoActual.frases.Length)
           {
                StartCoroutine(EscribirFrase()); //la escribo
           }
            else
            {
                TerminarDialogo(); //si no me quedan frases, termino y cierro el dialogo
            }
            
        }
    }

    void CompletarFrase()
    {
        StopAllCoroutines();
        // pongo las frases de golpe
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        escribiendo = false;
    }

    void TerminarDialogo()
    {
        marcos.SetActive(false);
        StopAllCoroutines();
        indiceFraseActual = 0; //para posteriores dialogos
        escribiendo = false;
        dialogoActual = null; //no tenemos ningun dialogo a no ser que se vuelva a clickar. 
        Time.timeScale = 1f; //volvemos al tiempo actual
    }
}
