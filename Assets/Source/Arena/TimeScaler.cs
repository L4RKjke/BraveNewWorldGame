using UnityEngine;
using UnityEngine.UI;

public class TimeScaler : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;

    public void OnSlide()
    {
        Time.timeScale = _timeSlider.value;
    }
}
