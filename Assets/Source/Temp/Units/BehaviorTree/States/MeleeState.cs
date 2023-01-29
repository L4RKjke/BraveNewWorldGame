using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IMeleeAtacker))]

public class MeleeState : AtackState
{
    private IMeleeAtacker _meleeAtacker;

    public UnityAction<UnityAction> AtackStarted;
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

    protected override void Atack()
    {
        AtackStarted?.Invoke(CompleteAtack);
    }

    protected override void CompleteAtack()
    {
        _meleeAtacker.Atack(Damage);
        _atackCourutine = StartCoroutine(LaunchActack(CurrentFighter.AtackDelay));
        AtackCompleted?.Invoke();
    }
}
