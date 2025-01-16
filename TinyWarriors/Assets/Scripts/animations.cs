using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    public CharacterController controller;
    public float rollSpeed = 8f;
    public float rollDuration = 1f;
    private bool isRolling = false;
    public MonoBehaviour movimento;

    public static Animator CharacterAnimatore;

    // Start is called before the first frame update
    void Start()
    {
        CharacterAnimatore = GetComponent<Animator>();
        movimento = GetComponentInParent<thirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 1"))
        {            
            walkOff();
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
        if (Input.GetKeyDown("left shift"))
        {
            CharacterAnimatore.SetBool("isRolling", true);
            Roll();
        }
    }

    public void movementStop()
    {
        if(CharacterAnimatore.GetBool("isAttacking"))
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

    public void rollOff()
    {
        CharacterAnimatore.SetBool("isRolling", false);
    }

    public void walkOff()
    {
        CharacterAnimatore.SetBool("isWalking", false);
        //movimento.enabled = false;
    }

    public void walkOn()
    {
        movimento.enabled = true;
    }
    
    
    IEnumerator RollCoroutine(Vector3 direction)
    {
        float startTime = Time.time;

        while (Time.time < startTime + rollDuration)
        {
            controller.Move(direction * rollSpeed * Time.deltaTime);
            yield return null;
            
        }

        isRolling = false;
        
        animations.CharacterAnimatore.SetBool("isRolling", false);
    }

    public void Roll()
    {
       

        isRolling = true;
        animations.CharacterAnimatore.SetBool("isWalking", false);
        animations.CharacterAnimatore.SetBool("isRolling", true);

        // Calcola la direzione di movimento del roll
        Vector3 rollDirection = transform.forward;
        StartCoroutine(RollCoroutine(rollDirection));

    }
}
