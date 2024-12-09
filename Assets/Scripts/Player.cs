using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] float distanciaInteraccion;

    NavMeshAgent agent;
    Camera cam;

    // guardo la informacion del npc actual al que voy a hablar
    Transform ultimoClick; 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    
    void Update()
    {
        Movimiento();

        if (Time.timeScale == 1)
        {
            Movimiento();
        }
        
        // si existe un npc al cual pueda clickear...
        if (ultimoClick&&ultimoClick.TryGetComponent(out NPC npc))
        {
            agent.stoppingDistance = distanciaInteraccion;
            // comprobar si he llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npc.Interactuar(this.transform);
                ultimoClick = null;
              
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
    }

    private void Movimiento()
    {
        // trazar un raycast desde la camara a la posicion del raton
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(hit.point);
                ultimoClick = hit.transform;
            }

                
            
        }
    }
}


// // mirar si el punto donde ha inpactado el raton tiene el script "NPC"
//                if (hit.transform.TryGetComponent(out NPC npc))
//{
//    // en este caso, es el npc actual
//    npcActual = npc;
//    // distancia de parada es la de la interaccion
//    agent.stoppingDistance = distanciaInteraccion;