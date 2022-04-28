using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Joystick joystickPlayer;
    public Joystick joystickCamera;

    AnimatorManager animatorManager;
    PlayerControls playerControls;
    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float cameraInputX,cameraInputY;
    public float horizontalInput;
    public float verticalInput;

    float moveInput;

    private void Awake() {
        
        animatorManager=GetComponent<AnimatorManager>();

    }

    private void OnEnable() {
        

        if(playerControls==null)
        {
            playerControls=new PlayerControls();
            playerControls.PlayerMovement.Movement.performed +=i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed +=i =>cameraInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable() {
        
        playerControls.Disable();
    }

    

    public void HandleInput()
    {
        horizontalInput=movementInput.x;
        verticalInput=movementInput.y;


        horizontalInput = joystickPlayer.Horizontal;
        verticalInput = joystickPlayer.Vertical;


        //cameraInputX =cameraInput.x;
        //cameraInputY=cameraInput.y;

        cameraInputX = joystickCamera.Horizontal;
        cameraInputY = joystickCamera.Vertical;

        moveInput =Mathf.Clamp01(Mathf.Abs(horizontalInput)+Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0,moveInput);
    }
}
