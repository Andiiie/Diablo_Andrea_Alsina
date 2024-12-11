using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    Animator anim;
    [SerializeField] NavMeshAgent agent;

    private void Awake()
    {
        // referencio al animador
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        // la velocidad maxima es agent.speed
        // la velocidad actual es agent.velocity
    }

    // Update is called once per frame
    void Update()
    {
        // en todos los frames voy actualizando mi velocity en función de mi velocidad actual
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
}
