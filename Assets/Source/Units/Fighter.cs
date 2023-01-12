using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private Fighter _currentTarget;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _healPoint;

    private NavMeshAgent _agent;
    private int _health;
    private ushort _damage;
    private float _speed;
    private float _defaultSpeed = 1.1f;
    private bool _canBeDamaged = true;

    private readonly ushort _maxDamage = 100;
    private readonly int _maxHealth = 100;

    public Transform HealPoint => _healPoint;

    public Weapon Weapon => _weapon;

    public ushort Damage => _damage;

    public int Health => _health;

    public float Speed => _speed;

    public Fighter CurrentTarget => _currentTarget;

    public FighterType RecruitType { get; private set; }

    public FighterType EnemyType { get; private set; }

    public UnitPool Units { get; private set; }

    public FighterStats Stats { get; private set; }

    public Vector2 InvertedScale { get; private set; }

    public Vector2 DefoaltScale { get; private set; }

    public UnityAction <Fighter>Died;

    public UnityAction <ushort>FighterHitted;

    public UnityAction Stunned;

    public UnityAction Imortaled;

    private void Start()
    {
        if (transform.GetChild(0).TryGetComponent(out Weapon weapon))
        {
            _weapon = weapon;
        }

        _agent = GetComponent<NavMeshAgent>();
        _speed = _agent.speed;
        InvertedScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        DefoaltScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    private void Update()
    {
        /*_currentTarget = Units.GenerateClosestFighter(EnemyType, transform.position);*/

        if (CurrentTarget != null)
        {
            if (CurrentTarget.transform.position.x > transform.position.x)
                transform.localScale = InvertedScale;
            else
                transform.localScale = DefoaltScale;
        }
        ///for test in inspecotor
        HP = _health;
    }

    public void Init(FighterType type, FighterType enemyType, UnitPool units, ushort damage, int health)
    {
        RecruitType = type;
        EnemyType = enemyType;
        Units = units;
        _damage = damage;
        _health = health;
    }

    public void Heal()
    {
        _health = _maxHealth;
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

    public void MakeUnmovable()
    {
        if (_agent != null)
            _agent.speed = 0;
    }

    public void MakeMoveble()
    {
        if (_agent != null)
            _agent.speed = _defaultSpeed;
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
            _health -= damage;/*Mathf.FloorToInt(Mathf.Lerp(_health, _minHealth, damage));*/

        if (_health <= 0)
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }

        FighterHitted?.Invoke(damage);
    }
}