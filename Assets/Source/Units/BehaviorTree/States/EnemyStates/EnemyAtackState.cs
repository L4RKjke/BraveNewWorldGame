using UnityEngine.Events;
using UnityEngine;

public class EnemyAtackState : AtackState
{
    private Enemy _enemy;

    public UnityAction EnemyAtackStarted;

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        StartCoroutine(Launch);
        Controller.AtackCompleted += CompleteAtack;
    }

    private void OnDisable()
    {
        StopCoroutine(Launch);
        Controller.AtackCompleted -= CompleteAtack;
    }

    protected override void StartAtack()
    {
        EnemyAtackStarted?.Invoke();
    }

    protected override void CompleteAtack()
    {
        _enemy.Atack();
    }
}
