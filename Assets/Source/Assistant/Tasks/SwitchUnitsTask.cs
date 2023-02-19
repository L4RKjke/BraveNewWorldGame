using UnityEngine;

public class SwitchUnitsTask : AssistantTask
{
    [SerializeField] private Arrow _arrow;

    private void OnEnable()
    {
        _arrow.gameObject.SetActive(true);
        ShowMessage(this);
    }

    private void OnDisable()
    {
        if (_arrow != null)
            _arrow.gameObject.SetActive(false);
    }
}
