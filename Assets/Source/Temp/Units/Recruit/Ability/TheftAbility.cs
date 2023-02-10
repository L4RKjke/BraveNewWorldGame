public class TheftAbility : Ability
{
    private int _targetDamage;

    private readonly int _damageValue = 2;

    private void OnEnable()
    {
        Fighter.Health.DamageTaken += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.DamageTaken -= OnHealthChanged;
    }

    protected override void ActivateAbility()
    {
        if (Fighter.CurrentTarget != null)
            Fighter.CurrentTarget.Health.TakeDamage(_targetDamage / _damageValue);
    }

    private void OnHealthChanged()
    {
        if (Fighter.CurrentTarget != null)
        {
            _targetDamage = Fighter.CurrentTarget.Damage;
            ActivateAbility();
        }
    }
}
