using UnityEngine;

// ƒополнительный магический урон при атаках: <_damageBonus>%
public class MagicDamage : DamageAbility
{
    private float _damageBonus = 0.1f;

    protected void Start()
    {
        AttackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        AttackState.AtackCompleted -= ActivateAbility;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        throw new System.NotImplementedException();
    }

    protected override void ActivateAbility()
    {
        int damage = Mathf.FloorToInt(Fighter.Damage * _damageBonus);

        Fighter.CurrentTarget.Health.TakeDamage(damage, Health.DamageType.Magical);
        _damageBonus += 0.1f;
    }
}