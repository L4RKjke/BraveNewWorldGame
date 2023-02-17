using UnityEngine;

public class EquipTask : AssistantTask
{
    [SerializeField] private GameObject _inventory;

    private bool _needUpdate = true;

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_inventory.activeSelf == true)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
