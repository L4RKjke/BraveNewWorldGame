using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _value;
    private int _armor = 0;
    private Fighter _unit;

    public UnityAction<int> HealthChanged;
    public UnityAction DamageTaken;
    public UnityAction<Fighter> Died;

    private int _maxHealth = 0;

    private readonly int _minHealth = 0;

    public int MaxHealth => _maxHealth;

    public int Value => _value;

    private void OnEnable()
    {
        _unit = GetComponent<Fighter>();
        //_maxHealth = _value;
    }

    public void Init(int health, int defence = 0)
    {
        _armor = defence;
        _value = health;
        _maxHealth = _value;
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
        damage -= _armor;

        if (damage < 0)
            damage = 0;

        if (damage > _value)
            damage = _value;

        if (_value > _minHealth)
        {
            _value -= damage;
            DamageTaken?.Invoke();
        }

        /*_value = Mathf.Clamp(damage, _minHealth, _value);*/

        if (_value < 0)
            _value = _minHealth;

        if (_value <= 0)
        {
            Died?.Invoke(_unit);
        }

        HealthChanged?.Invoke(_value);
    }
}