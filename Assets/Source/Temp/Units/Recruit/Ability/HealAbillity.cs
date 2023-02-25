using System.Collections;
using UnityEngine;

public class HealAbillity : Ability
{
    ///Хилит на 3% от максимального здоровья при получении урона.
    private readonly float _healDelay = 0.5f;
    private readonly float _healValue = 0.03f;

    private void OnEnable()
    {
        Fighter.Health.Damaged += DamageTaken;
    }

    private void OnDisable()
    {
        Fighter.Health.Damaged -= DamageTaken;
    }


    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        HealAbillity ability = recruit.gameObject.AddComponent<HealAbillity>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        StartCoroutine(Heal());
    }

    private void DamageTaken(int health = 0)
    {
        Fighter.Health.Damaged -= DamageTaken;

        if (Fighter.Health.Value > 0)
        {
            ActivateAbility();
        }
    }

    private IEnumerator Heal()
    {
        Fighter.Health.Heal((int)(Fighter.Health.MaxHealth * _healValue));
        yield return new WaitForSeconds(_healDelay);
        Fighter.Health.Damaged += DamageTaken;
    }
}