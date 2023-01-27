using UnityEngine;
using UnityEngine.UI;

public abstract class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public Slider Slider => _slider;
}
