using UnityEngine;

public class HealthAbility : Ability
{
    //C вероятностью <_healPercent> может полностью восстановить здоровье.
    private float _healPercent = 0.05f;

    private readonly float _minPercent = 0;
    private readonly float _maxPercent = 100;

    private void Start()
    {
        Fighter.Health.Damaged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.Damaged -= OnHealthChanged;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        HealthAbility ability = recruit.gameObject.AddComponent<HealthAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Fighter.Health.MaxHealth);
    }

    private void OnHealthChanged(int health)
    {
        var radomValue = Random.Range(_minPercent, _maxPercent);

        if (radomValue < _healPercent)
        {
            ActivateAbility();
        }
    }
}