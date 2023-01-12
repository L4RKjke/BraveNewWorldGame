using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : Weapon
{
    private Priest _currentFighter;
    private ushort _damage = 2;

    private void Awake()
    {
        _currentFighter = transform.parent.GetComponent<Priest>();
    }

    override public void UseWeapon()
    {
        _currentFighter.Atack();
/*        for (int i = 0; i < _currentFighter.Units.GetLength(FighterType.Enemy); i++)
        {
            _currentFighter.Units.GetById(i, FighterType.Enemy).TakeDamage(_damage);
        }*/
    }
}
