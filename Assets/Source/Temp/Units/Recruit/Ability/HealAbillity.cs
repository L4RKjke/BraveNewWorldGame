using System.Collections;
using UnityEngine;

public class HealAbillity : Ability
{
    ///Хилит полсе того как юниту нанесли урон
    private readonly float _healDelay = 0.5f;
    private readonly int _healValue = 20;

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


    public override void SetAbility(Recruit recruit)
    {
        recruit.gameObject.AddComponent<HealAbillity>();
    }

    protected override void ActivateAbility()
    {
        _healCoroutine = StartCoroutine(Heal());
    }

    private void OnHealthChanged()
    {
        StopCoroutine(_healCoroutine);
        ActivateAbility();
    }

    private IEnumerator Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(_healDelay);

            Fighter.Health.Heal(Fighter.Health.MaxHealth/ _healValue);
        }

    }
}
