using UnityEngine;

[RequireComponent(typeof(IRangeAtacker))]

public class RangeAtackState : AtackState 
{
    private IRangeAtacker _rangeAtacker;

    private void Start()
    {
        _rangeAtacker = GetComponent<IRangeAtacker>();
    }

    protected override float CurrentDelay() => _rangeAtacker.GetRangeAtackDelay();

    protected override void StartAtack()
    {
        AtackStarted?.Invoke();
    }

    protected override void CompleteAtack()
    {
        _rangeAtacker.Shoot(Damage);
        AtackCompleted?.Invoke();
    }
}