using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpinTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentTimeTXT;
    [SerializeField] private TextMeshProUGUI _MenuTimeTXT;
    [SerializeField] private int _StartMinutes = 5;

    private string _currentTime;
    private Coroutine _coroutineTimer;
    private int _seconds;
    private int _minutes;

    public UnityAction TimeOver;

    private void OnEnable()
    {
        ResetTimer();

        if (_coroutineTimer is not null)
            StopCoroutine(_coroutineTimer);
    }

    private void Start()
    {
        StartTimer();
    }

    private void OnDisable()
    {
        if (_coroutineTimer is not null)
            StopCoroutine(_coroutineTimer);
    }

    public void ResetTimer()
    {
        if (_coroutineTimer is not null)
            StopCoroutine(_coroutineTimer);

        _seconds = 0;
        _minutes = 0;
        _currentTimeTXT.text = "00:00";
    }

    public void StartTimer()
    {
        _seconds = 0;
        _minutes = _StartMinutes;
        _coroutineTimer = StartCoroutine(StartTimerCoroutine());
    }

    public void StopTimer()
    {
        StopCoroutine(_coroutineTimer);
    }

    private IEnumerator StartTimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (_seconds == 0)
            {
                _minutes--;
                _seconds = 60;
            }

            _seconds--;
            _currentTime = _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
            _currentTimeTXT.text = _currentTime;
            _MenuTimeTXT.text = _currentTime;

            if (_seconds == 0 && _minutes == 0)
            {
                TimeOver?.Invoke();
                break;
            }
        }
    }
}
