using System.Collections;
using UnityEngine.Events;

public class EnemyAtackState : AtackState
{
    private Enemy _enemy;

    public UnityAction Atacked;

    private readonly string _lauchAtack = "LaunchActack";

    private void OnEnable()
    {
        _enemy  = GetComponent<Enemy>();
        StartCoroutine(_lauchAtack);
    }

    private void OnDisable()
    {
        StopCoroutine(_lauchAtack);
    }

    protected override void StartAtack()
    {
        _enemy.Atack();
        Atacked?.Invoke();
    }
}
