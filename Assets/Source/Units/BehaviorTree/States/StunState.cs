using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class StunState : State
{
    private NavMeshAgent _agent;
    private float _speed;

    public float CurrentSpeed => _agent.speed;

    public float NormalSpeed => _speed;

    private readonly int _stunTime = 5;

    private IEnumerator Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _speed = _agent.speed;
        _agent.speed = 0;

        yield return new WaitForSeconds(_stunTime);

        _agent.speed = _speed;
    }
}
