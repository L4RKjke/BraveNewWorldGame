using System.Collections;
using UnityEngine;

public class HealAbillity : Ability
{
    private readonly float _healDelay = 0.5f;
    private readonly int _healValue = 20;

    private Coroutine _healCoroutine;

    private void Start()
    {
       Fighter.Health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        StopCoroutine(_healCoroutine);
    }

    protected override void ActivateAbility()
    {
        _healCoroutine = StartCoroutine(Heal());
    }

    private void OnHealthChanged(int health)
    {
        ActivateAbility();
        Fighter.Health.HealthChanged -= OnHealthChanged;
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
