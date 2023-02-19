using UnityEngine;
using UnityEngine.UI;

public class EnvForgeTask : AssistantTask
{
    [SerializeField] private Button _forgeButton;
    [SerializeField] private GameObject _shop;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _forgeButton.interactable = true;
    }

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_shop.activeSelf == false)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
