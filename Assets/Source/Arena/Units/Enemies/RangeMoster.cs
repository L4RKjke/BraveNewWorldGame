using UnityEngine;

public class RangeMoster : Fighter, IRangeAtacker
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

    public float GetRangeAtackDelay()
    {
        return AtackDelay;
    }
}