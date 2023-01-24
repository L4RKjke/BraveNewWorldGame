using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IMeleeAtacker))]

public class MeleeState : AtackState
{
    [SerializeField] private GameObject _hitEffect;

    private IMeleeAtacker _meleeAtacker;

    public UnityAction AtackStarted;
    public UnityAction AtackCompleted;
    private Coroutine _atackCourutine;

    private readonly float _meleeAtackDelay = 1f;

    private void OnEnable()
    {
        var spreadValue = 0.1f;
        var delaySpread = Random.Range(-spreadValue, spreadValue);

        _atackCourutine = StartCoroutine(LaunchActack(_meleeAtackDelay + delaySpread));
        _meleeAtacker = GetComponent<IMeleeAtacker>();
        Controller.AtackCompleted += CompleteAtack;
    }

    private void OnDisable()
    {
        StopCoroutine(_atackCourutine);

        if (Controller != null)
        {
            Controller.AtackCompleted -= CompleteAtack;
        }
    }

    protected override void StartAtack()
    {
        AtackStarted?.Invoke();
    }

    protected override void CompleteAtack()
    {
        Instantiate(_hitEffect, CurrentFighter.CurrentTarget.transform.position, Quaternion.identity);
        _meleeAtacker.Atack(Damage);
        AtackCompleted?.Invoke();
    }
}
