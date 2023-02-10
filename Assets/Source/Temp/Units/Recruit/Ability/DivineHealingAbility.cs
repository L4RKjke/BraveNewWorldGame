public class DivineHealingAbility: Ability
{
    /*���� �������� ���������� ���� 20 ���������, ����� �� 100*/
    private bool _isActivated = false;

    private readonly float _healValue = 0.2f;

    private void OnEnable()
    {
        _isActivated = false;
        Fighter.Health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.HealthChanged -= OnHealthChanged;
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Fighter.Health.MaxHealth);
    }

    private void OnHealthChanged(int health)
    {
        if (health < Fighter.Health.MaxHealth * _healValue && _isActivated == false)
        {
            ActivateAbility();
            _isActivated = true;
        }
    }
}
