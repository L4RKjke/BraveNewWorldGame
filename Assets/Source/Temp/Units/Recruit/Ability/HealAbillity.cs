using System.Collections;
using UnityEngine;

public class HealAbillity : Ability
{
    ///Хилит на 3% от максимального здоровья при получении урона.
    private readonly float _healDelay = 0.5f;
    private readonly float _healValue = 0.03f;

    private Coroutine _healCoroutine;

    private void OnEnable()
    {
       Fighter.Health.DamageTaken += OnHealthChanged;
    }

    private void OnDisable()
    {
        if (_healCoroutine != null)
            StopCoroutine(_healCoroutine);

        Fighter.Health.DamageTaken -= OnHealthChanged;
    }


    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        HealAbillity ability = recruit.gameObject.AddComponent<HealAbillity>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        _healCoroutine = StartCoroutine(Heal());
    }

    private void OnHealthChanged()
    {
        if(_healCoroutine == null)
        ActivateAbility();
    }

    private IEnumerator Heal()
    {
        bool isHealed = false;

        while (isHealed == false)
        {
            Fighter.Health.Heal((int)(Fighter.Health.MaxHealth * _healValue));
            yield return new WaitForSeconds(_healDelay);
            isHealed = true;
        }

        _healCoroutine = null;
    }
}
