using UnityEngine;
using UnityEngine.UI;

public class TavernTask : AssistantTask
{
    [SerializeField] private Button _tavern;
    [SerializeField] private Hint _hint;

    private void OnEnable()
    {
        _hint.gameObject.SetActive(true);
        _tavern.interactable = true;
        ShowMessage(this);
    }

    private void OnDisable()
    {
        if (_hint != null)
            _hint.gameObject.SetActive(false);
    }
}
