using UnityEngine;

public class BloodlustAbility : Ability
{
    // каждый удар хилит на 25% от значения нанесенного урона
    private readonly int _damageValue = 4;

    private void OnEnable()
    {
        Fighter.Health.DamageTaken += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.DamageTaken -= OnHealthChanged;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        BloodlustAbility ability = recruit.gameObject.AddComponent<BloodlustAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Fighter.Damage / _damageValue);       
    }

    private void OnHealthChanged()
    {
        ActivateAbility();
    }
}
