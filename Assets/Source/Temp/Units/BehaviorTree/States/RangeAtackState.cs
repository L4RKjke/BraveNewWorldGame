using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IRangeAtacker))]

public class RangeAtackState : AtackState 
{
    private IRangeAtacker _rangeAtacker;

    public UnityAction<UnityAction> AtackStarted;
    public UnityAction AtackCompleted;
    private Coroutine _atackCourutine;

    private void OnEnable()
    {
        _rangeAtacker = GetComponent<IRangeAtacker>();
        _atackCourutine = StartCoroutine(LaunchActack(FirstDelaySpread));
    }

    private void OnDisable()
    {
        StopCoroutine(_atackCourutine);
    }

    protected override void Atack()
    {
        AtackStarted?.Invoke(CompleteAtack);
    }

    protected override void CompleteAtack()
    {
        _atackCourutine = StartCoroutine(LaunchActack(CurrentFighter.AtackDelay));
        _rangeAtacker.Shoot(Damage);
        AtackCompleted?.Invoke();
    }
}