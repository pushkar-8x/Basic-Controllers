using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   InputManager input;
   PlayerLocomotion locomotion;
   CameraManager cameraManager;

   private void Awake() {
       input=GetComponent<InputManager>();
       locomotion=GetComponent<PlayerLocomotion>();
       cameraManager=FindObjectOfType<CameraManager>();
   }

   private void Update() {

       input.HandleInput();
   }

   private void FixedUpdate() {
       
       locomotion.HandleAllInput();

   }
   private void LateUpdate() {

        if(GameManager.instance.camType==CameraType.TPP)
       cameraManager.HandleAllCameraMovement();
   }
}
