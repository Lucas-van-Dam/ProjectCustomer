using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseObject : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent agent;

    [SerializeField]
    float stopDistance = 5;

    public bool isFollowActive = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (!isFollowActive)
            return;

        float distToObject = Vector3.Distance(transform.position, target.position);

        if (distToObject > stopDistance)
            agent.destination = target.position;
        else
            agent.destination = transform.position;
    }
}
