using UnityEngine;

//ƒовабл€ет <damageFactor>% урона текущего врага к свему.
public class TheftAbility : DamageAbility
{
    private float _damageFactor = 0.5f;

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
        throw new System.NotImplementedException();
    }

    protected override void ActivateAbility()
    {
        var damage = Mathf.FloorToInt(Fighter.CurrentTarget.Damage * _damageFactor);

        Fighter.CurrentTarget.Health.TakeDamage(damage);
    }
}