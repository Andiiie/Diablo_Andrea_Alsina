using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // para que la barra pueda mirar a la camara (solo funciona con el ortografico)
        transform.forward = cam.transform.forward; 
    }
}
