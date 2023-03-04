using UnityEngine;
using UnityEngine.Events;

public class WalkState : State
{
    [SerializeField] private NavMeshRootController _navMeshCotroller;

    private readonly int _minSpeed = 0;

    public NavMeshRootController NavMeshCotroller => _navMeshCotroller;

    public UnityAction<float> SpeedChanged;

    private void OnEnable()
    {
        _navMeshCotroller.MakeMoveble();
        SpeedChanged?.Invoke(CurrentFighter.Speed);
    }

    private void OnDisable()
    {
        if (_navMeshCotroller.enabled)
            _navMeshCotroller.StopAgent();

        SpeedChanged?.Invoke(_minSpeed);
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        CurrentFighter.UpdateCurrentTarget();

        if (CurrentFighter.CurrentTarget != null && CurrentFighter != null)
        {
            if (_navMeshCotroller.enabled)
                _navMeshCotroller.MoveTo(CurrentFighter.CurrentTarget.transform.position, CurrentFighter.Speed);
        }
    }
}