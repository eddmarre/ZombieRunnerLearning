using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAmount = 70f;
    [SerializeField] float intensityAmount = 10f;
    FlashLightSystem lightSystem;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAmount);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }

    }
}
