using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] Enemy main;

    [SerializeField] float velocidadCombate = 5.5f;
    [SerializeField] NavMeshAgent agentMain;
    [SerializeField] float distanciaAtaque = 1.5f;
    [SerializeField] Animator animator;
    

    void Start()
    {
        main.Combate = this;
        //main.mainTarget;
    }

    private void OnEnable()
    {
        agentMain.speed = velocidadCombate;
        agentMain.stoppingDistance = distanciaAtaque; 
    }


    void Update()
    {
        if (main.MainTarget != null && agentMain.CalculatePath(main.MainTarget.position, new NavMeshPath()))
        {
            // voy persiguiendo al target en todo momento (calculando su posicion)
            agentMain.SetDestination(main.MainTarget.position);
            if (agentMain.remainingDistance <= distanciaAtaque)
            { 
              animator.SetBool("attack", true);

            }
        }
        else //si no lo puedo alcanzar
        {
            main.ActivarPatrulla();
        }
        
    }

    void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;
    }
}
