using System.Collections;
using UnityEngine;

public class HealthAbility : Ability
{
    //Увеличивает здоровье на 20%.
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

    public override void SetAbility(Recruit recruit)
    {
        recruit.gameObject.AddComponent<HealthAbility>();
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Fighter.Health.MaxHealth);
    }

    private void OnHealthChanged(int health)
    {
        if (health < Fighter.Health.MaxHealth*0.2f && _isActivated == false)
        {
            ActivateAbility();
            _isActivated = true;
        }
    }
}
