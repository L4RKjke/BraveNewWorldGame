using UnityEngine;

public class EnhanceTask : AssistantTask
{
    [SerializeField] private GameObject _enchance;

    private bool _needUpdate = true;

    private void Update()
    {
        if (_needUpdate == false)
            return;

        else if (_enchance.activeSelf == true)
        {
            ShowMessage(this);
            _needUpdate = false;
        }
    }
}
