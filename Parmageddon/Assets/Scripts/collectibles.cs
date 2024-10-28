using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{
    //public static event Action OnCollected;
    public GameObject oggetto;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(oggetto);
            Player.n_pezzi--;
        }
    }
}
