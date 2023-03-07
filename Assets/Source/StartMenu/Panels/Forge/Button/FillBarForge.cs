using UnityEngine;

public class FillBarForge : FillBarUI
{
    private Coroutine _fill;

    public void StartFill(Color color, float timeToFill = 3)
    {
        SetColor(color);
        _fill = StartCoroutine(FillProgress(timeToFill));
    }

    public void OffFill()
    {
        if(_fill != null)
        {
            StopCoroutine(_fill);
            _fill = null;
        }

        ResetFill();
    }
}
