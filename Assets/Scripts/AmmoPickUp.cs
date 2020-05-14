using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoamount=5;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType, ammoamount);
            Destroy(gameObject);
        }

    }
}
