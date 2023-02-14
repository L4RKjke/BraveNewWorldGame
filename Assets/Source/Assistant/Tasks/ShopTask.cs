using UnityEngine;
using UnityEngine.UI;

public class ShopTask : AssistantTask
{
    [SerializeField] private Button _shop;
    [SerializeField] private GameObject _tavern;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _shop.interactable = true;
        HintController.ActivateHint(_shop);
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
