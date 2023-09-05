using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseObject : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        agent.destination = target.position;
    }
}
