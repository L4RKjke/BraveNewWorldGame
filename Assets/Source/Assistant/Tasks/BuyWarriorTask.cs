using UnityEngine;
using UnityEngine.UI;

public class BuyWarriorTask : AssistantTask
{
    [SerializeField] private Button _updateButton;
    [SerializeField] private GameObject _tavern;

    private bool _needUpdate = true;

    private void OnEnable() 
    {
        _updateButton.interactable = false;
    }

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_tavern.activeSelf == true)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }      
}
