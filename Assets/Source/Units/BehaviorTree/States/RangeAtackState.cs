using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IRangeAtacker))]

public class RangeAtackState : AtackState 
{
    private IRangeAtacker _rangeAtacker;
    private Coroutine _atackCourutine;

    public UnityAction AtackStarted;

    private void Start()
    {
        _rangeAtacker = GetComponent<IRangeAtacker>();
    }
    private void OnEnable()
    {
        _atackCourutine = StartCoroutine(LaunchActack(CurrentFighter.AtackDelay));
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
        _rangeAtacker.Shoot(Damage);
    }
}