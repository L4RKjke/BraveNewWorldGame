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
        AnimationController.AtackCompleted += CompleteAtack;
        _atackCourutine = StartCoroutine(LaunchAtack(FirstDelaySpread));
    }

    private void OnDisable()
    {
        StopCoroutine(_atackCourutine);
        AnimationController.AtackCompleted -= CompleteAtack;
    }

    protected override void StartAtack()
    {
        AtackStarted?.Invoke();
    }

    protected override void CompleteAtack()
    {
        _rangeAtacker.Shoot(Damage);
        StopCoroutine(_atackCourutine);
        _atackCourutine = StartCoroutine(LaunchAtack(CurrentFighter.AtackDelay));
    }
}