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

    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Mathf.FloorToInt(Fighter.Health.Armor * _armorFactor));
    }

    private void OnHealthChanged(int damage)
    {
        ActivateAbility();
    }
}