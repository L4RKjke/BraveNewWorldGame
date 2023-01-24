using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Fighter _fighter;

    private void Start()
    {
        _fighter.Health.HealthChanged += ChangeFill;
    }

    private void OnDisable()
    {
        _fighter.Health.HealthChanged -= ChangeFill;
    }

    private void ChangeFill(int value)
    {
        float damageValue = (float)value / _fighter.Health.MaxHealth;
        _slider.value = damageValue;
    }
}
