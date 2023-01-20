using UnityEngine;
using UnityEngine.Events;



public class MeleeState : AtackState
{
    private IMeleeAtacker _meleeAtacker;

    public UnityAction AtackStarted;

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
    }
}
