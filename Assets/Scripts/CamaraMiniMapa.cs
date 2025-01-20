using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMiniMapa : MonoBehaviour
{
    [SerializeField] 
    Player player;
    Vector3 distanciaAlPlayer;
    // Start is called before the first frame update
    void Start()
    {
        distanciaAlPlayer=transform.position-player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =player.transform.position+distanciaAlPlayer;
    }
}
