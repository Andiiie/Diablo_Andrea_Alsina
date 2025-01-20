using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Player main;
    
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        main = GetComponent<Player>();
    }

    void Start()
    {

    }

    public void EjecutarAtaque()
    {
        anim.SetBool("attacking", true);
    }

    public void PararAtaque()
    {
        anim.SetBool("attacking", false);
        anim.SetBool("attacking", false);
    }
}
