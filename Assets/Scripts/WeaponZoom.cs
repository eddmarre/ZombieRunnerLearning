using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]  float regularFOV = 60.0f;
    [SerializeField] float ADSFOV = 45.0f;
    [SerializeField] Camera FPSCamera;
    bool zoomToggle=false;
    void Update()
    {
        CameraFOV();
    }
    void CameraFOV()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomToggle==false)
            {
                zoomToggle=true;
                FPSCamera.fieldOfView=ADSFOV;
            }
            else
            {
                zoomToggle=false;
                FPSCamera.fieldOfView=regularFOV;
            }
        }
    }
}
