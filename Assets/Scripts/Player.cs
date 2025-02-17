using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [SerializeField] float distanciaInteraccion;

    NavMeshAgent agent;
    Camera cam;
    [SerializeField] float tiempoRotacion;

    PlayerAnimation playerAnimation;
    [SerializeField] GameObject Victoria;
    // guardo la informacion del npc actual al que voy a hablar
    Transform ultimoClick;
    [SerializeField] float vida = 100;
    [SerializeField] GameObject Derrota;
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
            Muerto();
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
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Time.timeScale == 1)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (Input.GetMouseButtonDown(0))
                {

                    //Mirrar a ver si el punto donde e impactado tiene el script NPC
                    agent.SetDestination(hit.point);
                    ultimoClick = hit.transform;
                }

            }

        }
    }

    public void HacerDanho(float danhoAtaque)
    {
       vida-=danhoAtaque;
        Debug.Log("Me hacen pupa :c" + danhoAtaque);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOver"))
        {
            Victoria.SetActive(true);
        }
    }
    private void Muerto()
    {
        if (vida <= 0)
        {
            Derrota.SetActive(true);
        }
    }
}
