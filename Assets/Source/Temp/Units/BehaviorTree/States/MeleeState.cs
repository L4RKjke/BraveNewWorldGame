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
        _atackCourutine = StartCoroutine(LaunchActackCoroutine(FirstDelaySpread));
    }   

    private void OnDisable()
    {
        StopCoroutine(_atackCourutine);
    }

    protected override void CompleteAtack()
    {
        _meleeAtacker.Atack(Damage);
        AtackCompleted?.Invoke();
        StopCoroutine(_atackCourutine);
        _atackCourutine = StartCoroutine(LaunchActackCoroutine(_meleeAtackDelay));
    }
}
