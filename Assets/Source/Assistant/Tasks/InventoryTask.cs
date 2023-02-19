using UnityEngine;
using UnityEngine.UI;

public class InventoryTask : AssistantTask
{
    [SerializeField] private Button _inventory;
    [SerializeField] private GameObject _enchance;
    [SerializeField] private Hint _hint;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _inventory.interactable = true;
        _hint.gameObject.SetActive(true);
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

        else if (_enchance.activeSelf == false)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
