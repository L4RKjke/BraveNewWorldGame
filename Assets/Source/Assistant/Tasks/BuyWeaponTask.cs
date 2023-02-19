using UnityEngine;
using UnityEngine.UI;

public class BuyWeaponTask : AssistantTask
{
    [SerializeField] private Button _buttonUpdate;
    [SerializeField] private GameObject _shop;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        if (_buttonUpdate != null)
            _buttonUpdate.interactable = false;
    }

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_shop.activeSelf == true)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
