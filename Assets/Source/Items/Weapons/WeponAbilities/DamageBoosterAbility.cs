using UnityEngine;

[RequireComponent(typeof(Weapon))]

public class DamageBoosterAbility : WeaponAbility
{
    private Weapon _weapon;

    override public void ActivateAbility()
    {
        _weapon = GetComponent<Weapon>();
         
        if (Fighter != null)
            Fighter.HealthChanged += OnFighterHitted;
    }

    private void OnDisable()
    {
        if (Fighter != null)
            Fighter.HealthChanged -= OnFighterHitted;
    }

    private void OnFighterHitted(ushort damage)
    {
        _weapon.IncreaseDamage((ushort)(damage/10));
    }
}
