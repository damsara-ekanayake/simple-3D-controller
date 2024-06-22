using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRb;

    public float sprintingSpeed = 7;
    public float walkingSpeed = 1.5f;
    public float rotationSpeed = 15;
    public bool isSprinting;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleALLMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (isSprinting)
        {
            moveDirection = moveDirection * sprintingSpeed;
        }
        else
        {
            moveDirection = moveDirection * walkingSpeed;
        }
        

        Vector3 movementVelocity = moveDirection;
        playerRb.velocity = movementVelocity;
        
    }

    private void HandleRotation()
    {
        Vector3 targetDiection = Vector3.zero;

        targetDiection = cameraObject.forward * inputManager.verticalInput;
        targetDiection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        targetDiection.Normalize();
        targetDiection.y = 0;

        if(targetDiection == Vector3.zero)
        {
            targetDiection = transform.forward;  
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDiection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}
