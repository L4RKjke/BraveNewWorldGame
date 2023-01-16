using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Fighter _fighter;

    private void Start()
    {
        _fighter.HealthChanged += ChangeFill;
    }

    private void OnDisable()
    {
        _fighter.HealthChanged -= ChangeFill;
    }

    private void ChangeFill(ushort value)
    {
        float damageValue = (float)value / _fighter.MaxHealth;
        _slider.value = damageValue;
    }
}
