using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] Transform ruta;
    [SerializeField] NavMeshAgent agentEnemy;

    List<Vector3> listadoPuntos = new List<Vector3>();
    Vector3 destinoActual;
    int indiceRutaActual; 
    void Awake()
    {
        // recorro todos los puntos de mi ruta
        foreach (Transform punto in ruta)
        {
            // los a�ado en mi lista
            listadoPuntos.Add(punto.position);
        }

    }

    private void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }


    IEnumerator PatrullarYEsperar()
    {

        CalcularDestino(); // 1. calculas el destino
        agentEnemy.SetDestination(destinoActual); // 2. se te marca el destino
        yield return new WaitUntil( () => !agentEnemy.pathPending && agentEnemy.remainingDistance <= 0.2f); //esperas hasta lelgar al destino y repites
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f)); //4. una vex llegado al punto, esperamos x tiempo en dicho punto
        
        
        //agentEnemy.SetDestination(destinoActual);
        //yield return null;
    }

    void CalcularDestino()
    {
        indiceRutaActual++;
       
        // Count para listas es igual a Length en los arrays
        if(indiceRutaActual >= listadoPuntos.Count)
        {
            indiceRutaActual = 0;
        }

        destinoActual = listadoPuntos[indiceRutaActual];
    }
}