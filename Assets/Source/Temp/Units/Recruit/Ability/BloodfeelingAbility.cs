using UnityEngine;

public class BloodfeelingAbility : Ability
{
    ///+25% � ����� �� ������� �������� ����������
    private AtackState _atackState;
    private float _damage = 1f;

    private readonly float _damageBonus = 0.25f;

    private void OnEnable()
    {
        _atackState = GetComponent<AtackState>();
        Fighter.Units.UnitDied += IncreaseDamage;
        _atackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        _atackState.AtackCompleted -= ActivateAbility;
        Fighter.Units.UnitDied -= IncreaseDamage;
    }

    protected override void ActivateAbility()
    {
        Fighter.CurrentTarget.Health.TakeDamage(Mathf.FloorToInt(Fighter.Damage * _damage) - Fighter.Damage);
    }

    private void IncreaseDamage(FighterType type)
    {
        if (type == Fighter.EnemyType)
            _damage += _damageBonus;
    }
}