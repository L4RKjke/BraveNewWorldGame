using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbility : Ability
{
    private Health _health;
    private float _damageBonus = 1.2f;

    private void OnEnable()
    {
/*        if (TryGetComponent(out MeleeState meleeState))
            meleeState.AtackCompleted += ActivateAbility;

        _health = GetComponent<Health>();*/
    }

    protected override void ActivateAbility()
    {
        _health.TakeDamage(Mathf.FloorToInt(Fighter.Damage * _damageBonus) - Fighter.Damage);
    }
}
