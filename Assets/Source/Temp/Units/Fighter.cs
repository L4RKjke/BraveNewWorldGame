using UnityEngine;

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

    public FighterType Type { get; private set; }

    public FighterType EnemyType { get; private set; }

    public UnitPool Units { get; private set; }

    public Health Health => _health;

    public float AtackDelay => _atackDelay;

    public float Speed => _speed;

    public float WalkDistance => _walkDistance;

    public float MeleeDistance => _meleeDistance;

    public GameObject RootModel => _rootModel;

    public int Damage => _damage;

    public Fighter Unit => this;

    public Fighter CurrentTarget => _currentTarget;

    private void Start()
    {
        var randomSpread = Random.Range(-0.2f, 0.2f);
 
        _walkDistance += randomSpread;

        if (TryGetComponent<Warrior>(out _))
            _meleeDistance = _walkDistance;
    }

    public void Init(FighterType type, FighterType enemyType, UnitPool units, int damage, int health)
    {
        _health = GetComponent<Health>();
        Type = type;
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
        _currentTarget = GetClosestTarget();
        /*_currentTarget = Units.GenerateClosestFighter(EnemyType, transform.position);*/
    }
    private Fighter GetClosestTarget()
    {
        Fighter target = null;
        float minDistance = Mathf.Infinity;

        for (int i = 0; i < Units.GetLength(EnemyType); i++)
        {
            var fighter = Units.GetById(i, EnemyType);
            float distance = Vector2.Distance(Units.GetById(i, EnemyType).transform.position, transform.position);

            if (distance < minDistance)
            {
                target = fighter;
                minDistance = distance;
            }
        }

        return target;
    }
}