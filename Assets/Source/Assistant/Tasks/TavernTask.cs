using UnityEngine;
using UnityEngine.UI;

public class TavernTask : AssistantTask
{
    [SerializeField] private Button _tavern;

    private void OnEnable()
    {
        _tavern.interactable = true;
        HintController.ActivateHint(_tavern);
        ShowMessage(this);
    }
}
