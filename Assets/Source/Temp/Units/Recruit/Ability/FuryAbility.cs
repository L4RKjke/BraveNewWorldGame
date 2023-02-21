using UnityEngine;
///Каждый раз, когда юнит получает урон, его атака увеличивается на <_damageBonus>%;
public class FuryAbility : DamageAbility
{
    private AtackState _atackState;
    private float _damage = 1f;
    
    private readonly float _damageBonus = 0.025f;

    private void Start()
    {
        _atackState = GetComponent<AtackState>();
        Fighter.Health.Damaged += IncreaseDamage;
        _atackState.AtackCompleted += ActivateAbility;
    }

    private void OnDisable()
    {
        _atackState.AtackCompleted -= ActivateAbility;
        Fighter.Health.Damaged -= IncreaseDamage;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        FuryAbility ability = recruit.gameObject.AddComponent<FuryAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        var aditionalDamage = Mathf.FloorToInt(Fighter.Damage * _damage) - Fighter.Damage;

        Fighter.CurrentTarget.Health.TakeDamage(aditionalDamage);
    }

    private void IncreaseDamage(int damage)
    {
        _damage += _damageBonus;
    }
}
