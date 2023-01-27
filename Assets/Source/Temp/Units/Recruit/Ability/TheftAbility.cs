using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheftAbility : Ability
{
    private int _targetDamage;

    private readonly int _damageValue = 2;

    private void Start()
    {
        Fighter.Health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.HealthChanged -= OnHealthChanged;
    }

    protected override void ActivateAbility()
    {
        if (Fighter.CurrentTarget != null)
            Fighter.CurrentTarget.Health.TakeDamage(_targetDamage / _damageValue);
    }

    private void OnHealthChanged(int health)
    {
        if (Fighter.CurrentTarget != null)
        {
            _targetDamage = Fighter.CurrentTarget.Damage;
            ActivateAbility();
        }
    }
}
