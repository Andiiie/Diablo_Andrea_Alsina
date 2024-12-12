using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform ruta;
    NavMeshAgent agentEnemy;

    List<Vector3> listadoPuntos = new List<Vector3>();
    Vector3 destinoActual; 
    void Awake()
    {
        agentEnemy = GetComponent<NavMeshAgent>();

        // recorro todos los puntos de mi ruta
        foreach (Transform punto in ruta) 
        {
          // los añado en mi lista
          listadoPuntos.Add(punto.position);
        }

    }

    private void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }


    IEnumerator PatrullarYEsperar()
    {
        agentEnemy.SetDestination(destinoActual);
        yield return null;
    }

    void CalcularDestino()
    {
        destinoActual = listadoPuntos[0];
    }
}
