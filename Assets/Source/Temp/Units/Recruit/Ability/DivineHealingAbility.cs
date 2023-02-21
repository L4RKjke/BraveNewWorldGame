// ¬осстанавливает здорье, если оно опустилось ниже <_healthPercent>%
public class DivineHealingAbility: Ability
{
    private readonly float _healthPercent = 0.2f;

    private void Start()
    {
        Fighter.Health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.HealthChanged -= OnHealthChanged;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        DivineHealingAbility ability = recruit.gameObject.AddComponent<DivineHealingAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Fighter.Health.MaxHealth);
    }

    private void OnHealthChanged(int currentHealth)
    {
        var PersentOfMaxHealth = Fighter.Health.MaxHealth * _healthPercent;

        if (currentHealth < PersentOfMaxHealth)
        {
            ActivateAbility();
            Fighter.Health.HealthChanged -= OnHealthChanged;
        }
    }
}