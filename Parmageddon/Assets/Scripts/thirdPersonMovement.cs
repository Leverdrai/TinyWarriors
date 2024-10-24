using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSMoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        movements();
        if (Input.GetKeyDown("e"))
        {
            this.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cube"))
        {

            this.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

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
