using System.Collections;
using UnityEngine;
/// Отрявляет противника. Наносит урон равный <_poistonStrenght> каждые <_posionDelay> секунд.
public class PoisoningAbility : DamageAbility
{
    private float _posionDelay = 5;
    private float _poistonStrenght = 0.1f;
    private Coroutine _poisonRoutine;

    private void Start()
    {
        AttackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        AttackState.AtackCompleted -= ActivateAbility;

        if (_poisonRoutine != null)
            StopCoroutine(_poisonRoutine);
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        throw new System.NotImplementedException();
    }

    protected override void ActivateAbility()
    {
        if (_poisonRoutine != null)
            StopCoroutine(_poisonRoutine);

        _poisonRoutine = StartCoroutine(Poison());
    }

    private IEnumerator Poison()
    {
        int posisonDamage = 0;

        while (Fighter.CurrentTarget != null)
        {
            yield return new WaitForSeconds(_posionDelay);

            posisonDamage = Mathf.FloorToInt(Fighter.Damage * _poistonStrenght);
            Fighter.CurrentTarget.Health.TakeDamage(posisonDamage, Health.DamageType.Magical);
        }
    }
}