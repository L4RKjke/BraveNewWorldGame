using UnityEngine;

// Каждый удар вы дополнительно наносите магический урон.
public class ExtraMagicDamage : DamageAbility
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
        Fighter.CurrentTarget.Health.TakeDamage(Fighter.MagicPower, Health.DamageType.Magical);
        _damageBonus += 0.1f;
    }
}