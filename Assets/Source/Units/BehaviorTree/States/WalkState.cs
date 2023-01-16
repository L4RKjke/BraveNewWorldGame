using UnityEngine;
using UnityEngine.Events;

public class WalkState : State
{
    [SerializeField] private FighterType _type;

    private Fighter _currentUnit;

    private readonly float _speed = 1.6f;

    public UnityAction MovementStarted;

    private void OnEnable()
    {
        Fighter.Agent.isStopped = false;
        _currentUnit = GetComponent<Fighter>();
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

    /// Привязаться к рут модели
    private void MoveToTarget()
    {
        if (_currentUnit.CurrentTarget != null && _currentUnit != null)
        {
            /*_currentUnit.transform.parent.position = Vector3.MoveTowards(_currentUnit.transform.parent.position, _currentUnit.CurrentTarget.transform.position, Time.deltaTime * _speed);*/
            Fighter.Agent.SetDestination(Fighter.CurrentTarget.transform.position/*_currentUnit.CurrentTarget.transform.position*/);
        }
    }
}