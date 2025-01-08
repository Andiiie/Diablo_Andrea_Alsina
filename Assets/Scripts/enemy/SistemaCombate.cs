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
        agentMain.SetDestination(main.MainTarget.position);
    }
}
