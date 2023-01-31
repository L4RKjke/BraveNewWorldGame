using UnityEngine;

[RequireComponent(typeof(IMeleeAtacker))]

public class MeleeState : AtackState
{
    private IMeleeAtacker _meleeAtacker;

    private Coroutine _atackCourutine;
    private readonly float _meleeAtackDelay = 1f;
    private float _meleeSpread;

    private void OnEnable()
    {
        _meleeAtacker = GetComponent<IMeleeAtacker>();
        AnimationController.AtackCompleted += CompleteAtack;
        _atackCourutine = StartCoroutine(LaunchAtack(FirstDelaySpread));
    }   

    private void OnDisable()
    {
        AnimationController.AtackCompleted += CompleteAtack;
    }

    protected override void StartAtack()
    {
        AtackStarted?.Invoke();
    }

    protected override void CompleteAtack()
    {
        _meleeAtacker.Atack(Damage);
        StopCoroutine(_atackCourutine);
        _atackCourutine = StartCoroutine(LaunchAtack(CurrentFighter.AtackDelay));
    }
}
