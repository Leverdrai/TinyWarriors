using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour 
{
    public GameObject pezzo;
    public GameObject player;
    public static int n_pezzi = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && thirdPersonMovement.resources.Risorsa >= 20 && n_pezzi < thirdPersonMovement.resources.MaxHealth/20 - 1)
        {
            Debug.Log("ciao");
            Vector3 spawnPosition = new Vector3(player.transform.position.x + Random.Range(-4, 4), 0.5f, player.transform.position.z + Random.Range(-4, 4));
            Instantiate(pezzo, spawnPosition, Quaternion.identity);
            n_pezzi++;
        }
    }


}
