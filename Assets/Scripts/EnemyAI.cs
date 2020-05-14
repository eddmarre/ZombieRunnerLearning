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
    [SerializeField] float turnSpeed=5f;
    EnemyHealth health;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health=GetComponent<EnemyHealth>();
    }


    void Update()
    {
        if(health.IsDead())
        {
            enabled=false;
            navMeshAgent.enabled=false;
        }
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
        FaceTarget();
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
    }

    void FaceTarget()
    {
        //normalized returns a value of 1 since we don't want to change the length of direction
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //slerp allows for a smoooth turn while rotating
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void OnDamageTaken()//string reference
    {
        isProvoked=true;
    }
}
