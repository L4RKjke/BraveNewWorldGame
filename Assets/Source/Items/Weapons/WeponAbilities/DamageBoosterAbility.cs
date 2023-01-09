using UnityEngine;

[RequireComponent(typeof(Sword))]

public class DamageBoosterAbility : WeaponAbility
{
    private Sword _sword;

    override public void ActivateAbility()
    {
        _sword = GetComponent<Sword>();
        Fighter.FighterHitted += OnFighterHitted;
    }

    private void OnDisable()
    {
        Fighter.FighterHitted -= OnFighterHitted;
    }

    private void OnFighterHitted(ushort damage)
    {
        _sword.IncreaseDamage((ushort)(damage/10));
    }
}
