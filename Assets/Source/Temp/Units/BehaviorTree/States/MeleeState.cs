using UnityEngine;

[RequireComponent(typeof(IMeleeAtacker))]

public class MeleeState : AtackState
{
    private IMeleeAtacker _meleeAtacker;

    private Coroutine _atackCourutine;

    private void OnEnable()
    {
        _meleeAtacker = GetComponent<IMeleeAtacker>();
        AnimationController.AtackCompleted += CompleteAtack;
        _atackCourutine = StartCoroutine(LaunchAtack(CurrentFighter.AtackDelay));
        StateActivated?.Invoke();
    }   

    private void OnDisable()
    {
        AnimationController.AtackCompleted += CompleteAtack;
        StopCoroutine(_atackCourutine);
    }

    protected override void StartAtack()
    {
        AtackStarted?.Invoke();
    }

    protected override void CompleteAtack()
    {
        _meleeAtacker.Atack(Damage);
    }
}
