using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacco : MonoBehaviour
{
    public Transform spada;
    public Transform Player;

    private float timer = 0.0f;
    private bool attacco = false;

    private float rotationY;

    void Start()
    {

    }

    void Update()
    {


        // Controlla se è stato premuto il tasto per avviare la rotazione
        if (Input.GetButtonDown("Fire1") && !attacco)
        {
            rotationY = spada.position.y / 2;

            spada.position = new Vector3(spada.position.x,
                                         spada.position.y - rotationY,
                                         spada.position.z); ;
            spada.rotation = Quaternion.Euler(spada.rotation.x - 45,
                                              spada.rotation.y,
                                              spada.rotation.z);
            attacco = true;
            timer = 0;
        }

        if(timer > 3 && attacco)
        {

            spada.position = new Vector3(spada.position.x,
                                         spada.position.y + rotationY,
                                         spada.position.z); ;
            spada.rotation = Quaternion.Euler(spada.rotation.x + 45,
                                              spada.rotation.y,
                                              spada.rotation.z);

            
            attacco = false;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
}
