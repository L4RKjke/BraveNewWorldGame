using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]

public abstract class Fighter : MonoBehaviour, IMeleeAtacker
{
    [SerializeField] GameObject _rootModel;
    [SerializeField] private float _meleeDistance;
    [SerializeField] private float _walkDistance;
    [SerializeField] private float _atackDelay;
    [SerializeField] private float _speed;

    private Health _health;
    private Fighter _currentTarget;
    private int _damage;

    public FighterType MyType { get; private set; }

    public FighterType EnemyType { get; private set; }

    public UnitPool Units { get; private set; }

    public Health Health => _health;

    public float AtackDelay => _atackDelay;

    public float Speed => _speed;

    public float WalkDistance => _walkDistance;

    public float MeleeDistance => _meleeDistance;

    public GameObject RootModel => _rootModel;


    public int Damage => _damage;

    public Fighter CurrentTarget => _currentTarget;

    public void Init(FighterType type, FighterType enemyType, UnitPool units, ushort damage, int health)
    {
        _health = GetComponent<Health>();
        MyType = type;
        EnemyType = enemyType;
        Units = units;
        _damage = damage;
        _health.Init(health);
    }

    public virtual void Atack(int damage)
    {
        if (CurrentTarget != null)
            CurrentTarget._health.TakeDamage(damage);
    }

    public void UpdateCurrentTarget()
    {
        _currentTarget = Units.GenerateClosestFighter(EnemyType, transform.position);
    }
}