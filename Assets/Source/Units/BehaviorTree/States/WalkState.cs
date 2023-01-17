using UnityEngine;
using UnityEngine.Events;

public class WalkState : State
{
    [SerializeField] private FighterType _type;

    private readonly float _speed = 1.6f;

    public UnityAction MovementStarted;

    private void OnEnable()
    {
        Fighter.Agent.isStopped = false;
        MovementStarted?.Invoke();
    }

    private void OnDisable()
    {
        Fighter.Agent.isStopped = true;
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (Fighter.CurrentTarget != null && Fighter != null)
        {
            Fighter.Agent.SetDestination(Fighter.CurrentTarget.transform.position);
        }
    }
}