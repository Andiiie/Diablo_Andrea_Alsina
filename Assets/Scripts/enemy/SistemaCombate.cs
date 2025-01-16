using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] Enemy main;

    [SerializeField] float velocidadCombate = 5.5f;
    [SerializeField] NavMeshAgent agentEnemy;
    [SerializeField] float distanciaAtaque = 1.5f;
    [SerializeField] float danhoAtaque = 1.5f;
    [SerializeField] Animator animator;
    

    void Start()
    {
        main.Combate = this;
        //main.mainTarget;
    }

    private void OnEnable()
    {
        agentEnemy.speed = velocidadCombate;
        agentEnemy.stoppingDistance = distanciaAtaque; 
    }


    void Update()
    {
        if (main.MainTarget != null && agentEnemy.CalculatePath(main.MainTarget.position, new NavMeshPath()))
        {
            // voy persiguiendo al target en todo momento (calculando su posicion)
            agentEnemy.SetDestination(main.MainTarget.position);
            if (!agentEnemy.pathPending && agentEnemy.remainingDistance <= distanciaAtaque)
            { 
              animator.SetBool("attack", true);

            }
        }
        else // si no lo puedo alcanzar
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

    #region ejecutados por eventos de animacion
    void Atacar()
    {
        // hacemos daño al player
        main.MainTarget.GetComponent<Player>().HacerDanho(danhoAtaque);
    }

    void FinAnimationAtaque()
    {
        animator.SetBool("attack", false);
    }
    #endregion
}
