using UnityEngine;
using UnityEngine.UI;

public class ShopTask : AssistantTask
{
    [SerializeField] private Button _shop;
    [SerializeField] private GameObject _tavern;
    [SerializeField] private Hint _hint;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _hint.gameObject.SetActive(true);
        _shop.interactable = true;
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

        else if (_tavern.activeSelf == false)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
