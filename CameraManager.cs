using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
     Transform targetTransform;

     public Transform cameraTransform;
     public Transform cameraPivot;
     public LayerMask collisionLayers; 
     private float defaultPosition;
     public float collisionRadius=2f;
     float cameraCollisionOffset=0.2f;
     float minimumCollisionOffset =0.2f;
     private Vector3 cameraVectorPosition;
     private Vector3 cameraFollowVelocity=Vector3.zero;
    public float cameraFollowSpeed =0.2f;
    public float cameraLookSpeed=2;
    public float cameraPivotSpeed=2;

    public float LookAngle,PivotAngle;

    private void Awake() {
        
        targetTransform=FindObjectOfType<PlayerManager>().transform;
        inputManager=FindObjectOfType<InputManager>();
        cameraTransform=Camera.main.transform;
        defaultPosition=cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position,targetTransform.position,ref cameraFollowVelocity,cameraFollowSpeed);
        transform.position=targetPosition;
    }

    private void RotateCamera()
    {
        LookAngle+=inputManager.cameraInputX*cameraLookSpeed;
        PivotAngle-=inputManager.cameraInputY*cameraPivotSpeed;

        PivotAngle=Mathf.Clamp(PivotAngle,-5f,35f);

        Vector3 rotation = Vector3.zero;
        rotation.y=LookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation=targetRotation;


        rotation=Vector3.zero;
        rotation.x=PivotAngle;
        targetRotation=Quaternion.Euler(rotation);
        cameraPivot.localRotation=targetRotation;
        
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;

        Vector3 direction = cameraTransform.position-cameraPivot.position;
        direction.Normalize();

        if(Physics.SphereCast(cameraPivot.transform.position,collisionRadius,direction,out hit,Mathf.Abs(targetPosition),collisionLayers))
        {
            float distance= Vector3.Distance(cameraPivot.position,hit.point);
            targetPosition-=distance-cameraCollisionOffset;


        }

        if(Mathf.Abs(targetPosition)<minimumCollisionOffset)
        {
            targetPosition-=minimumCollisionOffset;
        }

        cameraVectorPosition.z=Mathf.Lerp(cameraTransform.localPosition.z,targetPosition,0.2f);
        cameraTransform.localPosition=cameraVectorPosition;




    }
}
