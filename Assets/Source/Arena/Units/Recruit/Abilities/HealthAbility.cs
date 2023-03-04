using UnityEngine;

public class HealthAbility : Ability
{
    //увеличивает здоровье на 40%.
    private float _healthIncrease = 0.4f;

    private void Awake()
    {
        ActivateAbility();
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        HealthAbility ability = recruit.gameObject.AddComponent<HealthAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Init((int)(Fighter.Health.MaxHealth * _healthIncrease) + Fighter.Health.MaxHealth);
    }
}