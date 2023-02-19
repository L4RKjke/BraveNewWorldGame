using UnityEngine;
using UnityEngine.UI;

public class ArenaTask : AssistantTask
{
    [SerializeField] private Button _arena;
    [SerializeField] private GameObject _inventory;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _arena.interactable = true;
    }

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_inventory.activeSelf == false)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
