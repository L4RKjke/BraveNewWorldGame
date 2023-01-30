using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IRangeAtacker))]

public class RangeAtackState : AtackState 
{
    private IRangeAtacker _rangeAtacker;

    private Coroutine _atackCourutine;

    private void OnEnable()
    {
        _rangeAtacker = GetComponent<IRangeAtacker>();
        _atackCourutine = StartCoroutine(LaunchActackCoroutine(FirstDelaySpread));
    }

    private void OnDisable()
    {
        StopCoroutine(_atackCourutine);
        AtackCompleted -= CompleteAtack;
    }

    protected override void CompleteAtack()
    {
        _rangeAtacker.Shoot(Damage);
        AtackCompleted?.Invoke();
        StopCoroutine(_atackCourutine);
        _atackCourutine = StartCoroutine(LaunchActackCoroutine(CurrentFighter.AtackDelay));
    }
}