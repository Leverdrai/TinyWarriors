using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{


    public Animator CharacterAnimatore;

    // Start is called before the first frame update
    void Start()
    {
        CharacterAnimatore = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            CharacterAnimatore.SetBool("isAttacking", true);
        } 

        if (thirdPersonMovement.movement.magnitude >= 0.1f)
        {
            CharacterAnimatore.SetBool("isWalking", true);
        }
        else 
        {
            CharacterAnimatore.SetBool("isWalking", false);
        }
        //Debug.Log(thirdPersonMovement.speed);
    }

    public void movementStop()
    {
        if(CharacterAnimatore.GetBool("isAttacking") == true)
        {
            thirdPersonMovement.speed = 0;
            thirdPersonMovement.turnSMoothTime = 1000;
        }
        
    }


    public void movementStart()
    {
        if(CharacterAnimatore.GetBool("isAttacking") == false)
        {
            thirdPersonMovement.speed = 6f;
            thirdPersonMovement.turnSMoothTime = 0.1f;
        }
    }
    public void attackOff()
    {

        CharacterAnimatore.SetBool("isAttacking", false);
    }
}
