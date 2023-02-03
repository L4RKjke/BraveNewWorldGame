using UnityEngine;
using UnityEngine.UI;

public class UnitHealthbar : Healthbar
{
    [SerializeField] private Fighter _fighter;

    private void Start()
    {
        if (_fighter.Health != null)
            _fighter.Health.HealthChanged += ChangeFill;
    }

    private void OnDisable()
    {
        if (_fighter.Health != null)
            _fighter.Health.HealthChanged -= ChangeFill;
    }

    protected void ChangeFill(int value)
    {
        float damageValue = (float)value / _fighter.Health.MaxHealth;
        Slider.value = damageValue;
    }
}
