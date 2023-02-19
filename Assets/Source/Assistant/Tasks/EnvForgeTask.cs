using UnityEngine;
using UnityEngine.UI;

public class EnvForgeTask : AssistantTask
{
    [SerializeField] private Button _forgeButton;
    [SerializeField] private GameObject _shop;
    [SerializeField] private Hint _hint;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _hint.gameObject.SetActive(true);
        _forgeButton.interactable = true;
    }

    private void OnDisable()
    {
        if (_hint != null)
            _hint.gameObject.SetActive(false);
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
