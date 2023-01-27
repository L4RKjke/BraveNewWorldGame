using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _value;
    private Fighter _unit;

    public UnityAction<int> HealthChanged;

    public UnityAction<Fighter> Died;

    private int _maxHealth = 150;

    private readonly int _minHealth = 0;

    public int MaxHealth => _maxHealth;

    public int Value => _value;

    private void Awake()
    {
        _unit = GetComponent<Fighter>();
        _maxHealth = _value;
    }

    public void Init(int health)
    {
        _value = health;
    }

    public void Heal(int healPoints)
    {
        if (healPoints < 0)
            healPoints = 0;

        _value += healPoints;

        if (_value > _maxHealth)
            _value = _maxHealth;

        HealthChanged?.Invoke(_value);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            damage = 0;

        if (damage > _value)
            damage = _value;

        if (_value > _minHealth)
            _value -= damage;

        if (_value < 0)
            _value = _minHealth;

        if (_value <= 0)
        {
            Died?.Invoke(_unit);
        }

        HealthChanged?.Invoke(_value);
    }
}
