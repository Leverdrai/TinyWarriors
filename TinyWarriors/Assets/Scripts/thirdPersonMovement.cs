using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class thirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public static Risorse resources;

    public static float speed = 6f;

    public static float turnSMoothTime = 0.1f;
    float turnSmoothVelocity;

    public static Vector3 movement;

    public float gravity = -9.81f;
    public bool isGrounded;
    private Vector3 velocity;

    // variabili per il groundcheck attraverso uno sphearcast
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;
    public Transform groundCheckPosition;

    // variabili per il roll
    /*public float rollSpeed = 8f;
    public float rollDuration = 3f;
    private bool isRolling;*/

    void Start()
    {
        resources = new Risorse(100);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGroundStatus();

        movements();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cube") && resources.Risorsa < resources.MaxHealth)
        {

            this.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            resources.Risorsa += 20;
            this.transform.localPosition += new Vector3(0, 0.1f, 0);
            Debug.Log(resources.Risorsa);

        }
    }

    //check per il pavimento
    void CheckGroundStatus()
    {
        isGrounded = Physics.CheckSphere(groundCheckPosition.position, groundCheckRadius, groundLayer);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPosition.position, groundCheckRadius);
    }

    public void movements()
    {
        //get axis to move
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");
        movement = new Vector3(HorizontalInput, 0, VerticalInput).normalized;

        //check if is moving
        if (movement.magnitude >= 0.1f)
        {
            //rotation                                                                             
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //crea un angolo piu smooth di rotazione
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSMoothTime);
            //per applicare la rotazione usiamo lo smooth qui
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //actual movement
            speed = 6f;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Inizia il dodge roll se il tasto Shift � premuto
        
    }

    

}
