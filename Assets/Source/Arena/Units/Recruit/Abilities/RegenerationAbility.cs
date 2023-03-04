using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerationAbility : Ability
{
    //¬осстанавливает <_healValue%> очков здоровь€ каждые <_healDelay> секунд.
    private float _healDelay = 1f;
    private float _healValue = 0.025f;

    private Coroutine _healCoroutine;

    private void Start()
    {
        Fighter.Health.Damaged += OnHealthChanged;
    }

    private void OnDisable()
    {
        if (_healCoroutine != null)
            StopCoroutine(_healCoroutine);

        Fighter.Health.Damaged -= OnHealthChanged;
    }

    public override void SetAbility(Recruit recruit, string namePath, string desriptionPath)
    {
        RegenerationAbility ability = recruit.gameObject.AddComponent<RegenerationAbility>();
        ability.SetAbilitiesDescription(namePath, desriptionPath);
    }

    protected override void ActivateAbility()
    {
        _healCoroutine = StartCoroutine(Heal());
    }

    private void OnHealthChanged(int value)
    {
        if (_healCoroutine != null)
            StopCoroutine(_healCoroutine);

        ActivateAbility();
    }

    private IEnumerator Heal()
    {
        while (Fighter.Health.Value < Fighter.Health.MaxHealth)
        {
            yield return new WaitForSeconds(_healDelay);

            var healthPoints = Mathf.FloorToInt(Fighter.Health.MaxHealth * _healValue);

            Fighter.Health.Heal(healthPoints);
        }

    }
}
