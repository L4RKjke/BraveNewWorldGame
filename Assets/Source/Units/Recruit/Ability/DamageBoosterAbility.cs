using UnityEngine;

public class DamageBoosterAbility : Ability
{
    private Health _health;
    private float _damageBonus = 1.1f;

    private void OnEnable()
    {
        if (TryGetComponent(out MeleeState meleeState))
            meleeState.AtackCompleted += ActivateAbility;

        _health = GetComponent<Health>();
    }

    private void OnDisable()
    {
        _damageBonus = 1.1f;
    }

    protected override void ActivateAbility()
    {
        _health.TakeDamage(Mathf.FloorToInt(Fighter.Damage * _damageBonus) - Fighter.Damage);
        _damageBonus += 0.1f;
    }
}
