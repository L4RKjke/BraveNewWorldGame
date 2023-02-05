using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class FillBarUI : MonoBehaviour
{
    [SerializeField] private Image _fill;

    private float _currentTimeFill = 0;

    public Image Fill => _fill;
    
    public event UnityAction FillEnd;

    public void SetFillComplete()
    {
        _fill.fillAmount = 1;
    }

    protected void SetColor(Color color)
    {
        _fill.color = color;
    }

    protected void ResetFill()
    {
        _fill.fillAmount = 0;
        _currentTimeFill = 0;
    }

    protected IEnumerator FillProgress(float timeToFill)
    {
        while (_fill.fillAmount < 1)
        {
            FillIn(timeToFill);
            yield return null;
        }
    }

    private void FillIn(float timeToFill)
    {
        _currentTimeFill += Time.deltaTime;
        _fill.fillAmount = _currentTimeFill / timeToFill;
        Mathf.Clamp(_fill.fillAmount, 0, 1);

        if (_currentTimeFill >= timeToFill)
        {
            FillEnd?.Invoke();
            _currentTimeFill = 0;
        }
    }
}
