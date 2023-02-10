public class SpikesAbility : Ability
{
    // ������ ���� ����� �� �������� �� �������� ����������� �����
    private readonly int _damageValue = 4;

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
        Fighter.Health.Heal(Fighter.Damage / _damageValue);       
    }

    private void OnHealthChanged()
    {
        ActivateAbility();
    }
}
