using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour, IItem
{
    private WeaponAbility _ability;

    private readonly float _abilityDelay = 1; 

    private void Awake()
    {
        if (TryGetComponent(out WeaponAbility ability))
        {
            _ability = ability;
            StartCoroutine(LounchAbilityCorutine());
        }
    }

    private void OnDisable()
    {
        StopCoroutine(LounchAbilityCorutine());
    }

    public void UseWeaponAbility(WeaponAbility ability)
    {
        ability.ActivateAbility();
    }

    abstract public void UseWeapon();

    private IEnumerator LounchAbilityCorutine()
    {
        yield return new WaitForSeconds(_abilityDelay);

        UseWeaponAbility(_ability);
    }
}
