using System;
using UnityEngine;

public class UnlukaAbility : Ability
{
    //�� ��������� �� 10 ��������� ������ �����
    private void OnEnable()
    {
        Fighter.Health.DamageTaken += ActivateAbility;
    }

    private void OnDisable()
    {
        Fighter.Health.DamageTaken -= ActivateAbility;
    }

    protected override void ActivateAbility()
    {
        var damage = Fighter.Health.MaxHealth * 0.1f;
        Fighter.Health.TakeDamage((int)damage);
    }
}
