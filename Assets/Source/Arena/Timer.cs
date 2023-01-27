using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentTimeTXT;

    private string _currentTime;
    private Coroutine _coroutineTimer;
    private int _seconds;
    private int _minutes;

    public void StartTimer()
    {
        _coroutineTimer = StartCoroutine(StartTimerCoroutine());
    }
    
    public void StopTimer()
    {
        StopCoroutine(_coroutineTimer);
    }

    private void OnDisable()
    {
        if (_coroutineTimer is not null)
            StopCoroutine(_coroutineTimer);
    }

    private IEnumerator StartTimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (_seconds == 59)
            {
                _minutes++;
                _seconds = _seconds - 59;
            }

            _seconds++;
            _currentTime = _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
            _currentTimeTXT.text = _currentTime; 
        }
    }
}
