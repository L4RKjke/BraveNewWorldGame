using System.Collections;
using UnityEngine;

public class HealthAbility : Ability
{
    //Увеличивает здоровье на 40%.
    private bool _isActivated = false;

    private void Start()
    {
        _isActivated = false;
        Fighter.Health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Fighter.Health.HealthChanged -= OnHealthChanged;
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
        if (health < Fighter.Health.MaxHealth*0.4f && _isActivated == false)
        {
            ActivateAbility();
            _isActivated = true;
        }
    }
}
