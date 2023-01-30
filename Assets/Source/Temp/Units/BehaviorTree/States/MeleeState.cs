using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IMeleeAtacker))]

public class MeleeState : AtackState
{
    private IMeleeAtacker _meleeAtacker;

    public UnityAction AtackCompleted;
    private Coroutine _atackCourutine;
    private readonly float _meleeAtackDelay = 1f;

    private void OnEnable()
    {
        _meleeAtacker = GetComponent<IMeleeAtacker>();
        _atackCourutine = StartCoroutine(LaunchActack(FirstDelaySpread));
    }

    private void OnDisable()
    {
        StopCoroutine(_atackCourutine);
    }

    protected override void CompleteAtack()
    {
        _meleeAtacker.Atack(Damage);
        _atackCourutine = StartCoroutine(LaunchActack(_meleeAtackDelay));
        AtackCompleted?.Invoke();
    }
}
