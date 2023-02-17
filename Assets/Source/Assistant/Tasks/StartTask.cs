using UnityEngine;
using UnityEngine.UI;

public class StartTask : AssistantTask
{
    [SerializeField] private Button _tavern;
    [SerializeField] private Button _inventory;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _anvil;
    [SerializeField] private Button _arena;

    private void OnEnable()
    {
        _inventory.interactable = false;
        _shop.interactable = false;
        _anvil.interactable = false;
        _arena.interactable = false;
        _tavern.interactable = false;
        ShowMessage(this);
    }
}
