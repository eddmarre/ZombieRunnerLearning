using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float WeaponDamage = 10f;
    [SerializeField] float timeBetweenShots = .5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    bool canShoot = true;
    //when class is called enable this
    void OnEnable()
    {
        canShoot = true;
    }
    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmoAmount(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceAmmoAmount(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            //hit effects for details
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.ReduceHitPoints(WeaponDamage);
            //call a method on enemy health that decreses enemy health
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        var hitVFX = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitVFX, .1f);

    }

}
