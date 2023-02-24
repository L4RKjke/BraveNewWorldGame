using UnityEngine;

//ƒовабл€ет <damageFactor>% урона текущего врага к свему.
public class TheftAbility : DamageAbility
{
    private float _damageFactor = 0.2f;

    private void Start()
    {
        AttackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        AttackState.AtackCompleted -= ActivateAbility;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        TheftAbility ability = recruit.gameObject.AddComponent<TheftAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        var damage = Mathf.FloorToInt(Fighter.CurrentTarget.Damage * _damageFactor);

        Fighter.CurrentTarget.Health.TakeDamage(damage, Health.DamageType.Physical);
    }
}