using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FireBallInstantiator))]

public class Priest : Recruit, IRangeAtacker
{
    [SerializeField] private GameObject _healPart;
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;

    private FireBallInstantiator _bulletInstantiator;
    private Fighter _mate;

    public Fighter Mate => _mate;

    public UnityAction HealStarted;

    private void Awake()
    {
        _bulletInstantiator = GetComponent<FireBallInstantiator>();
    }

    public void Shoot(int damage)
    {
        ChooseAtack(OnDefaultAtack, OnAdvancedAtack);
    }

    protected override void OnDefaultAtack()
    {
        _bulletInstantiator.Shoot(CurrentTarget, _fireball, _firePoint, EnemyType, Damage + MagicPower);
    }

    protected override void OnAdvancedAtack()
    {
        var mate = GetWounded();
        _mate = mate;
        mate.Health.Heal(mate.Health.MaxHealth);
        HealStarted?.Invoke();
    }

    private Fighter GetWounded()
    {
        float minHealth = Mathf.Infinity;
        Fighter fighter = null;

        for (int i = 0; i < Units.GetLength(Unit.Type); i++)
        {
            var unit = Units.GetById(i, Unit.Type);

            if (unit.Health.Value < minHealth)
            {
                fighter = unit;
                minHealth = Units.GetById(i, Unit.Type).Health.Value;
            }
        }
        return fighter;
    }
}
