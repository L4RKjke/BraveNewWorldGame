using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SquadHealthbar : Healthbar
{
    [SerializeField] private UnitPool _units;
    [SerializeField] private FighterType _type;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _redHealthbar;

    private int _maxHealth;
    private Coroutine _corutine;

    private readonly float _healthRate = 0.12f;

    public UnityAction HealthOver;

    private void OnEnable()
    {
        UpdateHealthbar();
    }

    private void OnDisable()
    {
        if (_corutine != null)
            StopCoroutine(_corutine);

        Fighter unit;

        for (int i = 0; i < _units.GetLength(_type); i++)
        {
            unit = _units.GetById(i, _type);

            if (unit != null)
                _units.GetById(i, _type).Health.HealthChanged -= OnHealthChanged;
        }
    }

    public void UpdateHealthbar()
    {
        _maxHealth = 0;

        for (int i = 0; i < _units.GetLength(_type); i++)
        {
            var unit = _units.GetById(i, _type);

            if (unit != null && unit.Health.HealthChanged != null)
            {
                _maxHealth += unit.Health.MaxHealth;
                unit.Health.HealthChanged += OnHealthChanged;
            }
        }

        _redHealthbar.fillAmount = 1;
        Slider.value = 1;
        _healthText.text = _maxHealth.ToString() + "/" + _maxHealth.ToString();
    }

    private void OnHealthChanged(int health)
    {

        float damageValue;
        var squadHealth = 0;

        for (int i = 0; i < _units.GetLength(_type); i++)
        {
            squadHealth += _units.GetById(i, _type).Health.Value;
        }

        damageValue = (float)squadHealth / _maxHealth;

        _healthText.text = squadHealth.ToString() + "/" + _maxHealth.ToString();

        if (_corutine is not null)
            StopCoroutine(_corutine);

        _redHealthbar.fillAmount = damageValue;

        if (enabled == true)
            _corutine = StartCoroutine(SetHealth(damageValue));

        if (squadHealth == 0)
            HealthOver?.Invoke();
    }

    private IEnumerator SetHealth(float target)
    {
        while (Slider.value != target)
        {
            yield return Slider.value = Mathf.MoveTowards(Slider.value, target, _healthRate * Time.deltaTime);
        }
    }
}