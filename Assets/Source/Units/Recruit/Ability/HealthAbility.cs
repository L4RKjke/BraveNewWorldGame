public class HealthAbility : Ability
{
    private bool _isActivated = false;

    private void Start()
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
        if (health < Fighter.Health.MaxHealth*0.2f && _isActivated == false)
        {
            ActivateAbility();
            _isActivated = true;
        }
    }
}
