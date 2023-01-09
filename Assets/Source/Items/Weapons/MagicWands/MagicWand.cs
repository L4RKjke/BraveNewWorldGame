using UnityEngine;

public class MagicWand : Weapon
{
    private Wizzard _wizzard;

    private readonly ushort _magicPower = 10;

    private void Awake()
    {
        _wizzard = transform.parent.GetComponent<Wizzard>();
        _wizzard.Fireball.IncreaseDamage(_magicPower);
    }

    override public void UseWeapon()
    {
        _wizzard.Atack();
    }
}
