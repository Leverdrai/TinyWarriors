using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public static Risorse resources;

    public float speed = 6f;

    public float turnSMoothTime = 0.1f;
    float turnSmoothVelocity;

    

    void Start()
    {
        resources = new Risorse(100);
    }

    // Update is called once per frame
    void Update()
    {
        movements();
        if (Input.GetKeyDown("e") && resources.Risorsa > 20)
        {
            this.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            resources.Risorsa -= 20;
            this.transform.localPosition -= new Vector3(0, 0.1f, 0);
            Debug.Log(resources.Risorsa);
        }
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
    void movements()
    {
        //get axis to move
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(HorizontalInput, 0, VerticalInput).normalized;

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
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }


}
