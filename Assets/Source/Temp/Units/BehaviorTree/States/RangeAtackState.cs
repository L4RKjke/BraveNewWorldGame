using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IRangeAtacker))]

public class RangeAtackState : AtackState 
{
    private IRangeAtacker _rangeAtacker;
    private Coroutine _atackCourutine;

    public UnityAction<UnityAction> AtackStarted;
    public UnityAction AtackCompleted;

    private void Start()
    {
        _rangeAtacker = GetComponent<IRangeAtacker>();
    }
    private void OnEnable()
    {
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
        _rangeAtacker.Shoot(Damage);
        AtackCompleted?.Invoke();
        _atackCourutine = StartCoroutine(LaunchActack(CurrentFighter.AtackDelay));
    }
}