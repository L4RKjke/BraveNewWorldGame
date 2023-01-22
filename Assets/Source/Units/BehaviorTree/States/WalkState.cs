using UnityEngine;
using UnityEngine.Events;

public class WalkState : State
{
    [SerializeField] private NavMeshRootController _navMeshCotroller;

    public UnityAction<float> SpeedChanged;

    private void OnEnable()
    {
        _navMeshCotroller.MakeMoveble();
        /*_navMeshCotroller.SetStoppingDistance(CurrentFighter.WalkDistance);*/
        SpeedChanged?.Invoke(CurrentFighter.Speed);
    }

    private void OnDisable()
    {
        _navMeshCotroller.StopAgent();
        SpeedChanged?.Invoke(0);
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (CurrentFighter.CurrentTarget != null && CurrentFighter != null)
        {
            _navMeshCotroller.MoveTo(CurrentFighter.CurrentTarget.transform.position, CurrentFighter.Speed);
        }
    }
}