using System;
using UnityEngine;

public class UnlukaAbility : DamageAbility
{
    //Каждый удар дополнительно отнимает <_damageReducer>% жизней врага, также наносите урон себе, равный <_damageReducer>% от максимального уровня здоровья.
    private float _damageReducer = 0.1f;

    private void Start()
    {
        AttackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        AttackState.AtackCompleted -= ActivateAbility;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        UnlukaAbility ability = recruit.gameObject.AddComponent<UnlukaAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        var damage = Mathf.FloorToInt(Fighter.CurrentTarget.Health.MaxHealth * _damageReducer);

        Fighter.CurrentTarget.Health.TakeDamage(damage, Health.DamageType.Physical);
        HurtYourself();
    }

    private void HurtYourself()
    {
        var damage = Mathf.FloorToInt(Fighter.Health.MaxHealth * _damageReducer);
        Fighter.Health.TakeDamage(damage, Health.DamageType.Physical);
    }
}