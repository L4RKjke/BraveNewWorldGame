using UnityEngine;
using UnityEngine.UI;

public class InventoryTask : AssistantTask
{
    [SerializeField] private Button _inventory;
    [SerializeField] private GameObject _enchance;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _inventory.interactable = true;
    }

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_enchance.activeSelf == false)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
