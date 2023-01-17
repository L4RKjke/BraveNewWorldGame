using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FireBallInstantiator))]

public class Wizzard : Recruit
{
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _electricity;

    private FireBallInstantiator _bulletInstantiator;

    public Fireball Fireball => _fireball;

    private readonly ushort _passiveAbilityDamage = 30;

    private void Awake()
    {
        _bulletInstantiator = GetComponent<FireBallInstantiator>();
    }

    public override void Atack()
    {
        _bulletInstantiator.Shoot(CurrentTarget, _fireball, _firePoint);
    }

    public override void UsePassiveSkill()
    {
        if (CurrentTarget != null)
        {
            CurrentTarget.TakeDamage(_passiveAbilityDamage);
            _electricity.SetActive(true);
            _electricity.GetComponent<ParticleSystem>().Play();
            _electricity.transform.position = new Vector2(CurrentTarget.transform.position.x, CurrentTarget.transform.position.y);
        }
    }
}