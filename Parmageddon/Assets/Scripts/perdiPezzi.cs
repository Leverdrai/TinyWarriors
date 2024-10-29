using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perdiPezzi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown("e") && thirdPersonMovement.resources.Risorsa > 20)
            {
                this.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
                thirdPersonMovement.resources.Risorsa -= 20;
                this.transform.localPosition -= new Vector3(0, 0.1f, 0);
                Debug.Log(thirdPersonMovement.resources.Risorsa);
            }
    }
}
