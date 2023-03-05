using UnityEngine;

public class ExtraHealthAbility : Ability
{
    //Восстанавливает здоровь после полученного урона, равное половине брони.
    private readonly float _armorFactor = 0.5f;

    private void Start()
    {
        Fighter.Health.Damaged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.Damaged -= OnHealthChanged;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        ExtraHealthAbility ability = recruit.gameObject.AddComponent<ExtraHealthAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        if (Fighter.Health.Value > 0)
            Fighter.Health.Heal(Mathf.FloorToInt(Fighter.Health.Armor * _armorFactor));
        else
            Fighter.Health.Damaged -= OnHealthChanged;
    }

    private void OnHealthChanged(int damage)
    {
        ActivateAbility();
    }
}