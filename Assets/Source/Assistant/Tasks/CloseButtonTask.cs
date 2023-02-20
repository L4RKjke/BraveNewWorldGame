using UnityEngine;
using UnityEngine.UI;

public class CloseButtonTask : AssistantTask
{
    [SerializeField] private Button _sloseButton;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Button _currentPanelButton;
    [SerializeField] private GameObject _blockPanel;

    private void OnEnable()
    {
        _sloseButton.interactable = true;
        ShowMessage(this);
        _arrow.gameObject.SetActive(true);

        if (_blockPanel != null)
            _blockPanel.SetActive(true);
    }

    private void OnDisable()
    {
        if (_blockPanel != null)
            _blockPanel.SetActive(false);

        if (_currentPanelButton != null)
            _currentPanelButton.interactable = false;
    }
}
