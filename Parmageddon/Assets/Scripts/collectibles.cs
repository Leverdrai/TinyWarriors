using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{
    public static event Action OnCollected;
    public GameObject oggetto;
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //se entra il trigger della collisione invoca il metodo e distrugge l'oggetto istanziato 
            OnCollected?.Invoke();
            Destroy(oggetto);
        }
    }
}
