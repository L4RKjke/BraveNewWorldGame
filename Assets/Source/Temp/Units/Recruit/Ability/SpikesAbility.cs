using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAbility : Ability
{
    // каждый удар хилит на половину от значения нанесенного урона
    private readonly int _damageValue = 4;

    private void Start()
    {
        Fighter.CurrentTarget.Health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.CurrentTarget.Health.HealthChanged -= OnHealthChanged;
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Fighter.Damage / _damageValue);       
    }

    private void OnHealthChanged(int health)
    {
        ActivateAbility();
    }
}
