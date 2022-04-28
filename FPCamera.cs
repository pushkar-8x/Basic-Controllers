using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    float rotationX;
    float mouseSensi =90f;
    public Transform player;

    public Joystick cameraJoystick;

    
    void Update()
    {
       

        float mouseX = cameraJoystick.Horizontal * Time.deltaTime * mouseSensi;
        float mouseY = cameraJoystick.Vertical * Time.deltaTime * mouseSensi;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX, 0, 0);

        player.Rotate(Vector3.up * mouseX);
    }
}
