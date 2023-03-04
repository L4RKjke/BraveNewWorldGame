using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FireBallInstantiator))]

public class Wizzard : Recruit, IRangeAtacker
{
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;

    private int _magicIncrease = 10;
    private FireBallInstantiator _bulletInstantiator;

    public Fireball Fireball => _fireball;

    public UnityAction LightningUsed;

    private void Awake()
    {
        _bulletInstantiator = GetComponent<FireBallInstantiator>();
    }

    public void Shoot(int damage)
    {
        ChooseAtack(OnDefaultAtack, OnAdvancedAtack);
    }

    public float GetRangeAtackDelay()
    {
        return AtackDelay;
    }

    protected override void OnDefaultAtack()
    {
        _bulletInstantiator.Shoot(CurrentTarget, _fireball, _firePoint, EnemyType, Damage + MagicPower);
    }

    protected override void OnAdvancedAtack()
    {
        base.Atack(MagicPower * _magicIncrease);
        LightningUsed?.Invoke();
    }
}