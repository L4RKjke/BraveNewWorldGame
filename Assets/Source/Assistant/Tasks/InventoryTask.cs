using UnityEngine;
using UnityEngine.UI;

public class InventoryTask : AssistantTask
{
    [SerializeField] private Button _inventory;

    private void OnEnable()
    {
        _inventory.interactable = true;
    }
}
