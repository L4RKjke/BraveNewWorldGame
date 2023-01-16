using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMesh : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;


    private void OnEnable()
    {
        _agent = transform.GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.stoppingDistance = 1;
        _agent.isStopped = false;
    }

    private void OnDisable()
    {
        _agent.isStopped = true;
    }

    private void Awake()
    {

    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.transform.position) > 3f)
            _agent.SetDestination(_target.position);
    }
}