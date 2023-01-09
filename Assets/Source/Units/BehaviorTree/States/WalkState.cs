using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMesh))]

public class WalkState : State
{
    [SerializeField] private FighterType _type;

    private Fighter _currentUnit;
    private NavMeshAgent _agent;

    private readonly float _speed = 1.6f;

    public UnityAction MovementStarted;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        SetAgentSettings();
    }

    private void OnEnable()
    {
        GetComponent<NavMeshAgent>().isStopped = false;
        _currentUnit = GetComponent<Fighter>();
        MovementStarted?.Invoke();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void OnDisable()
    {
        GetComponent<NavMeshAgent>().isStopped = true;
    }

    private void SetAgentSettings()
    {
        _agent.speed = _speed;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void MoveToTarget()
    {
        if (_currentUnit.CurrentTarget != null && _currentUnit != null)
        {
            _agent.SetDestination(_currentUnit.CurrentTarget.transform.position);
        }
    }
}