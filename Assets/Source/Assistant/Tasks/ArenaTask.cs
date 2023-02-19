using UnityEngine;
using UnityEngine.UI;

public class ArenaTask : AssistantTask
{
    [SerializeField] private Button _arena;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private Hint _hint;

    private bool _needUpdate = true;

    private void OnEnable()
    {
        _arena.interactable = true;
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

        else if (_inventory.activeSelf == false)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
