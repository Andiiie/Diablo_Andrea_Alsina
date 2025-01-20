using DG.Tweening;
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
    [SerializeField] float tiempoRotacion;

    PlayerAnimation playerAnimation;

    // guardo la informacion del npc actual al que voy a hablar
    Transform ultimoClick; 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    
    void Update()
    {

        if (Time.timeScale == 1)
        {
            Movimiento();
        }
        
        // si existe un npc al cual pueda clickear...
        if (ultimoClick&&ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance = distanciaInteraccion;
            // comprobar si he llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                // a trasves del LookAt, consigue que el jugador mire al NPC
                // UNA VEZ COMPLETE EL GIRO, LANZAR ESTAS DOS LINEAS
                //transform.DOLookAt(npc.transform.position, tiempoRotacion, AxisConstraint.Y).OnComplete( () => LanzarInteraccion(npc));
                LanzarInteraccion(interactuable);
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
    }

    void LanzarInteraccion(IInteractuable interactuable)
    {
        interactuable.Interactuar(transform);
        ultimoClick = null;
    }

    void Movimiento()
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

    public void HacerDanho(float danhoAtaque)
    {
        Debug.Log("Me hacen pupa :c" + danhoAtaque);
    }
}


// // mirar si el punto donde ha inpactado el raton tiene el script "NPC"
//                if (hit.transform.TryGetComponent(out NPC npc))
//{
//    // en este caso, es el npc actual
//    npcActual = npc;
//    // distancia de parada es la de la interaccion
//    agent.stoppingDistance = distanciaInteraccion;