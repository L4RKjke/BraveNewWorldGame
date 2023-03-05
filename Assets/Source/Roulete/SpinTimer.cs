using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpinTimer : MonoBehaviour
{
    private int _startMinutes = 1;
    private string _currentTime;
    private Coroutine _coroutineTimer;
    private int _seconds;
    private int _minutes;

    public string CurrentTime => _currentTime;

    public UnityAction TimeOver;
    public UnityAction<string> TimeUpdated;

    private void OnDisable()
    {
        if (_coroutineTimer is not null)
            StopCoroutine(_coroutineTimer);
    }

    public void SetMinutes(int minutes)
    {
        if (minutes < 0)
            minutes = 0;
        if (minutes > 59)
            minutes = 59;

        _startMinutes += minutes;
    }

    public void ResetMinutes()
    {
        _startMinutes = 0;
    }

    public void ResetTimer()
    {
        if (_coroutineTimer is not null)
            StopCoroutine(_coroutineTimer);

        _seconds = 0;
        _minutes = 0;
    }

    public void StartTimer()
    {
        if (_coroutineTimer is not null)
            StopCoroutine(_coroutineTimer);

        _seconds = 0;
        _minutes = _startMinutes;
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

            TimeUpdated?.Invoke(_currentTime);

            if (_seconds == 0 && _minutes == 0)
            {
                TimeOver?.Invoke();
                break;
            }
        }
    }
}