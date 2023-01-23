using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class Fighter : MonoBehaviour, IMeleeAtacker
{
    [SerializeField] private Transform _healPoint;
    [SerializeField] Transform _buttonPostion;
    [SerializeField] GameObject _rootModel;
    [SerializeField] private float _meleeDistance;
    [SerializeField] private float _walkDistance;
    [SerializeField] private float _atackDelay;
    [SerializeField] private float _speed;

    private Fighter _currentTarget;
    private int _maxHealth;
    private int _health;
    private ushort _damage;
    private bool _canBeDamaged = true;

    private readonly ushort _maxDamage = 100;

    public float AtackDelay => _atackDelay;

    public float Speed => _speed;

    public float WalkDistance => _walkDistance;

    public float MeleeDistance => _meleeDistance;

    public GameObject RootModel => _rootModel;

    public Transform ButtonPostition => _buttonPostion;

    public Transform HealPoint => _healPoint;

    public ushort Damage => _damage;

    public int Health => _health;

    public int MaxHealth => _maxHealth;

    public Fighter CurrentTarget => _currentTarget;

    public FighterType MyType { get; private set; }

    public FighterType EnemyType { get; private set; }

    public UnitPool Units { get; private set; }

    public UnityAction <Fighter>Died;

    public UnityAction <ushort>HealthChanged;

    public UnityAction Stunned;

    public UnityAction Imortaled;

    private void Start()
    {
        _maxHealth = Health;
    }

    public virtual void Atack(ushort damage)
    {
        CurrentTarget.TakeDamage(damage);
    }

    public void Init(FighterType type, FighterType enemyType, UnitPool units, ushort damage, int health)
    {
        MyType = type;
        EnemyType = enemyType;
        Units = units;
        _damage = damage;
        _health = health;
    }

    public void Heal()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke((ushort)_health);

    }
    
    public void AddHealthPoint()
    {
        if (_health < _maxHealth)
            _health += 1;
    }

    public void UpdateCurrentTarget()
    {
        _currentTarget = Units.GenerateClosestFighter(EnemyType, transform.position);
    }

    public void MakeImmortal() 
    {
        _canBeDamaged = false;
    }

    public void MakeMortal()
    {
        _canBeDamaged = true;
    }

    public void TakeDamage(/*DamageType type,*/ ushort damage)
    {
        if (damage > _maxDamage)
            damage = _maxDamage;

        if (_canBeDamaged)
        {
            _health -= damage;
        }

        if (_health <= 0)
        {
            Died?.Invoke(this);
        }

        HealthChanged?.Invoke((ushort)_health);
    }
}