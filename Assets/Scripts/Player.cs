using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] float distanciaInteraccion;

    NavMeshAgent agent;
    Camera cam;

    // guardo la informacion del npc actual al que voy a hablar
    NPC npcActual; 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    
    void Update()
    {
        Movimiento();

        // si existe un npc al cual pueda clickear...
        if (npcActual)
        {
            // comprobar si he llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npcActual.Interactuar(this.transform);
                npcActual = null;
                agent.isStopped = true;
                agent.stoppingDistance = 0;
            }
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
                // mirar si el punto donde ha inpactado el raton tiene el script "NPC"
                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    // en este caso, es el npc actual
                    npcActual = npc;
                    // distancia de parada es la de la interaccion
                    agent.stoppingDistance = distanciaInteraccion;
                }

                agent.SetDestination(hit.point);
            }
        }
    }
}
