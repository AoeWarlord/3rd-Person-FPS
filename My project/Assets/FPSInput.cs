using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    bool isGrounded;
    //bool isMoving;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool allowedToMove = true;
    private CharacterController charController;
    private PlayerCharacter stillAlive;
    //private Vector3 lastPosition = new Vector3(0f, 0f, 0f);



    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        stillAlive = GetComponent<PlayerCharacter>();
    }

    

    // Update is called once per frame
    void Update()
    {
        allowedToMove = stillAlive.notDead;
        if (allowedToMove)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && movement.y < 0)
            {
                movement.y = -9.8f;
            }

            movement = Vector3.ClampMagnitude(movement, speed);

            movement *= Time.deltaTime;

            movement = transform.TransformDirection(movement);

            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            movement.y += gravity * Time.deltaTime;

            /*if(lastPosition != gameObject.transform.position && isGrounded == true)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }*/

            charController.Move(movement);
        }
    }
}
