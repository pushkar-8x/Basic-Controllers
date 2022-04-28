using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CameraType
{
    FPP,TPP
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CameraType camType;

    public GameObject FPCamera;
    public GameObject TPCamera;
    private void Start()
    {
        instance = this;
        camType = CameraType.TPP;
    }

    public void SwitchCamera()
    {
        if (camType == CameraType.FPP)
        {
            camType = CameraType.TPP;
            FPCamera.SetActive(false);
            TPCamera.SetActive(true);


        }
        else if (camType == CameraType.TPP)
        {
            camType = CameraType.FPP;
            FPCamera.SetActive(true);
            TPCamera.SetActive(false);

        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
