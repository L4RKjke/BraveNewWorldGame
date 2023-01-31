using UnityEngine;

public class DamageAbility : Ability
{
    private Health _health;
    private float _damageBonus = 1.2f;

    private void OnEnable()
    {
/*        if (TryGetComponent(out MeleeState meleeState))
            meleeState.AtackCompleted += ActivateAbility;

        if (TryGetComponent(out RangeAtackState RangeState))
            RangeState.AtackCompleted += ActivateAbility;*/

        _health = GetComponent<Health>();
    }

    protected override void ActivateAbility()
    {
        _health.TakeDamage(Mathf.FloorToInt(Fighter.Damage * _damageBonus) - Fighter.Damage);
    }
}
