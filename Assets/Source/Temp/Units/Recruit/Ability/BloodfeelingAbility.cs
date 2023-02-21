using UnityEngine;
//+<_damageBonus>% к урону за каждого умершого противника
public class BloodfeelingAbility : DamageAbility
{
    private float _damage = 1f;

    private readonly float _damageBonus = 0.1f;

    private void Start()
    {
        Fighter.Units.UnitDied += IncreaseDamage;
        AttackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        AttackState.AtackCompleted -= ActivateAbility;
        Fighter.Units.UnitDied -= IncreaseDamage;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        BloodfeelingAbility ability = recruit.gameObject.AddComponent<BloodfeelingAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        var aditionalDamage = Mathf.FloorToInt(Fighter.Damage * _damage) - Fighter.Damage;

        Fighter.CurrentTarget.Health.TakeDamage(aditionalDamage);
    }

    private void IncreaseDamage(FighterType type)
    {
        if (type == Fighter.EnemyType)
            _damage += _damageBonus;
    }
}
