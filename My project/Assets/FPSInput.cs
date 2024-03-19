using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravity = -9.8f;
    private bool allowedToMove = true;
    private CharacterController charController;
    private PlayerCharacter stillAlive;




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

            movement = Vector3.ClampMagnitude(movement, speed);

            movement.y = gravity;

            movement *= Time.deltaTime;

            movement = transform.TransformDirection(movement);

            charController.Move(movement);
        }
    }
}
