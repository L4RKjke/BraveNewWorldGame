using System;
using UnityEngine;

public class UnlukaAbility : Ability
{
    //Вы получаете на 10 процентов больше урона
    private void OnEnable()
    {
        Fighter.Health.DamageTaken += ActivateAbility;
    }

    private void OnDisable()
    {
        Fighter.Health.DamageTaken -= ActivateAbility;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        UnlukaAbility ability = recruit.gameObject.AddComponent<UnlukaAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        var damage = Fighter.Health.MaxHealth * 0.1f;
        Fighter.Health.TakeDamage((int)damage);
    }
}
