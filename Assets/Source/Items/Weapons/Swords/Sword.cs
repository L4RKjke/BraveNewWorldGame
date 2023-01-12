using UnityEngine;

public class Sword : Weapon
{
    private ushort _swordSharpness = 5;
    private Fighter _target;
    private Fighter _currentRecruit;

    private readonly ushort _maxSharpness = 50;

    override public void UseWeapon()
    {
        ushort strength = (ushort)(_swordSharpness + transform.parent.GetComponent<Fighter>().Damage);
        transform.parent.GetComponent<Fighter>().CurrentTarget.TakeDamage(_swordSharpness);

        Debug.Log("SwordUsed");
    }

    public void IncreaseDamage(ushort amplifier)
    {
        if (_swordSharpness <= _maxSharpness)
            _swordSharpness += amplifier;
    }
}
