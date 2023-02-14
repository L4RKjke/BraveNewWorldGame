using UnityEngine;
using UnityEngine.UI;

public class BuyWeaponTask : AssistantTask
{
    [SerializeField] private Button _buttonUpdate;

    private void OnEnable()
    {
        _buttonUpdate.interactable = false;
    }
}
