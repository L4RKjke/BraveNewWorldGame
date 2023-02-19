using UnityEngine;
using UnityEngine.UI;

public class EnhanceTask : AssistantTask
{
    [SerializeField] private GameObject _enchance;
    [SerializeField] private Button _closeButton;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _closeButton.interactable = false;
    }

    private void OnDisable()
    {
        if (_closeButton != null)
            _closeButton.interactable = true;
    }

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_enchance.activeSelf == true)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
