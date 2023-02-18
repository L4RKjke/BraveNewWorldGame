using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonTask : AssistantTask
{
    [SerializeField] private Button _updateButton;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _closeButton.interactable = false;
        _updateButton.interactable = true;
        _arrow.gameObject.SetActive(true);
        ShowMessage(this);
    }

    private void OnDisable()
    {
        if (_updateButton != null)
            _updateButton.interactable = false;
        if (_closeButton != null)
            _closeButton.interactable = false;

        _arrow.gameObject.SetActive(false);
    }
}
