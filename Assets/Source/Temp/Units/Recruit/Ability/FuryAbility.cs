using UnityEngine;

[RequireComponent (typeof(AtackState))]

public class FuryAbility : Ability
{
    ///+20% когда юнит получает урон
    private AtackState _atackState;
    private float _damage = 1f;
    
    private readonly float _damageBonus = 0.2f;

    private void OnEnable()
    {
        _atackState = GetComponent<AtackState>();
        Fighter.Health.DamageTaken += IncreaseDamage;
        _atackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        _atackState.AtackCompleted -= ActivateAbility;
        Fighter.Health.DamageTaken -= IncreaseDamage;
    }

    protected override void ActivateAbility()
    {
        Fighter.CurrentTarget.Health.TakeDamage(Mathf.FloorToInt(Fighter.Damage * _damage) - Fighter.Damage);
    }

    private void IncreaseDamage()
    {
        _damage += _damageBonus;
    }
}
