using UnityEngine;
using UnityEngine.UI;

public class BuyWarriorTask : AssistantTask
{
    [SerializeField] private Button _updateButton;
    [SerializeField] private GameObject _tavern;
    [SerializeField] private Arrow _arrow;

    private bool _needUpdate = true;

    private void OnEnable() 
    {
        _arrow.gameObject.SetActive(true);
        _updateButton.interactable = false;
    }

    private void OnDisable()
    {
        if (_arrow != null)
            _arrow.gameObject.SetActive(false);
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
