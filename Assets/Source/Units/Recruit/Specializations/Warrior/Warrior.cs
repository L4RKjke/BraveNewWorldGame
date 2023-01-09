public class Warrior : Recruit
{
    private ushort _currentDamage;

    private readonly ushort _damageMultiplier = 2;

    private void Start()
    {
        _currentDamage = Damage;
    }

    public override void Atack()
    {
        if (CurrentTarget != null)
            CurrentTarget.TakeDamage(_currentDamage);
    }

    public override void UseAdvancedAtack()
    {
        _currentDamage *= _damageMultiplier;
    }

    public override void UseUltimate()
    {
        Heal();
    }
}
