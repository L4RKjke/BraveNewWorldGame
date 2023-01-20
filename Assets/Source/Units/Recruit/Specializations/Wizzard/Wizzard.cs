using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FireBallInstantiator))]

public class Wizzard : Recruit, IRangeAtacker
{
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _electricity;

    private FireBallInstantiator _bulletInstantiator;

    public Fireball Fireball => _fireball;

    private void Awake()
    {
        _bulletInstantiator = GetComponent<FireBallInstantiator>();
    }

    public void Shoot(ushort damage)
    {
        _bulletInstantiator.Shoot(CurrentTarget, _fireball, _firePoint, EnemyType, damage);
    }
}