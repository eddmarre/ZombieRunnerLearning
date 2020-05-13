using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float regularFOV = 60f;
    [SerializeField] float ADSFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;
    [SerializeField] Camera FPSCamera;
    bool zoomToggle = false;
    FirstPersonController firstPersonController;
    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }
    void Update()
    {
        CameraFOV();
    }
    void CameraFOV()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomToggle == false)
            {
                zoomToggle = true;
                FPSCamera.fieldOfView = ADSFOV;
                firstPersonController.m_MouseLook.XSensitivity = zoomInSensitivity;
                firstPersonController.m_MouseLook.YSensitivity=zoomInSensitivity;
            }
            else
            {
                zoomToggle = false;
                FPSCamera.fieldOfView = regularFOV;
                firstPersonController.m_MouseLook.XSensitivity=zoomOutSensitivity;
                firstPersonController.m_MouseLook.YSensitivity=zoomOutSensitivity;

            }
        }
    }
}
