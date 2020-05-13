using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;//float initializes at 0 so doing this prevents issue at start time
    bool isProvoked = false;
    float enemyStoppingDistance = 2f;
    Animator animator;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

    }
    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            chaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {

            AttackTarget();

        }
    }

    /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// Lets us see the range of the selected object
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    void chaseTarget()
    {
        animator.SetBool("Attack", false);
        animator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
        navMeshAgent.stoppingDistance = enemyStoppingDistance;
    }
    void AttackTarget()
    {
        animator.SetBool("Attack", true);
        Debug.Log(name + "Attacking" + target.name);//todo delete later
    }
}
