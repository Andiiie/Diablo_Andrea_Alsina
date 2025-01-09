using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    SistemaCombate combate;
    SistemaPatrulla patrulla;

    Transform mainTarget;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarget { get => mainTarget; set => mainTarget = value; }

    private void Start()
    {
        // empeiza el juego y activamos la patrulla
        patrulla.enabled = true;
    }

    public void ActivaCombate(Transform target)
    {
        // ahora tenemos un target al cual perseguir
        mainTarget = target;
        
        // nos dicen de activar el combate
        combate.enabled = true;
    }

    public void ActivarPatrulla()
    {
        combate.enabled = false;
        patrulla.enabled = true;
    }
}
