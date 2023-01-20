using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Warrior : Recruit
{
    public float _damageBonus = 1.5f;

    public override void Atack(ushort damage)
    {
        base.Atack((ushort)(damage * _damageBonus));
    }
}