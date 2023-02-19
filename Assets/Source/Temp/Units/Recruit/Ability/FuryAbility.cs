using UnityEngine;

public class FuryAbility : Ability
{
    ///+2.5% когда юнит получает урон
    private AtackState _atackState;
    private float _damage = 1f;
    
    private readonly float _damageBonus = 0.025f;

    private void OnEnable()
    {
        _atackState = GetComponent<AtackState>();
        Fighter.Health.DamageTaken += IncreaseDamage;
        _atackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        _atackState.AtackCompleted -= ActivateAbility;
        Fighter.Health.DamageTaken -= IncreaseDamage;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        FuryAbility ability = recruit.gameObject.AddComponent<FuryAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        Fighter.CurrentTarget.Health.TakeDamage(Mathf.FloorToInt(Fighter.Damage * _damage) - Fighter.Damage);
    }

    private void IncreaseDamage()
    {
        _damage += _damageBonus;
    }
}
