using UnityEngine;

public class Eye : Enemy, IRangeAtacker
{
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;

    private FireBallInstantiator _bulletInstantiator;

    public Fireball Fireball => _fireball;

    private void Awake()
    {
        _bulletInstantiator = GetComponent<FireBallInstantiator>();
    }

    public void Shoot(int damage)
    {
        _bulletInstantiator.Shoot(CurrentTarget, _fireball, _firePoint, EnemyType, damage);
    }
}