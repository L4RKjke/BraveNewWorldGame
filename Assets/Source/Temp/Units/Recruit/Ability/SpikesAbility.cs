using UnityEngine;

public class SpikesAbility : Ability
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

    public override void SetAbility(Recruit recruit)
    {
        recruit.gameObject.AddComponent<SpikesAbility>();
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
