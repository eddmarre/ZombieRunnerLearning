using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
 [SerializeField] float hitPoints=100f;

 public void ReduceHitPoints(float damage)
 {
     hitPoints-=damage;
     print(hitPoints);//todo remove later
     if(hitPoints<=0)
     {
         Destroy(gameObject);
     }
 }
}
