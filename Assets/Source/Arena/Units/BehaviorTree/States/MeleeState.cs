using UnityEngine;

[RequireComponent(typeof(IMeleeAtacker))]

public class MeleeState : AtackState
{
    private IMeleeAtacker _meleeAtacker;

    protected override float CurrentDelay => _meleeAtacker.GetMeleeAtackDelay();

    private void Start()
    {
        _meleeAtacker = GetComponent<IMeleeAtacker>();
    }   

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