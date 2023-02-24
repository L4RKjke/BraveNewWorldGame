using UnityEngine;
// Дополнительный урон при атаках: <_damageBonus>%

public class DamageBoosterAbility : DamageAbility
{
    private float _damageBonus = 0.33f;

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
        DamageBoosterAbility ability = recruit.gameObject.AddComponent<DamageBoosterAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        int damage = Mathf.FloorToInt(Fighter.Damage * _damageBonus);

        Fighter.CurrentTarget.Health.TakeDamage(damage, Health.DamageType.Physical);
        _damageBonus += 0.1f;
    }
}
