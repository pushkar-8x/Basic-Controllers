using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    
    Vector3 moveDirection ;
    //Transform cameraObject;
    public Transform TPCam;
    public Transform FPCam;
    public float movementSpeed = 10f;
    public float rotationSpeed=15f;
    Rigidbody rb;

    private void Awake() {

        
        inputManager=GetComponent<InputManager>();
        rb=GetComponent<Rigidbody>();
       
    }





   















    public void HandleAllInput()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
       
        if(GameManager.instance.camType==CameraType.TPP)
        {
            moveDirection = TPCam.forward * inputManager.verticalInput;
            moveDirection += TPCam.right * inputManager.horizontalInput;


            moveDirection.Normalize();

            moveDirection.y = 0;

            Vector3 movementVel = moveDirection * movementSpeed;

            rb.velocity = movementVel;
        }
        else if(GameManager.instance.camType == CameraType.FPP)
        {
            moveDirection = FPCam.forward * inputManager.verticalInput;
            moveDirection += FPCam.right * inputManager.horizontalInput;


            moveDirection.Normalize();

            moveDirection.y = 0;

            Vector3 movementVel = moveDirection * movementSpeed;

            rb.velocity = movementVel;
        }
          

        

    }



    private void HandleRotation()
    {
        
        if(GameManager.instance.camType == CameraType.TPP)
        {
            Vector3 targetDirection = Vector3.zero;

            targetDirection = TPCam.forward * inputManager.verticalInput;
            targetDirection += TPCam.right * inputManager.horizontalInput;

            targetDirection.Normalize();
            targetDirection.y = 0;


            if (targetDirection == Vector3.zero)
                targetDirection = transform.forward;


            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = playerRotation;
        }
           
        
       

    }
}
