using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    private WeaponAbility _ability;

    private readonly float _abilityDelay = 7;

    protected readonly string AbilityCorutine = "LounchAbilityCorutine";

    public ushort Damage { get; private set; } = 15;

    private void OnEnable()
    {
        if (TryGetComponent(out WeaponAbility ability))
        {
            _ability = ability;
            StartCoroutine(AbilityCorutine);
        }
    }

    private void OnDisable()
    {
        if (TryGetComponent(out WeaponAbility ability))
        {
            StopCoroutine(AbilityCorutine);
        }
    }

    public void Init(ushort damage)
    {
        Damage = damage;
    }

    public void UseWeaponAbility(WeaponAbility ability)
    {
        ability.ActivateAbility();
    }

    public void IncreaseDamage(ushort amplifier)
    {
        Damage += amplifier;
    }

    private IEnumerator LounchAbilityCorutine()
    {
        yield return new WaitForSeconds(_abilityDelay);

        UseWeaponAbility(_ability);
    }
}
