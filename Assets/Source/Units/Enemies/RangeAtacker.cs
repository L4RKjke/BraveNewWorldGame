using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FireBallInstantiator))]

public class RangeAtacker : Enemy
{
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;

    private FireBallInstantiator _bulletInstantiator;

    private void Awake()
    {
        _bulletInstantiator = GetComponent<FireBallInstantiator>();
    }

    public override void Atack()
    {
        _bulletInstantiator.Shoot(CurrentTarget, _fireball, _firePoint);
    }
}
