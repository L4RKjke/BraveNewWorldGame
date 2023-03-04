using UnityEngine;

[RequireComponent(typeof(IMeleeAtacker))]

public class MeleeState : AtackState
{
    private IMeleeAtacker _meleeAtacker;

    private void Start()
    {
        _meleeAtacker = GetComponent<IMeleeAtacker>();
    }

    protected override float CurrentDelay() => _meleeAtacker.GetMeleeAtackDelay();

    protected override void StartAtack()
    {
        AtackStarted?.Invoke();
    }

    protected override void CompleteAtack()
    {
        _meleeAtacker.Atack(Damage);
        AtackCompleted?.Invoke();
    }
}