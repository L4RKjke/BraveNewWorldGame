using UnityEngine;

public class Eye : Enemy, IRangeAtacker
{

    /// мб чел просто будет магом, и тогда убрать класс енеми. но тогда у типа могуд быть абилки, так что наверно оставить как есть

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