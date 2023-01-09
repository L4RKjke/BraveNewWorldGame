using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class StunState : State
{
    private NavMeshAgent _agent;
    private float _currentSpeed;

    private readonly int _stunTime = 5;

    private IEnumerator Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentSpeed = _agent.speed;
        _agent.speed = 0;

        yield return new WaitForSeconds(_stunTime);

        _agent.speed = _currentSpeed;
    }
}
