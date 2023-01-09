using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : Weapon
{
    private Fighter _currentFighter;
    private ushort _damage = 2;

    private void Awake()
    {
        _currentFighter = transform.parent.GetComponent<Fighter>();
    }

    override public void UseWeapon()
    {
        for (int i = 0; i < _currentFighter.Units.GetLength(FighterType.Enemy); i++)
        {
            _currentFighter.Units.GetById(0, FighterType.Enemy).TakeDamage(_damage);
        }
    }
}
