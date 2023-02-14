using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : Condition
{
    [SerializeField] private Button _button;

    public Button Button => _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(() => OnButtonClick());
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => OnButtonClick());
    }

    private void OnButtonClick()
    {
        NeedTransit = true;
    }
}
