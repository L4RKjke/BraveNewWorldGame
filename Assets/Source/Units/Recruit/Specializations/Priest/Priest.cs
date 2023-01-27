using UnityEngine;

[RequireComponent(typeof(FireBallInstantiator))]

public class Priest : Fighter, IRangeAtacker
{
    [SerializeField] private GameObject _healPart;
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _firePoint;

    private int _magicPower = 0;

    private FireBallInstantiator _bulletInstantiator;

    private void Awake()
    {
        _bulletInstantiator = GetComponent<FireBallInstantiator>();
    }

    public void Shoot(int damage)
    {
        var mate = GetWounded();

        if (mate.Health.Value != Health.MaxHealth)
        {
            mate.Health.Heal(mate.Health.MaxHealth);
            ///Эту херовину вынести в приствью
            _healPart.SetActive(true);
            _healPart.GetComponent<HealPartMover>().Init(mate);
            _healPart.GetComponent<HealPartActivator>().Play();
        }

        else
        {
            _bulletInstantiator.Shoot(CurrentTarget, _fireball, _firePoint, EnemyType, damage + _magicPower);
        }
    }

    private Fighter GetWounded()
    {
        float minHealth = Mathf.Infinity;
        Fighter fighter = null;

        for (int i = 0; i < Units.GetLength(FighterType.Recruit); i++)
        {
            var unit = Units.GetById(i, FighterType.Recruit);

            if (unit.Health.Value < minHealth)
            {
                fighter = unit;
                minHealth = Units.GetById(i, FighterType.Recruit).Health.Value;
            }
        }
        return fighter;
    }
}
