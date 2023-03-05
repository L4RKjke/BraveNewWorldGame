public abstract class DamageAbility : Ability
{
    private AtackState _attackState;

    protected AtackState AttackState => _attackState;

    protected void Awake()
    {
        _attackState = GetComponent<AtackState>();
    }
}
