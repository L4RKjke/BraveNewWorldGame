using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfBlood : Ability
{
    //C вероятностью <_healPercent> может полностью восстановить здоровье.
    private int _healPercent = 2;

    private readonly int _minPercent = 0;
    private readonly int _maxPercent = 100;

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
        ElfBlood ability = recruit.gameObject.AddComponent<ElfBlood>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        Fighter.Health.Heal(Fighter.Health.MaxHealth);
    }

    private void OnHealthChanged(int health)
    {
        if (Fighter.Health.Value > 0)
        {
            int radomValue = Random.Range(_minPercent, _maxPercent + 1);

            if (radomValue < _healPercent)
            {
                ActivateAbility();
            }
        }
        else
        {
            Fighter.Health.Damaged -= OnHealthChanged;
        }
    }
}
