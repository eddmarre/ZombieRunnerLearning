using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    //show the class in the inspector
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;

    }
    public int GetAmmoAmount()
    {
        return ammoAmount;
    }

    public void ReduceAmmoAmount()
    {
        ammoAmount--;
        print(ammoAmount);
    }
}
