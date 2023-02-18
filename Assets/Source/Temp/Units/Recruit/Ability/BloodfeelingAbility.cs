using UnityEngine;

public class BloodfeelingAbility : Ability
{
    ///+10% к урону за каждого умершого противника
    private AtackState _atackState;
    private float _damage = 1f;
    private int _active = 0;

    private readonly float _damageBonus = 0.1f;

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


    public override void SetAbility(Recruit recruit)
    {
        recruit.gameObject.AddComponent<BloodfeelingAbility>();
    }

    protected override void ActivateAbility()
    {
        _active++;
        Debug.Log(_active + "blood");
        Fighter.CurrentTarget.Health.TakeDamage(Mathf.FloorToInt(Fighter.Damage * _damage) - Fighter.Damage);
    }

    private void IncreaseDamage(FighterType type)
    {
        if (type == Fighter.EnemyType)
            _damage += _damageBonus;
    }
}
